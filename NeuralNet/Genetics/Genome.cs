﻿namespace NeuralNet.Genetics
{
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet.Helpers;

    public class Genome : IGenome<double>
    {
        private readonly Rand _rand = Rand.Generator;

        public IList<double> Chromosome { get; set; }

        public double Fitness { get; private set; }

        public Genome() { }

        public Genome(double fitness)
        {
            Fitness = fitness;
        }

        public Genome(int chromosomeSize, double fitness)
            : this(fitness)
        {
            Chromosome = Enumerable.Range(0, chromosomeSize).Select(x => _rand.NextClamped()).ToArray();
        }

        public Genome(IEnumerable<double> chromosome, double fitness)
            : this(fitness)
        {
            Chromosome = chromosome.ToArray();
        }

        public void ResetFitness()
        {
            Fitness = 0;
        }

        public void IncreaseFitness(int fitnessIncrease)
        {
            Fitness += fitnessIncrease;
        }

        public void DecreaseFitness(int fitnessDecrease)
        {
            Fitness -= fitnessDecrease;
        }
    }
}
