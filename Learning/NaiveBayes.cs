using System;
using System.Collections.Generic;
using System.Linq;

using Shauni.Database;
using Maths.Learning;
using Maths;

namespace Shauni.Learning
{
    public class NaiveBayes
    {
        private BayesNaiveLearningAlgorithm bayes = BayesNaiveLearningAlgorithm.Create(ProbabilityDensityFunctionType.Gaussian);

        private List<TrainingSetRecord> query;
        private Matrix Dataset = Matrix.Zeros(0, 0);
        private Matrix Target = Matrix.Zeros(0, 0);

        private double[] TempoRange = new double[] { 0, 500 };
        private int[] KeyRange = new int[] { 0, 11 };

        public NaiveBayes(IEnumerable<TrainingSetRecord> data)
        {
            query = data.ToList();
        }

        public int Run(List<double> sample)
        {
            this.NormalizeInput(ref sample);
            bayes.Samples = sample;
            return bayes.Run(Dataset, Target);
        }

        private void NormalizeInput(ref List<double> sample)
        {
            sample[0] = Extensions.Normalize(sample[0], TempoRange[0], TempoRange[1]);
            sample[3] = Extensions.Normalize(sample[3], KeyRange[0], KeyRange[1]);
        }

        public void Initialize(bool IsCategorical = false)
        {
            bayes.IsCategorical = IsCategorical;
            this.Populate();
        }

        private void Populate()
        {
            if (query == null)
                return;

            //TempoRange = query.Select(t => t.Tempo).MinMax();
            //KeyRange = query.Select(t => t.Key).MinMax();

            for (int i = 0; i < query.Count; i++)
            {
                double tempo = query[i].Tempo;
                double key = query[i].Key;

                this.Dataset.AddRow(
                    new RowVector(
                        Extensions.Normalize(tempo, TempoRange[0], TempoRange[1])
                        , query[i].Danceability, query[i].Energy
                        , Extensions.Normalize(key, KeyRange[0], KeyRange[1])
                        /*query[i].Key.Normalize(KeyRange[0], KeyRange[1])*/));

                this.Target.AddRow(new RowVector(query[i].Grouping.ToList()[0].Favourite.Value ? 1f : 0f));
            }
        }
    }
}
