using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace WindowsFormsApp_Hausarbeit
{
    public class GeneticAlgorithm4Double
    {
        // Parameter für den GA
        int PopulationSize { get; set; }
        public int Generations { get; set; }
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        //public double[,] data_YHL { get; set; }    
        public double[] bestIndividuum { get; set; } = new double[6];
        public double bestFinalFitness { get; private set; }
        public double globalBestFitness { get; private set; } = double.MaxValue; 

        public List<Individual4Double> population = new List<Individual4Double>();

        public Random rnd = new Random();
        // public List<CR_Mutation_Individual> genome;
        

        public GeneticAlgorithm4Double(int PopulationSize, double CrossoverRate, double MutationRate, int Generations)
        {
            this.PopulationSize = PopulationSize;
            this.Generations = Generations;
            this.MutationRate = MutationRate;
            this.CrossoverRate = CrossoverRate;
            this.rnd = new Random();
        }

        private Func<double[], double> fitnessFunction;                         // Delegate für Fitness-Funktion

        public void SetFitnessFunction(Func<double[], double> fitnessFunction)
        {
            this.fitnessFunction = fitnessFunction;
            Console.WriteLine("Fitness-Funktion wird richtig durchgeführt.");
        }

        public void EvaluatePopulation()
        {
            if (fitnessFunction == null)
            {
                Console.WriteLine("Fitness-Funktion ist null. Population kann nicht evaluiert werden.");
                return;
            }

            foreach (var individual in population)
            {
                //Console.WriteLine($"Berechne Fitness für: {string.Join(", ", individual.Genome)}");
                individual.Fitness = fitnessFunction(individual.Genome);
                //Console.WriteLine($"Fitness-Wert: {individual.Fitness}");

                // individual.Fitness = fitnessFunction(individual.Genome);        // Fitness berechnen
            }
        }

        public void InitializePopulation(int genomeLength)                      // Erstellt ein Individuum mit einem zufälligen Genom
        {
            population.Clear();
            for (int i = 0; i < PopulationSize; i++)
            {
                Console.WriteLine($"Erstelle Individuum {i+1}");
                Individual4Double individual = new Individual4Double(genomeLength, rnd, new GetFitness(fitnessFunction));
                population.Add(individual);
                //Console.WriteLine($"Genom des Individuums {i + 1}: {string.Join(", ", individual.Genome)}");
            }
        }

        //public void EvaluatePopulation()                                      // Bewertet die Fitness jedes Individuums in der Population
        //{
        //    foreach (var individual in population)
        //    {
        //        individual.EvaluateFitness();
        //    }
        //}

        public void SortPopulationByFitness()                                   // Aussteigende Sortierung die Population nach Fitness 
        {
            population.Sort();
            bestFinalFitness = Math.Max(population[0].Fitness, 0.0);            // Fitness des besten Individuums speichern
            //Console.WriteLine($"Beste Fitness nach Sortierung: {bestFinalFitness}");

            if (bestFinalFitness < globalBestFitness)
            {
                globalBestFitness = bestFinalFitness;
                bestIndividuum = population[0].Genome;                          // Speichert das Genom des besten Individuums
                //Console.WriteLine($"Neues bestIndividuum: {string.Join(", ", bestIndividuum)}");
            }
        }

        public void GenerateNewPopulation()
        {
            //Console.WriteLine("Neue Generation wird generiert.");
            // Erstelle eine neue Population basierend auf den besten 50% der Eltern
            List<Individual4Double> newPopulation = new List<Individual4Double>();

            // Wähle die besten 50% Eltern
            int numOfParents = PopulationSize / 2;
            List<Individual4Double> parents = population.Take(numOfParents).ToList();

            while (newPopulation.Count < PopulationSize)                                // Erstellt neue Genome durch Crossover+Mutation
            {
                Individual4Double parent1 = parents[rnd.Next(parents.Count)];           // Wählt zwei zufällige Elternteile
                Individual4Double parent2 = parents[rnd.Next(parents.Count)];
                
                IndividualBase child = parent1.Crossover(parent2, CrossoverRate, rnd);  // Erzeugt ein Kind durch Crossover

                Individual4Double childIndividual = (Individual4Double)child;           // IndividualBase-Kind wird zu CR_Mutation_Individual

                childIndividual.MutationRate = this.MutationRate;                       // Setze die Mutationsrate für das Kind

                childIndividual.Mutation(rnd);                                          // Führe eine Mutation am Kind durch

                //childIndividual.EvaluateFitness();

                newPopulation.Add(childIndividual);                                     // Füge das Kind zur neuen Population hinzu
            }
            population = newPopulation;                                                 // Ersetze die alte Population durch die neue

            //foreach (var individual in population)
            //{
            //    Console.WriteLine($"Hier sind Genome: {string.Join(", ", individual.Genome)}, und Fitness: {individual.Fitness}");
            //}

        }

        public void RunGA(Action<GeneticAlgorithm4Double> Logging = null)
        {
            InitializePopulation(6);

            for (int gen = 0; gen < Generations; gen++)
            {
                Console.WriteLine($"Generation {gen + 1} beginnt...");

                EvaluatePopulation();

                SortPopulationByFitness();

                GenerateNewPopulation();

                if (Logging != null) Logging(this);
            }
        }
    }
}