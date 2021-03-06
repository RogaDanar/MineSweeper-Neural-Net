﻿namespace MineSweeper.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFast = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.pnlSettings = new MineSweeper.UI.Controls.Settings();
            this.statsGeneration = new MineSweeper.UI.Controls.Stats();
            this.pgMain = new MineSweeper.UI.Controls.Playground();
            this.graphPopulation = new MineSweeper.UI.Controls.Graph();
            ((System.ComponentModel.ISupportInitialize)(this.pgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPopulation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFast
            // 
            this.btnFast.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFast.ForeColor = System.Drawing.Color.Black;
            this.btnFast.Location = new System.Drawing.Point(668, 44);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(124, 25);
            this.btnFast.TabIndex = 15;
            this.btnFast.Text = "Fast";
            this.btnFast.UseVisualStyleBackColor = false;
            this.btnFast.Click += new System.EventHandler(this.btnFastClick);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(668, 75);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 25);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "(Re)set values";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnResetClick);
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartStop.ForeColor = System.Drawing.Color.Black;
            this.btnStartStop.Location = new System.Drawing.Point(668, 13);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(124, 25);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStopClick);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(122)))), ((int)(((byte)(174)))));
            this.pnlSettings.Location = new System.Drawing.Point(665, 106);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(130, 427);
            this.pnlSettings.TabIndex = 28;
            // 
            // statsGeneration
            // 
            this.statsGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statsGeneration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(122)))), ((int)(((byte)(174)))));
            this.statsGeneration.Location = new System.Drawing.Point(665, 561);
            this.statsGeneration.Name = "statsGeneration";
            this.statsGeneration.Size = new System.Drawing.Size(130, 200);
            this.statsGeneration.TabIndex = 29;
            // 
            // pgMain
            // 
            this.pgMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pgMain.Location = new System.Drawing.Point(12, 13);
            this.pgMain.Name = "pgMain";
            this.pgMain.Size = new System.Drawing.Size(640, 520);
            this.pgMain.TabIndex = 0;
            this.pgMain.TabStop = false;
            // 
            // graphPopulation
            // 
            this.graphPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.graphPopulation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.graphPopulation.Location = new System.Drawing.Point(12, 561);
            this.graphPopulation.Name = "graphPopulation";
            this.graphPopulation.Size = new System.Drawing.Size(640, 200);
            this.graphPopulation.TabIndex = 5;
            this.graphPopulation.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(795, 778);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.statsGeneration);
            this.Controls.Add(this.pgMain);
            this.Controls.Add(this.graphPopulation);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFast);
            this.Font = new System.Drawing.Font("DengXian", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPopulation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MineSweeper.UI.Controls.Settings pnlSettings;
        private MineSweeper.UI.Controls.Playground pgMain;
        private MineSweeper.UI.Controls.Graph graphPopulation;
        private MineSweeper.UI.Controls.Stats statsGeneration;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnReset;
    }
}

