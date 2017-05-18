/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Maths.Graphs;
using Shauni.Database;
using Maths.Learning;

namespace Shauni.LearningCICO
{
    //public delegate void LearningDoneEventhandler(object sender, LearningDoneEventArgs e);

    public class WorkerThreadLearning
    {
        private DecisionTree learning = new DecisionTree();

        private Thread workerThread;
        public event LearningDoneEventhandler LearningDone;
        public event EventHandler TreeUpdated;

        private ManualResetEvent trigger = new ManualResetEvent(true);

        public WorkerThreadLearning()
        {
        }

        public void Start(IMedia media, bool rebuilt)
        {
            // The advantage(s) of this (over ParameterizedThreadStart) is that you can pass multiple parameters,
            // and you get compile-time checking without needing to cast from object all the time.
            workerThread = new Thread(() => DoLearning(media, rebuilt));
            workerThread.Start();
        }

        public void Start()
        {
            workerThread = new Thread(() => DoLearning());
            workerThread.Start();
        }

        private void DoLearning(IMedia media, bool rebuilt = true)
        {
            ColoredTree<string, string> decisionTree = null;

            decisionTree = (rebuilt) ? UpdateDecisionTree() : Utility.Deserialize<ColoredTree<string, string>>(Paths.DecisionTree);

            if (media != null)
            {
                LearningDoneEventArgs e = new LearningDoneEventArgs(this.Predict(decisionTree, media));
                OnLearningDone(e);
            }
        }

        private ColoredTree<string, string> UpdateDecisionTree()
        {
            learning.ExtractDataFromDatabase();

            ID3Learning id3 = new ID3Learning();
            id3.Initialize(learning.DataCell);
            ColoredTree<string, string> decisionTree = id3.Run(learning.Dataset, learning.Target);

            this.SerializeTree(decisionTree);

            return decisionTree;
        }

        private void SerializeTree(ColoredTree<string, string> decisionTree)
        {
            decisionTree.Serialize(Paths.DecisionTree);
        }

        private void DoLearning()
        {
            DoLearning(null, true);
            OnTreeUpdated();
        }

        private bool? Predict(ColoredTree<string, string> decisionTree, IMedia media)
        {
            Song song = SharedData.Database.Song.Where(m => m.Name == media.Name).FirstOrDefault();
            return learning.Predict<Song>(decisionTree, song);
        }

        protected virtual void OnLearningDone(LearningDoneEventArgs e)
        {
            if (LearningDone != null)
                LearningDone(this, e);
        }

        protected virtual void OnTreeUpdated()
        {
            if (TreeUpdated != null)
                TreeUpdated(this, EventArgs.Empty);
        }
    }

    public class LearningDoneEventArgs : EventArgs
    {
        public bool? Prediction { get; private set; }

        public LearningDoneEventArgs(bool? prediction)
        {
            this.Prediction = prediction;
        }
    }
}
*/