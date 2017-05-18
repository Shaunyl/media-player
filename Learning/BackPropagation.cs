using System;
using System.Collections.Generic;
using System.Linq;

using Shauni.Database;
using Maths.Learning;
using Maths;
using Maths.Statistics;
using Maths.Extensions;

namespace Shauni.Learning
{
    public class BackPropagation
    {
        private List<TrainingSetRecord> query;

        public Matrix X { get; private set; }
        public Matrix Y { get; private set; }

        public BackPropagation(IEnumerable<TrainingSetRecord> data)
        {
        }

        private void LoadData()
        {
            X = Matrix.LoadFromFile("iris_x.txt");
            Y = Matrix.LoadFromFile("iris_y.txt");
        }

        private void Normalize(Matrix X, int d)
        {
            for (int i = 0; i < d; i++)
            {
                double minX = Vector.Min(X.Column(i));
                double maxX = Vector.Max(X.Column(i));
                for (int j = 0; j < X.Rows; j++)
                    X[j, i] = (X[j, i] - minX) / (maxX - minX);
            }
        }

        private void Run()
        {
            RandomNumberGenerator.SetSeed();

            Int32 n = X.Rows;
            Int32 d = X.Columns;

            //Class Vs. Class: like or not like. But more than two attributes: Tempo, Danceability, Energy, Key
            //X = (N, 4)
            //Y = (N, 1)
            Y.Update(1, 1, Criteria.EqualsTo);
            Y.Update(2, -1, Criteria.EqualsTo);
            Y.Update(3, 1, Criteria.EqualsTo);

            //Normalization
            Normalize(X, d);

            int hiddenLayersNeurons = 2; //numero strati nascosti... //fisso mmmh...
            double threshold = 1 * Math.Pow(10, -3);
            int outNeurons = 1; //numero neuroni in uscita.., one class...

            ColumnVector layerNeurons = new ColumnVector(d, hiddenLayersNeurons, outNeurons);

            int neurodes = layerNeurons.Count - 1; //escludiamo lo strato degli input.

            Cell Wf = new Cell(1, neurodes);
            Cell bf = new Cell(1, neurodes);

            Int32 iterations = new MultiLayerPerceptronLearningAlgorithm(layerNeurons).Run(X, Y, ref Wf, ref bf);

            // Validation

            int nf = 30000;
            //Matrix XF = Matrix.Randn(nf, d, 3.5, 2);
            Matrix XF = Matrix.Rand(nf, d);

            XF.AlongsideTo<RowVector>(Matrix.Ones(XF.Size(1), 1));
            Cell Ff = new Cell(1, neurodes);

            // feed forward phase
            Wf[0, 0].AlongsideTo<ColumnVector>(bf[0, 0]);
            Ff[0, 0] = ActivationFunctions.Tanh(XF * (Wf[0, 0]));

            for (int i = 1; i < neurodes; i++)
            {
                Ff[0, i - 1].AlongsideTo<RowVector>(Matrix.Ones(Ff[0, i - 1].Size(1), 1));
                Wf[0, i].AlongsideTo<ColumnVector>(bf[0, i]);
                Ff[0, i] = ActivationFunctions.Tanh(Ff[0, i - 1] * Wf[0, i]);
            }

            Matrix YF = Ff[0, neurodes - 1];
        }
    }
}
