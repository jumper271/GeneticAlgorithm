using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp_Hausarbeit;
using ZedGraph;

namespace WindowsFormsApp_Hausarbeit
{
    public delegate double GetFitness(double[] DeliverIndividal);

    public abstract class IndividualBase : IComparable<IndividualBase>
    {
        protected double fitness;

        public double Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }

        public int CompareTo(IndividualBase others)
        {
            return fitness.CompareTo(others.fitness);
        }

        public double LookIntoFitness()
        {
            return this.fitness;
        }

        public abstract IndividualBase Crossover(IndividualBase partner, double CrossoverRate, Random rnd);
        public abstract void Mutation(Random rnd);

    }

    public class Individual4Double : IndividualBase
    {
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public Random rnd = new Random();

        //private FitnessFunc fitnessFunc;
        private GetFitness getFitness;

        public double[] genome;
        public double[] Genome
        {
            get { return genome; }
        }

        //public Individual4Double(double[,] data_YHL)
        //{
        //    this.fitnessFunc = new FitnessFunc(data_YHL); // Initialisierung der Fitness-Funktion
        //    this.getFitness = fitnessFunc.CalcFitness;
        //}

        public Individual4Double(int variables, Random rnd, GetFitness CalcFitness)
        {
            this.rnd = rnd;

            //Console.WriteLine("Starter-Zufallsgen wird erstellt.");

            double[] gene = new double[variables];

            gene[0] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Jagdrate Luchse a
            gene[1] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für den Umrechnungsfaktor b
            gene[2] = rnd.NextDouble() * (60 - 0.1) + 0.1;    // Zufallwert für die Michaelis-Konstante c
            gene[3] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Sterberate Luchse d
            gene[4] = rnd.NextDouble() * (150 - 0.1) + 0.1;   // Zufallwert für die Trägerkapazität k
            gene[5] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Reproduktionsrate Hase r

            // Test-Gene
            //gene[0] = 1;     // Zufallwert für die Jagdrate Luchse a
            //gene[1] = 2;     // Zufallwert für den Umrechnungsfaktor b
            //gene[2] = 40;    // Zufallwert für die Michaelis-Konstante c
            //gene[3] = 3;     // Zufallwert für die Sterberate Luchse d
            //gene[4] = 100;   // Zufallwert für die Trägerkapazität k
            //gene[5] = 4;     // Zufallwert für die Reproduktionsrate Hase r

            //Console.WriteLine("Starter-Zufallsgen: " + string.Join(", ", gene));

            this.genome = gene;

            //Console.WriteLine("Vor Aufruf von CalcFitness");
            getFitness = CalcFitness;
            //Console.WriteLine($"Fitness-Wert: {getFitness(gene)}");
            //Console.WriteLine("Nach Aufruf von CalcFitness");
        }

        public void EvaluateFitness()
        {
            fitness = getFitness(genome);
            //Console.WriteLine($"Berechneter Fitness-Wert: {fitness}");
        }

        public override IndividualBase Crossover(IndividualBase partner, double CrossoverRate, Random rnd)
        {
            // Array.Sort(genome);

            //Console.WriteLine("CO wird durchgeführt.");

            Individual4Double child;
            double[] child_genome = new double[this.genome.Length];

            double[] parent_one = this.genome;
            double[] parent_two = ((Individual4Double)partner).Genome;

            for (int current_nr = 0; current_nr < child_genome.Length; current_nr++)
            {
                if (rnd.NextDouble() < CrossoverRate)
                { 
                    child_genome[current_nr] = parent_one[current_nr];                                      // Aktuelles Gen des Kindes ist von parent_one
                }
                else
                {
                    for (int i_genom_zwei = current_nr; i_genom_zwei < child_genome.Length; i_genom_zwei++) // Aktuelles (und folgende) Gen des Kindes ist von parent_two
                    {
                        child_genome[current_nr] = parent_two[current_nr];

                        current_nr++;
                    }
                }
            }
            child = new Individual4Double(child_genome);
            return child;
        }

        public Individual4Double(double[] genome)
        {
            //Console.WriteLine("Konstruktor mit Parameter genome wird aufgerufen");
            this.genome = genome;
        }

        public override void Mutation(Random rnd)
        {
            //Console.WriteLine("Mutation wird durchgeführt.");

            if (rnd.NextDouble() < MutationRate) genome[0] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Jagdrate Luchse a
            if (rnd.NextDouble() < MutationRate) genome[1] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für den Umrechnungsfaktor b
            if (rnd.NextDouble() < MutationRate) genome[2] = rnd.NextDouble() * (60 - 0.1) + 0.1;    // Zufallwert für die Michaelis-Konstante c
            if (rnd.NextDouble() < MutationRate) genome[3] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Sterberate Luchse d
            if (rnd.NextDouble() < MutationRate) genome[4] = rnd.NextDouble() * (150 - 0.1) + 0.1;   // Zufallwert für die Trägerkapazität k
            if (rnd.NextDouble() < MutationRate) genome[5] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Reproduktionsrate Hase r

            double[] child_genome = this.genome;
            double[] mutated_child = new double[child_genome.Length];
        }
        public override string ToString()
        {
            return $"{Fitness}";
        }

    }
}
