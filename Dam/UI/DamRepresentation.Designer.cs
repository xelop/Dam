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
            this.screen = new System.Windows.Forms.Panel();
            this.WaterRiver = new System.Windows.Forms.Panel();
            this.WaterContainer = new System.Windows.Forms.Panel();
            this.screen.SuspendLayout();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.Transparent;
            this.screen.BackgroundImage = global::Dam.Properties.Resources.Dam;
            this.screen.Controls.Add(this.WaterRiver);
            this.screen.Controls.Add(this.WaterContainer);
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.ForeColor = System.Drawing.Color.Transparent;
            this.screen.Location = new System.Drawing.Point(0, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(859, 537);
            this.screen.TabIndex = 0;
            this.screen.Click += new System.EventHandler(this.screen_Click);
            // 
            // WaterRiver
            // 
            this.WaterRiver.BackColor = System.Drawing.Color.Transparent;
            this.WaterRiver.Location = new System.Drawing.Point(696, 318);
            this.WaterRiver.Name = "WaterRiver";
            this.WaterRiver.Size = new System.Drawing.Size(163, 115);
            this.WaterRiver.TabIndex = 1;
            this.WaterRiver.Paint += new System.Windows.Forms.PaintEventHandler(this.WaterRiver_Paint);
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
            // DamRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dam.Properties.Resources.Dam;
            this.ClientSize = new System.Drawing.Size(859, 537);
            this.Controls.Add(this.screen);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "DamRepresentation";
            this.Text = "DamRepresentation";
            this.screen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Panel WaterRiver;
        private System.Windows.Forms.Panel WaterContainer;
    }
}