using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

using Shauni.Database;
using Shauni.Properties;
using Maths.Graphs;
using Maths.Learning;

namespace Shauni.Learning
{
    public delegate void LearningDoneEventHandler(object sender, LearningDoneEventArgs e);
    //public delegate void PredictionDoneEventHandler(object sender, PredictionDoneEventArgs e);

    public abstract class ILearning
    {
        protected Thread workerThread;
        public event LearningDoneEventHandler LearningDone;

        public IEnumerable<TrainingSetRecord> Data { get; set; }

        public abstract void Predict(Song song);

        protected virtual void OnLearningDone(LearningDoneEventArgs e)
        {
            if (LearningDone != null)
                LearningDone(this, e);
        }
    }

    public class BackpropagationLearning : ILearning
    {
        public override void Predict(Song media)
        {
        }
    }

    public class NaiveBayesLearning : ILearning
    {
        private NaiveBayes bayes;
        private Song song;

        public NaiveBayesLearning(IEnumerable<TrainingSetRecord> data)
        {
            this.bayes = new NaiveBayes(data);
            this.Data = data;
        }

        public override void Predict(Song media)
        {
            this.song = media;

            workerThread = new Thread(() => Run());
            workerThread.Start();
        }

        protected void Run()
        {
            bayes.Initialize(false);

            LearningDoneEventArgs e = new LearningDoneEventArgs(this.Predict());
            e.Media = song;
            OnLearningDone(e);
        }
        
        private int Predict()
        {
            var echo = song.EchoNest;


            int prediction = bayes.Run(new List<double>()
                {
                      (double)echo.Tempo
                    , (double)echo.Danceability
                    , (double)echo.Energy
                    , (double)echo.Key
                });

            return prediction;
        }
    }

    public class DecisionTreeLearning : ILearning
    {
        public event EventHandler TreeUpdated;
        private DecisionTree learning;

        private bool _rebuild;

        public DecisionTreeLearning(IEnumerable<TrainingSetRecord> data, bool rebuild = false)
        {
            this._rebuild = rebuild;
            this.learning = new DecisionTree(data);
            this.Data = data;
        }

        public override void Predict(Song media)
        {
            workerThread = new Thread(() => Run(media));
            workerThread.Start();
        }

        private void Run(Song media)
        {
            ColoredTree<string, string> decisionTree = (_rebuild || !File.Exists(Paths.DecisionTree)) ? UpdateTree() : DeserializeTree(Paths.DecisionTree);

            LearningDoneEventArgs e = new LearningDoneEventArgs(this.Predict(decisionTree, media));
            e.Media = media;

            OnLearningDone(e);
        }

        private int Predict(ColoredTree<string, string> decisionTree, Song media)
        {
            Song song = SharedData.Database.Song.Where(m => m.Name == media.Name).FirstOrDefault();
            return learning.Predict<Song>(decisionTree, song);
        }

        private ColoredTree<string, string> DeserializeTree(String filename)
        {
            return Utility.Deserialize<ColoredTree<string, string>>(filename);
        }

        private ColoredTree<string, string> UpdateTree()
        {
            ID3Learning id3 = new ID3Learning();
            id3.Initialize(learning.DataCell);

            ColoredTree<string, string> decisionTree = id3.Run(learning.Dataset, learning.Target);

            this.SerializeTree(decisionTree);
            this.OnTreeUpdated();

            return decisionTree;
        }

        private void SerializeTree(ColoredTree<string, string> decisionTree)
        {
            decisionTree.Serialize(Paths.DecisionTree);
        }

        protected virtual void OnTreeUpdated()
        {
            if (TreeUpdated != null)
                TreeUpdated(this, EventArgs.Empty);
        }
    }

    class LearningContext
    {
        private ILearning learning;
        private IEnumerable<TrainingSetRecord> data;
        public event EventHandler<PredictionDoneEventArgs> PredictionDone;

        protected void OnPredictionDone(PredictionDoneEventArgs e)
        {
            if (PredictionDone != null)
                PredictionDone(this, e);
        }

        public void InitializeAlgorithm(IEnumerable<TrainingSetRecord> data)
        {
            this.data = data;

            if (Settings.Default.LearningSystem.Equals("Naive Bayes"))
            {
                learning = new NaiveBayesLearning(data);
            }
            else if (Settings.Default.LearningSystem.Equals("Decision Tree"))
            {
                learning = new DecisionTreeLearning(data, true);
            }

            learning.LearningDone += new LearningDoneEventHandler(learning_LearningDone);
        }

        private void learning_LearningDone(object sender, LearningDoneEventArgs e)
        {
            PredictionDoneEventArgs pd = new PredictionDoneEventArgs();
            if (e.Prediction == 1)
                pd.Media = e.Media;

            OnPredictionDone(pd);
        }

        public void Predict(Song song)
        {
            this.learning.Predict(song);
        }
    }

    public class LearningDoneEventArgs : EventArgs
    {
        public int Prediction { get; private set; }
        public IMedia Media { get; set; }

        public LearningDoneEventArgs(int prediction)
        {
            this.Prediction = prediction;
        }
    }

    public class PredictionDoneEventArgs : EventArgs
    {
        public IMedia Media { get; set; }

        public PredictionDoneEventArgs()
        {
        }
    }
}
