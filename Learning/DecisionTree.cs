using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

using Shauni.Database;
using Maths.Learning;
using Maths.Graphs;
using Maths;

namespace Shauni.Learning
{
    public class DecisionTree
    {
        private List<TrainingSetRecord> query;

        public DataCell DataCell { get; private set; }
        public Matrix Dataset { get; private set; }
        public Matrix Target { get; private set; }

        private const int tempoStep = 10, tempoSample = (tempoStep / 2);
        private const double energyStep = 0.1d, energySample = (energyStep / 2);

        public DecisionTree(IEnumerable<TrainingSetRecord> data)
        {
            query = data.ToList();

            FilterValues(query);
            CreateDatacell(query);
        }

        private void FilterValues(List<TrainingSetRecord> input)
        {
            bool checkDanceability = false, checkEnergy = false;

            for (int i = 0; i < input.Count; i++)
            {
                for (int start = 20; start < 201; start += tempoStep)
                {
                    if (input[i].Tempo.Between(start, (start + tempoStep)))
                    {
                        input[i].Tempo = (start + tempoStep) - tempoSample;
                        break;
                    }
                }

                for (double start = 0; start < 1; start += energyStep)
                {
                    if (input[i].Danceability.Between(start, (start + energyStep)) && !checkDanceability)
                    {
                        input[i].Danceability = Math.Round((start + energyStep) - energySample, 2);
                        checkDanceability = true;
                    }

                    if (input[i].Energy.Between(start, (start + energyStep)) && !checkEnergy)
                    {
                        input[i].Energy = Math.Round((start + energyStep) - energySample, 2);
                        checkEnergy = true;
                    }

                    if (checkDanceability && checkEnergy) break;
                }
                checkDanceability = checkEnergy = false;
            }
        }

        private void CreateDatacell(IEnumerable<TrainingSetRecord> query)
        {
            Dataset = Matrix.Zeros(0, 0);
            Target = Matrix.Zeros(0, 0);

            DataCell = new DataCell();

            DataCell.Add(new DataAttribute(0, "Tempo", query.Select(s => Convert.ToString(s.Tempo)).Distinct().OrderBy(s => s).ToArray()));
            DataCell.Add(new DataAttribute(1, "Danceability", query.Select(s => Convert.ToString(s.Danceability)).Distinct().OrderBy(s => s).ToArray()));
            DataCell.Add(new DataAttribute(2, "Energy", query.Select(s => Convert.ToString(s.Energy)).Distinct().OrderBy(s => s).ToArray()));
            DataCell.Add(new DataAttribute(3, "Key", query.Select(s => Convert.ToString(s.Key)).Distinct().OrderBy(s => s).ToArray()));
            DataCell.Add(new DataAttribute(4, "Favourite", "False", "True"));

            this.Populate(query.ToList());
        }

        private void Populate(List<TrainingSetRecord> datalist)
        {
            for (int i = 0; i < datalist.Count; i++)
            {
                RowVector row = new RowVector((double)DataCell[0].Values.Where(v => v.Value == datalist[i].Tempo.ToString()).FirstOrDefault().Key
                    , (double)DataCell[1].Values.Where(v => v.Value == datalist[i].Danceability.ToString()).FirstOrDefault().Key
                    , (double)DataCell[2].Values.Where(v => v.Value == datalist[i].Energy.ToString()).FirstOrDefault().Key
                    , (double)DataCell[3].Values.Where(v => v.Value == datalist[i].Key.ToString()).FirstOrDefault().Key);
                
                Dataset.AddRow(row);

                Target.AddRow(new RowVector(datalist[i].Grouping.ToList()[0].Favourite.Value ? 1f : 0f));
            }
        }

        private Attribute GetAttribute(String data)
        {
            return Utility.GetEnumValueFromString<Attribute>(data);
        }

        public Int32 Predict<V>(ColoredTree<string, string> tree, V media)
            where V : class, IMedia
        {
            if (media == null)
                return -1;

            if (typeof(V) != typeof(Song))
                return -1;

            ColoredTree<string, string>.Vertex vertex = tree.Root;

            Song song = media as Song;

            while (true)
            {
                Attribute attribute = Utility.GetEnumValueFromString<Attribute>(vertex.Data);
                ColoredGraph<string, string>.Edge edge = null;

                if (attribute == Attribute.Tempo)
                {
                    edge = tree.FindEdges(vertex, EdgeEnds.Start).Where(e => int.Parse(e.Data) - tempoSample < song.EchoNest.Tempo && song.EchoNest.Tempo < int.Parse(e.Data) + tempoSample).FirstOrDefault();
                }
                else if (attribute == Attribute.Danceability)
                {
                    edge = tree.FindEdges(vertex, EdgeEnds.Start).Where(e => e.Data == song.EchoNest.Danceability.ToString()).FirstOrDefault();
                }
                else if (attribute == Attribute.Energy)
                {
                    edge = tree.FindEdges(vertex, EdgeEnds.Start).Where(e => double.Parse(e.Data) - energySample < song.EchoNest.Energy && song.EchoNest.Energy < double.Parse(e.Data) + energySample).FirstOrDefault();
                }
                else if (attribute == Attribute.Key)
                {
                    edge = tree.FindEdges(vertex, EdgeEnds.Start).Where(e => e.Data == song.EchoNest.Key.ToString()).FirstOrDefault();
                }

                if (edge == null) break;

                vertex = edge.End;

                if (vertex == null) break;

                int leaf = Parse(vertex);

                if (leaf != -1)
                    return leaf;
            }

            return -1;
        }

        private Int32 Parse(ColoredTree<string, string>.Vertex vertex)
        {
            return (vertex.Data == "True" ? 1 : (vertex.Data == "False") ? 0 : -1);
        }
    }
}
