namespace WindowsFormsApp_Hausarbeit
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphPopulationsbestände = new ZedGraph.ZedGraphControl();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.zedGraphPhasenebene = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.numericUpDownPopGr = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCO = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMu = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownGen = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopGr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGen)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphPopulationsbestände
            // 
            this.zedGraphPopulationsbestände.Location = new System.Drawing.Point(895, 14);
            this.zedGraphPopulationsbestände.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphPopulationsbestände.Name = "zedGraphPopulationsbestände";
            this.zedGraphPopulationsbestände.ScrollGrace = 0D;
            this.zedGraphPopulationsbestände.ScrollMaxX = 0D;
            this.zedGraphPopulationsbestände.ScrollMaxY = 0D;
            this.zedGraphPopulationsbestände.ScrollMaxY2 = 0D;
            this.zedGraphPopulationsbestände.ScrollMinX = 0D;
            this.zedGraphPopulationsbestände.ScrollMinY = 0D;
            this.zedGraphPopulationsbestände.ScrollMinY2 = 0D;
            this.zedGraphPopulationsbestände.Size = new System.Drawing.Size(541, 422);
            this.zedGraphPopulationsbestände.TabIndex = 0;
            // 
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(13, 13);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(128, 48);
            this.btnSimulate.TabIndex = 1;
            this.btnSimulate.Text = "Simulation";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.button1_Click);
            // 
            // zedGraphPhasenebene
            // 
            this.zedGraphPhasenebene.Location = new System.Drawing.Point(346, 14);
            this.zedGraphPhasenebene.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphPhasenebene.Name = "zedGraphPhasenebene";
            this.zedGraphPhasenebene.ScrollGrace = 0D;
            this.zedGraphPhasenebene.ScrollMaxX = 0D;
            this.zedGraphPhasenebene.ScrollMaxY = 0D;
            this.zedGraphPhasenebene.ScrollMaxY2 = 0D;
            this.zedGraphPhasenebene.ScrollMinX = 0D;
            this.zedGraphPhasenebene.ScrollMinY = 0D;
            this.zedGraphPhasenebene.ScrollMinY2 = 0D;
            this.zedGraphPhasenebene.Size = new System.Drawing.Size(541, 422);
            this.zedGraphPhasenebene.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Poplationsgröße:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jagdrate a:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(148, 191);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Umrechnungsfaktor b:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(186, 226);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Trägerkapazität k:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(148, 318);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 26);
            this.textBox4.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sterberate Luchse d:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(186, 289);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 26);
            this.textBox5.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Michaelis-Konstante c:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(186, 257);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 26);
            this.textBox6.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Reproduktionsrate Hase r:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(215, 347);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 26);
            this.textBox7.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "FSQ:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(65, 374);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 26);
            this.textBox8.TabIndex = 18;
            // 
            // numericUpDownPopGr
            // 
            this.numericUpDownPopGr.Location = new System.Drawing.Point(148, 62);
            this.numericUpDownPopGr.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPopGr.Name = "numericUpDownPopGr";
            this.numericUpDownPopGr.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownPopGr.TabIndex = 19;
            this.numericUpDownPopGr.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDownCO
            // 
            this.numericUpDownCO.DecimalPlaces = 2;
            this.numericUpDownCO.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownCO.Location = new System.Drawing.Point(148, 126);
            this.numericUpDownCO.Name = "numericUpDownCO";
            this.numericUpDownCO.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownCO.TabIndex = 20;
            this.numericUpDownCO.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // numericUpDownMu
            // 
            this.numericUpDownMu.DecimalPlaces = 2;
            this.numericUpDownMu.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownMu.Location = new System.Drawing.Point(148, 158);
            this.numericUpDownMu.Name = "numericUpDownMu";
            this.numericUpDownMu.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownMu.TabIndex = 21;
            this.numericUpDownMu.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Crossover-Rate:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Mutationsrate:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Generationen:";
            // 
            // numericUpDownGen
            // 
            this.numericUpDownGen.Location = new System.Drawing.Point(148, 94);
            this.numericUpDownGen.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownGen.Name = "numericUpDownGen";
            this.numericUpDownGen.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownGen.TabIndex = 25;
            this.numericUpDownGen.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 450);
            this.Controls.Add(this.numericUpDownGen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDownMu);
            this.Controls.Add(this.numericUpDownCO);
            this.Controls.Add(this.numericUpDownPopGr);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphPhasenebene);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.zedGraphPopulationsbestände);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopGr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphPopulationsbestände;
        private System.Windows.Forms.Button btnSimulate;
        private ZedGraph.ZedGraphControl zedGraphPhasenebene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.NumericUpDown numericUpDownPopGr;
        private System.Windows.Forms.NumericUpDown numericUpDownCO;
        private System.Windows.Forms.NumericUpDown numericUpDownMu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownGen;
    }
}

