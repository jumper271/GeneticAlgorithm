using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp_Hausarbeit
{
    public partial class Form1 : Form
    {
        public static double[,] data_YHL = new double[91, 3];                     // Einlesen der Text-Datei

        public Form1()
        {
            InitializeComponent();

            #region Daten importieren
            int index_HL = 0;

            foreach (string current_line in System.IO.File.ReadAllLines(@"C:\Users\hanna\OneDrive\Dokumente\LUH\3. Semester\Programmieren von Algorithmen\Hausarbeit\LynxHare.txt"))
            {
                string[] HL_string_array = current_line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                data_YHL[index_HL, 0] = index_HL;
                data_YHL[index_HL, 1] = Double.Parse(HL_string_array[1]);
                data_YHL[index_HL, 2] = Double.Parse(HL_string_array[2]);

                index_HL++;
            }
            Console.WriteLine("Daten importiert.");
            //Console.Write($"{data_YHL[1, 2]} ");
            #endregion
        }

        # region Parameter und Variablen

        // Felder für feste Parameter für nächste Aufgabe 
        //private double r = ;
        //private double k = ;
        //private double a = ;
        //private double b = ;
        //private double c = ;
        //private double d = ;

        //Globabe Variablen
        LineItem data_H;                        //Messpunkte für Hasen
        LineItem data_L;                        //Messpunkte für Luchse
        LineItem data_model_H;                  //Messpunkte im Modell für Hasen
        LineItem data_model_L;                  //Messpunkte im Modell für  Luchse

        LineItem data_model_LH_ph;              //Modell für die Phasenebene
        LineItem data_model_LH_ph_t0;           //Anfangspunkt t0 in der Phasenebene

        LineItem LIX;

        //protected double[] bestIndividuum { get; private set; }
        //protected double[] globalBestFitness { get; private set; }

        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            //fitnessFunc = new CalcFitness(data_YHL);
            int PopGr = (int)numericUpDownPopGr.Value;
            double CO_rate = (double)numericUpDownCO.Value;
            double Mu_rate = (double)numericUpDownMu.Value;
            int GenSize = (int)numericUpDownGen.Value;
            
            #region ZedGraph der Populationsbestände

            GraphPane timeline = zedGraphPopulationsbestände.GraphPane;
            timeline.CurveList.Clear();

            timeline.Title.Text = "Populationsbestände";        // Diagramm-Titel
            timeline.XAxis.Title.Text = "Jahr";                 // x-Achsen-Titel
            timeline.YAxis.Title.Text = "Anzahl (in 1000)";     // y-Achsen-Titel

            //Messpunkte in der Legende
            data_H = timeline.AddCurve("Hasenbestand", null, Color.LightGreen);
            data_L = timeline.AddCurve("Luchsbestand", null, Color.LightGoldenrodYellow);
            data_H.Symbol.Type = SymbolType.XCross;
            data_H.Symbol.Size = 4f;
            data_L.Symbol.Type = SymbolType.XCross;
            data_L.Symbol.Size = 4f;

            //Modelle in die Legende
            data_model_H = timeline.AddCurve("Hasenbestand", null, Color.ForestGreen);
            data_model_L = timeline.AddCurve("Luchsbestand", null, Color.Yellow);

            //Nur Messpunkte ohne Linie
            data_model_H.Line.IsVisible = false;
            data_model_L.Line.IsVisible = false;

            // Messpunkte eintragen
            for (int i = 0; i < 91; i++)
            {
                data_H.AddPoint(data_YHL[i, 0], data_YHL[i, 1]);
                data_L.AddPoint(data_YHL[i, 0], data_YHL[i, 2]);
            }
            
            timeline.AxisChange();
            zedGraphPopulationsbestände.Invalidate();

            #endregion

            #region ZedGraph der Phasenebene

            GraphPane phaselevel = zedGraphPhasenebene.GraphPane;
            phaselevel.CurveList.Clear();

            phaselevel.Title.Text = "Phasenebene";                       // Diagramm-Titel
            phaselevel.XAxis.Title.Text = "Luchse (Anzahl in 1000)";     // x-Achsen-Titel
            phaselevel.YAxis.Title.Text = "Hasen (Anzahl in 1000)";      // y-Achsen-Titel

            //Messpunkte in der Legende
            data_model_LH_ph_t0 = phaselevel.AddCurve("t_null", null, Color.OrangeRed);
            data_model_LH_ph = phaselevel.AddCurve("L(x)/H(x)", null, Color.Blue);

            // Messpunkt anpassen
            data_model_LH_ph_t0.Symbol.Type = SymbolType.XCross;
            data_model_LH_ph_t0.Symbol.Size = 4f;
            data_model_LH_ph_t0.Color = Color.Red;

            //data_model_LH_ph_t0.Line.IsVisible = false;               // nur t0 anzeigen lassen

            Console.WriteLine("Daten eingetragen.");

            #endregion


            //Func<double[], double> CalcFitness = (genome) =>
            //{
            //    // Beispiel: Die Fitness ist die Summe der Werte im Genom
            //    double fitness = genome.Sum();
            //    Console.WriteLine($"Berechne Fitness für: {string.Join(", ", genome)} -> Fitness: {fitness}");
            //    return fitness;
            //};

            GeneticAlgorithm4Double letsgo_GA = new GeneticAlgorithm4Double(PopGr, CO_rate, Mu_rate, GenSize);

            //var letsgo_GA = new GeneticAlgorithm4Double(10, 0.7, 0.1, 100);

            //// Test-Fitness-Funktion 
            //Func<double[], double> CalcFitness = (genome) => {
            //    Console.WriteLine($"Berechne Fitness für Genom: {string.Join(", ", genome)}");
            //    return genome.Sum(); 
            //};

            Console.WriteLine("Starte genetischen Algorithmus");

            //letsgo_GA.SetFitnessFunction(CalcFitness);

            letsgo_GA.SetFitnessFunction((genome) => 
            {
                //Console.WriteLine($"Berechne Fitness für Genom: {string.Join(", ", genome)}");
                double fitness = genome.Sum(); // Beispiel-Berechnung
                //Console.WriteLine($"Fitness: {fitness}");
                return fitness;
            });

            //letsgo_GA.SetFitnessFunction(CalcFitness);
            letsgo_GA.InitializePopulation(6);
            //letsgo_GA.RunGA(returning);

            // Test-Individuum
            //letsgo_GA.bestIndividuum = new double[] { 1.0, 0.5, 0.3, 0.2, 100, 2.5 };

            letsgo_GA.RunGA((ga) => {
                //Console.WriteLine("Generiere Population...");
                //Console.WriteLine($"Beste Fitness: {ga.globalBestFitness}");
            });

            returning(letsgo_GA);
        }

        private void returning(GeneticAlgorithm4Double obj_GA)
        {
            #region Diagrammkomponente Zeit
            GraphPane zeit_diag = zedGraphPopulationsbestände.GraphPane;

            #region Modell für bestes Genom 

            #region Variablendeklarierung

            double[,] monthly_HL = new double[1081, 3];

            // Anfangsbedingungen für das Euler-Verfahren
            //double steps = obj_GA.data_YHL[0, 0];   // Zeit (1845)
            //double H = obj_GA.data_YHL[0, 1];       // Anfangswert der Hasen
            //double L = obj_GA.data_YHL[0, 2];       // Anfangswert der Luchs
            
            double steps = Form1.data_YHL[0, 0];
            double H = Form1.data_YHL[0, 1];
            double L = Form1.data_YHL[0, 2];

            Console.WriteLine($"Startwerte: steps = {steps}, H = {H}, L = {L}");

            // 0. Zeile für monatliche Werte für das Diagramm
            monthly_HL[0, 0] = steps;
            monthly_HL[0, 1] = H;
            monthly_HL[0, 2] = L;

            if (obj_GA.bestIndividuum == null)
            {
                MessageBox.Show("Das beste Individuum konnte nicht berechnet werden.");
                return;
            }

            double a = obj_GA.bestIndividuum[0];
            double b = obj_GA.bestIndividuum[1];
            double c = obj_GA.bestIndividuum[2];
            double d = obj_GA.bestIndividuum[3];
            double k = obj_GA.bestIndividuum[4];
            double r = obj_GA.bestIndividuum[5];

            Console.WriteLine($"Übergebene Parameter: a={a}, b={b}, c={c}, d={d}, k={k}, r={r}");

            //Test-Gene:
            //double a = 1;
            //double b = 1;
            //double c = 30;
            //double d = 1;
            //double k = 70;
            //double r = 1;

            int period = 90;                        // in Jahren
            int fqs_counter = 0;
            int month = 1;                          // Startmonat 

            double delta_t = 0.0001;                // Tage

            #endregion

            #region while-Schleife mit Euler-Verfahren

            while (steps < period)
            {
                H = H + (r * H * (1 - (H / k)) - ((a * L * H) / (c + H))) * delta_t;

                L = L + (((a * L * H * b) / (c + H)) - (d * L)) * delta_t;

                //if (fqs_counter != 0 && fqs_counter % (int)((1 / delta_t) / 12) == 0)
                if (fqs_counter % 1000 == 0)
                {
                    monthly_HL[month, 0] = month;
                    monthly_HL[month, 1] = H;
                    monthly_HL[month, 2] = L;

                    //Console.WriteLine($"Startwerte: steps = {steps}, H = {H}, L = {L}");

                    month++;  
                }

                if (fqs_counter % 1000 == 0) // Alle 1000 Schritte
                {
                    //Console.WriteLine($"Iteration {fqs_counter}: steps = {steps}, H = {H}, L = {L}");
                }

                fqs_counter++;
                steps += delta_t;  
            }

            #endregion

            data_model_H.Clear();
            data_model_L.Clear();

            #region Modell in Diagramm eintragen
            
            for (int i_Modell = 0; i_Modell < monthly_HL.GetLength(0); i_Modell++)                       // Modellpunkte in die Diagramme eintragen
            {
                data_model_H.AddPoint((monthly_HL[i_Modell, 0] / 12), monthly_HL[i_Modell, 1]);          // Modellpunkte für Hase
                data_model_L.AddPoint((monthly_HL[i_Modell, 0] / 12), monthly_HL[i_Modell, 2]);          // Modellpunkte für Luchs
            }

            // Diagramm aktualisieren
            zeit_diag.AxisChange();
            zedGraphPopulationsbestände.Invalidate();

            #endregion

            #region Ausgabe des Genoms und Fitness

            // Ausgabe der Genomwerte und Fitness
            textBox2.Text = Convert.ToString(a);
            textBox3.Text = Convert.ToString(b);
            textBox4.Text = Convert.ToString(c);
            textBox5.Text = Convert.ToString(d);
            textBox6.Text = Convert.ToString(k);
            textBox7.Text = Convert.ToString(r);

            textBox8.Text = Convert.ToString(obj_GA.globalBestFitness);

            #endregion

            // Diagramm aktualisieren
            this.Invalidate();
            Application.DoEvents();

            #endregion
            #endregion

            #region Diagrammkomponente Phasenebene
            GraphPane phasen_diag = zedGraphPhasenebene.GraphPane;

            data_model_LH_ph_t0.Clear();
            data_model_LH_ph.Clear();

            #region Modell in Phasenebene eintragen

            // Startpunkt der Phasenebene (Hase vs. Luchs)
            data_model_LH_ph_t0.AddPoint(monthly_HL[0, 2], monthly_HL[0, 1]);

            // Weitere Punkte für Phasenebene
            for (int i_Modell = 1; i_Modell < monthly_HL.GetLength(0); i_Modell++)
            {
                data_model_LH_ph.AddPoint(monthly_HL[i_Modell, 2], monthly_HL[i_Modell, 1]); 
            }

            phasen_diag.AxisChange();
            zedGraphPhasenebene.Invalidate();

            #endregion

            // Diagramm aktualisieren 
            this.Invalidate();
            Application.DoEvents();

            #endregion
        }

        #region Fitness-Funktion
        public double CalcFitness(double[] gene)
        {
            Console.WriteLine("CalcFitness wird aufgerufen."); // Debug

            double[,] FQS_YHL = new double[91, 3];

            double t = data_YHL[0, 0];              // Zeit t=0
            double H = data_YHL[0, 1];              // Anzahl der Hasen bei t=0
            double L = data_YHL[0, 2];              // Anzahl der Hasen bei t=0

            //Erste Zeile der FQS-Matrix
            FQS_YHL[0, 0] = t;                      // Zeit von Jahr 1845 bis 1935 (t=0 und t=90)
            FQS_YHL[0, 1] = H;                      // Anzahl der Hasen bei t=0
            FQS_YHL[0, 2] = L;                      // Anzahl der Hasen bei t=0

            double a = gene[0];
            double b = gene[1];
            double c = gene[2];
            double d = gene[3];
            double k = gene[4];
            double r = gene[5];

            int period = 90;                        // oder 91?
            double dt = 0.0027;                     // ungefähr ein Tag
            int counter = 0;
            int cnt_years = 1;

            int inext = 0;
            double tnext = data_YHL[inext, 0];

            while (t <= period)
            {
                // DGL für Hasen mit Euler
                H = H + (r * H * (1 - (H / k)) - ((a * L * H) / (c + H))) * dt;

                // DGL für Luchse mit Euler
                L = L + (((a * L * H * b) / (c + H)) - (d * L)) * dt;

                //if (t >= tnext)
                //{
                //    //todo
                //    inext++;
                //    tnext = data_YHL[inext, 0];
                //}

                if (counter != 0 && counter % (int)(1 / dt) == 0)
                {
                    // Schritt speichern
                    FQS_YHL[cnt_years, 0] = cnt_years;
                    FQS_YHL[cnt_years, 1] = H;
                    FQS_YHL[cnt_years, 2] = L;

                    cnt_years++;
                }

                else
                {

                }

                counter++;
                t += dt;

            }

            double error_H = 0;
            double error_L = 0;

            // Berechnung der Fehler für Hasen und Luchse
            for (int i = 0; i <= period; i++)
            {
                //error_H += Math.Pow(data_YHL[i, 1] - FQS_YHL[i, 1], 2);
                error_H = error_H + ((data_YHL[i, 1] - FQS_YHL[i, 1]) * (data_YHL[i, 1] - FQS_YHL[i, 1]));
                //error_L += Math.Pow(data_YHL[i, 2] - FQS_YHL[i, 2], 2);
                error_L = error_L + ((data_YHL[i, 2] - FQS_YHL[i, 2]) * (data_YHL[i, 2] - FQS_YHL[i, 2]));
            }

            // Gesamtfehler und Fitnesswert berechnen
            double error_total = error_H + error_L;
            double fitness_individuum = error_total;

            Console.WriteLine($"Fitness für Genom {string.Join(", ", gene)}: {fitness_individuum}");

            return fitness_individuum;
        }
        #endregion
    }
}
