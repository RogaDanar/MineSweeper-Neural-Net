﻿namespace MineSweeper.Application.Specs
{
    using System;
    using System.Collections.Generic;
    using MineSweeper.Application.Utils;
    using NeuralNet.Genetics;
    using NeuralNet.Network;

    public class SweeperSpecBase
    {
        public event EventHandler NextGenerationEnded = delegate { };

        public event EventHandler TickEnded = delegate { };

        public int Ticks { get { return Settings.Ticks; } }
        public MineSweeperSettings Settings { get; protected set; }

        public SweeperSpecBase(MineSweeperSettings settings)
        {
            Settings = settings;
        }

        protected IEnumerable<Tuple<ObjectType, IList<double>>> GetObjects(ObjectType objectType, int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var newObject = Vector.RandomVector2D(Settings.DrawWidth, Settings.DrawHeight);
                yield return new Tuple<ObjectType, IList<double>>(objectType, newObject);
            }
        }

        protected void RaiseNextGenerationEnded()
        {
            NextGenerationEnded.Raise(this, EventArgs.Empty);
        }

        protected void RaiseTickEnded()
        {
            TickEnded.Raise(this, EventArgs.Empty);
        }

        protected INeuralNet GetNewBrain(int inputs, int outputs)
        {
            return new FeedforwardNetwork(inputs, outputs, Settings.HiddenLayers, Settings.HiddenLayerNeurons);
        }

        protected INeuralNet GetNewBrain(int inputs, int outputs, int sweeperWeightCount)
        {
            var genome = new Genome(sweeperWeightCount);
            return new FeedforwardNetwork(inputs, outputs, Settings.HiddenLayers, Settings.HiddenLayerNeurons, genome);
        }
    }
}