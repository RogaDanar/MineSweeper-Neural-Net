﻿namespace Brainspace.Models.Genetics
{
    using Brainspace.Helpers;
    using System.Collections.Generic;
    using System.Linq;

    public class GeneticAlgorithm
    {
        private readonly Rand _rand = Rand.Generator;

        public double MutationRate { get; set; }

        public double CrossoverRate { get; set; }

        public double PerturbationRate { get; set; }

        public GeneticAlgorithm(double mutationRate, double crossoverRate, double perturbationRate)
        {
            MutationRate = mutationRate;
            CrossoverRate = crossoverRate;
            PerturbationRate = perturbationRate;
        }

        public void Mutate(Genome genome)
        {
            for (int i = 0; i < genome.Chromosome.Count(); i++)
            {
                if (_rand.NextDouble() <= MutationRate)
                {
                    genome.Chromosome[i] += _rand.NextClamped() * PerturbationRate;
                }
            }
        }

        public void Crossover(Genome mother, Genome father, Genome son, Genome daughter)
        {
            if (_rand.NextDouble() <= CrossoverRate && !mother.Equals(father))
            {
                var crossoverPoint = _rand.Next(mother.Chromosome.Count());

                son.Chromosome = mother.Chromosome.Take(crossoverPoint).Concat(father.Chromosome.Skip(crossoverPoint)).ToList();
                daughter.Chromosome = father.Chromosome.Take(crossoverPoint).Concat(mother.Chromosome.Skip(crossoverPoint)).ToList();
            } else
            {
                son.Chromosome = father.Chromosome.ToList();
                daughter.Chromosome = mother.Chromosome.ToList();
            }
        }

        public Population NextGeneration(Population population)
        {
            var elites = population.Genomes.OrderByDescending(x => x.Fitness).Take(4);

            var newGenomes = new List<Genome>();
            newGenomes.AddRange(elites);

            while (newGenomes.Count < population.Genomes.Count())
            {
                var mother = population.GetGenomeByRoulette();
                var father = population.GetGenomeByRoulette();

                var son = new Genome();
                var daughter = new Genome();

                Crossover(mother, father, son, daughter);
                Mutate(son);
                Mutate(daughter);
                newGenomes.Add(son);
                newGenomes.Add(daughter);
            }

            population.Genomes = newGenomes.Take(population.Genomes.Count());
            return population;
        }
    }
}