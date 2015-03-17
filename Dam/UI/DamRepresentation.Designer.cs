namespace Dam
{
    partial class DamRepresentation
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
            this.WaterContainer = new System.Windows.Forms.Panel();
            this.RiverWater = new System.Windows.Forms.PictureBox();
            this.TankHeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RiverHeight = new System.Windows.Forms.Label();
            this.TankVolume = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RiverWater)).BeginInit();
            this.SuspendLayout();
            // 
            // WaterContainer
            // 
            this.WaterContainer.BackColor = System.Drawing.Color.Transparent;
            this.WaterContainer.Location = new System.Drawing.Point(0, 166);
            this.WaterContainer.Name = "WaterContainer";
            this.WaterContainer.Size = new System.Drawing.Size(104, 247);
            this.WaterContainer.TabIndex = 0;
            this.WaterContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.WaterContainer_Paint);
            // 
            // RiverWater
            // 
            this.RiverWater.BackColor = System.Drawing.Color.Transparent;
            this.RiverWater.Location = new System.Drawing.Point(696, 314);
            this.RiverWater.Name = "RiverWater";
            this.RiverWater.Size = new System.Drawing.Size(164, 112);
            this.RiverWater.TabIndex = 2;
            this.RiverWater.TabStop = false;
            this.RiverWater.Paint += new System.Windows.Forms.PaintEventHandler(this.RiverWater_Paint);
            // 
            // TankHeight
            // 
            this.TankHeight.AutoSize = true;
            this.TankHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TankHeight.ForeColor = System.Drawing.Color.Black;
            this.TankHeight.Location = new System.Drawing.Point(110, 273);
            this.TankHeight.Name = "TankHeight";
            this.TankHeight.Size = new System.Drawing.Size(0, 16);
            this.TankHeight.TabIndex = 3;
            this.TankHeight.Click += new System.EventHandler(this.label1_Click);
            this.TankHeight.Paint += new System.Windows.Forms.PaintEventHandler(this.TankHeight_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(429, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 18);
            this.label2.TabIndex = 5;
            // 
            // RiverHeight
            // 
            this.RiverHeight.AutoSize = true;
            this.RiverHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RiverHeight.ForeColor = System.Drawing.Color.Black;
            this.RiverHeight.Location = new System.Drawing.Point(638, 400);
            this.RiverHeight.Name = "RiverHeight";
            this.RiverHeight.Size = new System.Drawing.Size(0, 18);
            this.RiverHeight.TabIndex = 6;
            // 
            // TankVolume
            // 
            this.TankVolume.AutoSize = true;
            this.TankVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TankVolume.ForeColor = System.Drawing.Color.Black;
            this.TankVolume.Location = new System.Drawing.Point(22, 124);
            this.TankVolume.Name = "TankVolume";
            this.TankVolume.Size = new System.Drawing.Size(0, 20);
            this.TankVolume.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(422, 135);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(446, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add Turbine";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(356, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Current Turbine Status:";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(609, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Turn On/Off";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DamRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dam.Properties.Resources.Dam;
            this.ClientSize = new System.Drawing.Size(859, 537);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TankVolume);
            this.Controls.Add(this.RiverHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TankHeight);
            this.Controls.Add(this.RiverWater);
            this.Controls.Add(this.WaterContainer);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "DamRepresentation";
            this.Text = "DamRepresentation";
            this.Click += new System.EventHandler(this.DamRepresentation_Click);
            ((System.ComponentModel.ISupportInitialize)(this.RiverWater)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel WaterContainer;
        private System.Windows.Forms.PictureBox RiverWater;
        private System.Windows.Forms.Label TankHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RiverHeight;
        private System.Windows.Forms.Label TankVolume;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;

    }
}