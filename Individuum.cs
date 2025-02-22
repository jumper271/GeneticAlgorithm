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

//    if (rnd.NextDouble() >= MutationRate)             // Prüft, ob eine Mutation stattfindet
//    {
//        this.genome = child_genome;                   // Rückgabe einer Kopie des aktuellen Individuums ohne Mutation
//    }
//    else
//    {
//        // Durchführen einer von drei Mutationen
//        switch (rnd.Next(3))
//        {
//            case 0: // Gen löschen
//                if (genome.Length > 1)                // Nur löschen, wenn Länge > 1
//                {
//                    int deleteIndex = rnd.Next(genome.Length);
//                    genome = genome.Where((_, index) => index != deleteIndex).ToArray();
//                }
//                break;

//            case 1: // Gen ändern
//                int changeIndex = rnd.Next(genome.Length);
//                genome[changeIndex] = rnd.NextDouble() * (5 - 0.1) + 0.1;   // Zufällige Zahl
//                break;
//        }
//    }
//    this.genome = mutated_child;
//}

// end class

//public class CR_Mutation_Individual : Individual4Double
//{
//    public CR_Mutation_Individual(int variables, Random rnd)
//    {
//        double[] gene = new double[variables];

//        gene[0] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Jagdrate Luchse a
//        gene[1] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für den Umrechnungsfaktor b
//        gene[2] = rnd.NextDouble() * (60 - 0.1) + 0.1;    // Zufallwert für die Michaelis-Konstante c
//        gene[3] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Sterberate Luchse d
//        gene[4] = rnd.NextDouble() * (150 - 0.1) + 0.1;   // Zufallwert für die Trägerkapazität k
//        gene[5] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Reproduktionsrate Hase r

//        this.genome = gene;
//    }

////public override IndividualBase Crossover(IndividualBase partner, double CrossoverRate, Random rnd)
////{
////    // Array.Sort(genome);

////    CR_Mutation_Individual child;
////    double[] child_genome = new double[this.genome.Length];

////    double[] parent_one = this.genome;
////    double[] parent_two = ((Individual4Double)partner).Genome;

////    for (int current_nr = 0; current_nr < child_genome.Length; current_nr++)
////    {
////        if (rnd.Next(0, 1) < CrossoverRate) 
////        {
////            child_genome[current_nr] = parent_one[current_nr];          // Aktuelles Gen des Kindes ist von parent_one
////        }
////        else
////        {
////            for (int i_genom_zwei = current_nr; i_genom_zwei < child_genome.Length; i_genom_zwei++) // Aktuelles (und folgende) Gen des Kindes ist von parent_two
////            {
////                child_genome[current_nr] = parent_two[current_nr];

////                current_nr++;
////            } 
////        }
////    }
////    child = new CR_Mutation_Individual(child_genome);
////    return child;
////}

////public CR_Mutation_Individual(double[] genome)
////{
////    this.genome = genome;
////}

////public override void Mutation(Random rnd)
////{
////    double[] child_genome = this.genome;
////    double[] mutated_child = new double[child_genome.Length];

////    if (rnd.NextDouble() >= MutationRate)             // Prüft, ob eine Mutation stattfindet
////    {
////        this.genome = child_genome;                   // Rückgabe einer Kopie des aktuellen Individuums ohne Mutation
////    }
////    else
////    {
////        // Durchführen einer von drei Mutationen
////        switch (rnd.Next(3))
////        {
////            case 0: // Gen löschen
////                if (genome.Length > 1)                // Nur löschen, wenn Länge > 1
////                {
////                    int deleteIndex = rnd.Next(genome.Length);
////                    genome = genome.Where((_, index) => index != deleteIndex).ToArray();
////                }
////                break;

////            case 1: // Gen ändern
////                int changeIndex = rnd.Next(genome.Length);
////                genome[changeIndex] = rnd.NextDouble() * (5 - 0.1) + 0.1;   // Zufällige Zahl
////                break;

////            case 2: // Gen hinzufügen
////                double newGene = rnd.NextDouble() * (5 - 0.1) + 0.1;
////                int insertIndex = rnd.Next(genome.Length + 1);
////                genome = genome.Take(insertIndex).Concat(new[] { newGene }).Concat(genome.Skip(insertIndex)).ToArray();
////                break;
////        }
////    }
////    this.genome = mutated_child;
////}
//}


//public class Individual : Individual4Double
//{
//    public Individual(double crossoverRate, double[] genome)
//    {
//        this.CrossoverRate = crossoverRate;
//        this.genome = genome;
//    }
//}

//public class CreateGenome : IndividualBase
//{
//    protected double[] genome;

//    public double[] Genome
//    {
//        get { return genome; }
//        set { }
//    }

//    // Leere Implementierungen
//    public override void EvaluateFitness()
//    {

//    }

//    public override IndividualBase Mutation(Random rnd)
//    {
//        return this;
//    }

//    public override IndividualBase Crossover(IndividualBase partner, Random rnd)
//    {
//        return this;
//    }
//}


//public delegate double GetFitness(double[] DeliverIndividal);
//public abstract class IndividualBase : IComparable<IndividualBase>
//{

//    protected double fitness;

//    public double Fitness { get { return fitness; } }

//    public int CompareTo(IndividualBase others)
//    {
//        return fitness.CompareTo(others.fitness);
//    }

//    public abstract void EvaluateFitness();
//    public abstract IndividualBase CrossOver(IndividualBase partner, Random rnd);
//    public abstract IndividualBase Mutation(Random rnd);

//}

//public abstract class IndividualBase4Strings : IndividualBase
//{
//    protected double[] genome;
//    private FitnessFunc fitnessFunc = new FitnessFunc();
//    private GetFitness getfitness;

//    public IndividualBase4Strings()
//    {
//        getfitness = fitnessFunc.CalcFitness; 
//    }

//    public double[] Genome { get { return genome; } }

//    public override void EvaluateFitness()
//    {
//        fitness = getfitness(genome);
//    }

//    public override IndividualBase Mutation(Random rnd)
//    {
//        switch (rnd.Next(3))
//        {
//            case 0: // Gen löschen
//                if (genome.Length > 1)                              // Nur löschen, wenn Länge > 1
//                {
//                    int deleteIndex = rnd.Next(genome.Length);
//                    genome = genome.Where((_, index) => index != deleteIndex).ToArray();
//                }
//                break;

//            case 1: // Gen ändern
//                int changeIndex = rnd.Next(genome.Length);
//                genome[changeIndex] = rnd.NextDouble() * (5 - 0.1) + 0.1; // Zufälliges Zeichen
//                break;

//            case 2: // Gen hinzufügen
//                double newGene = rnd.NextDouble() * (5 - 0.1) + 0.1;
//                int insertIndex = rnd.Next(genome.Length + 1);
//                genome = genome.Take(insertIndex).Concat(new[] { newGene }).Concat(genome.Skip(insertIndex)).ToArray();
//                break;
//        }
//        return this;
//    }

//    public override string ToString()
//    {
//        return base.ToString();
//    }
//}

//public class Individual : IndividualBase4Strings
//{
//    public double CrossoverRate { get; set; }
//    public Individual(double crossoverRate, double[] genome)
//    {
//        this.CrossoverRate = crossoverRate;
//        this.genome = genome;
//    }

//    public override IndividualBase CrossOver(IndividualBase partner, Random rnd)
//    {
//        if (partner is Individual other) // Sicherstellen, dass der Partner als Individual gecastet wird
//        {
//            // Prüfen, ob kein Crossover stattfindet
//            if (rnd.NextDouble() >= CrossoverRate)                  // Bestimmt, ob ein Crossover stattfindet
//            {
//                // Rückgabe einer Kopie von einem der Eltern
//                return new Individual(CrossoverRate, this.genome);
//            }

//            // Crossover durchführen
//            int crossoverPoint = rnd.Next(genome.Length);           // Wählt zufälligen Punkt im Genom
//            double[] newGenome = new double[genome.Length];         // Neues Genom für das Kind

//            for (int i = 0; i < crossoverPoint; i++)                // Kopiert Gene vom ersten Elternteil bis zum Crossover-Punkt
//            {
//                newGenome[i] = this.genome[i];
//            }

//            for (int i = crossoverPoint; i < genome.Length; i++)    // Kopiert Gene vom zweiten Elternteil ab dem Crossover-Punkt
//            {
//                newGenome[i] = other.genome[i];
//            }

//            return new Individual(CrossoverRate, newGenome);        // Rückgabe eines neuen Individuums mit dem kombinierten Genom
//        }
//        else
//        {
//            throw new InvalidOperationException("Partner is not of type Individual.");
//        }
//        //    Individual other = (Individual)partner;

//        //    // Ein-Punkt-Crossover: 
//        //    if (rnd.NextDouble() >= CrossoverRate)              // Bestimmt, ob ein Crossover stattfindet
//        //    {
//        //        return rnd.Next(2) == 0 ? new Individual(this.genome, CrossoverRate) : new Individual(other.genome, CrossoverRate);
//        //    }
//        //    else 
//        //    {
//        //    // Kein Crossover, Rückgabe einer Kopie von einem der Eltern
//        //    }

//        //    int crossoverPoint = rnd.Next(genome.Length);       // Wählt zufälligen Punkt im Genom
//        //    double[] newGenome = new double[genome.Length];     // Neues Genom für das Kind

//        //    for (int i = 0; i<crossoverPoint; i++)              // Kopiert Gene vom ersten Elternteil bis zum Crossover-Punkt
//        //    {
//        //        newGenome[i] = this.genome[i];
//        //    }

//        //    for (int i = crossoverPoint; i<genome.Length; i++)  // Kopiert Gene vom zweiten Elternteil ab dem Crossover-Punkt
//        //    {
//        //        newGenome[i] = other.genome[i];
//        //    }

//        //    return new Individual(newGenome, CrossoverRate);    // Rückgabe eines neuen Individuums mit dem kombinierten Genom
//        //}
//    }
//}

//public class CreateGenome : IndividualBase
//{
//    protected double[] genome;
//    public double[] Genome
//    {
//        get { return genome; }
//        set { }
//    }
//}

//public class CreateNewGenome : CreateGenome
//{
//    public CreateNewGenome(int genes, Random rnd)    // Erstellen eines Genomes aus 6 Genen, welche zufällige Zahlen sind, in einem Array
//    {
//        genome = new double[genes];

//        genome[0] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Jagdrate Luchse a
//        genome[1] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Umrechnungsfaktor b
//        genome[2] = rnd.NextDouble() * (60 - 0.1) + 0.1;    // Zufallwert für die Michaelis-Konstante c
//        genome[3] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Sterberate Luchse d
//        genome[4] = rnd.NextDouble() * (150 - 0.1) + 0.1;   // Zufallwert für die Trägerkapazität k
//        genome[5] = rnd.NextDouble() * (5 - 0.1) + 0.1;     // Zufallwert für die Reproduktionsrate Hase r
//    }
//}

