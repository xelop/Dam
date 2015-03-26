namespace Dam.UI
{
    partial class AddTurbine
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._btn_AddTurbine = new System.Windows.Forms.Button();
            this._txt_MinEnergy = new System.Windows.Forms.TextBox();
            this._txt_MinPressure = new System.Windows.Forms.TextBox();
            this._txt_MinFlowRate = new System.Windows.Forms.TextBox();
            this._txt_MaxEnergy = new System.Windows.Forms.TextBox();
            this._txt_MaxPressure = new System.Windows.Forms.TextBox();
            this._txt_MaxFlowRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._txt_NumberofTurbines = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 427);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Energy Generation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pressure";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flow Rate";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._txt_NumberofTurbines);
            this.panel2.Controls.Add(this._btn_AddTurbine);
            this.panel2.Controls.Add(this._txt_MinEnergy);
            this.panel2.Controls.Add(this._txt_MinPressure);
            this.panel2.Controls.Add(this._txt_MinFlowRate);
            this.panel2.Controls.Add(this._txt_MaxEnergy);
            this.panel2.Controls.Add(this._txt_MaxPressure);
            this.panel2.Controls.Add(this._txt_MaxFlowRate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(256, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 427);
            this.panel2.TabIndex = 1;
            // 
            // _btn_AddTurbine
            // 
            this._btn_AddTurbine.Location = new System.Drawing.Point(171, 370);
            this._btn_AddTurbine.Name = "_btn_AddTurbine";
            this._btn_AddTurbine.Size = new System.Drawing.Size(75, 23);
            this._btn_AddTurbine.TabIndex = 11;
            this._btn_AddTurbine.Text = "Add";
            this._btn_AddTurbine.UseVisualStyleBackColor = true;
            this._btn_AddTurbine.Click += new System.EventHandler(this._btn_AddTurbine_Click);
            // 
            // _txt_MinEnergy
            // 
            this._txt_MinEnergy.Location = new System.Drawing.Point(229, 237);
            this._txt_MinEnergy.Name = "_txt_MinEnergy";
            this._txt_MinEnergy.Size = new System.Drawing.Size(130, 20);
            this._txt_MinEnergy.TabIndex = 10;
            // 
            // _txt_MinPressure
            // 
            this._txt_MinPressure.Location = new System.Drawing.Point(229, 154);
            this._txt_MinPressure.Name = "_txt_MinPressure";
            this._txt_MinPressure.Size = new System.Drawing.Size(130, 20);
            this._txt_MinPressure.TabIndex = 9;
            // 
            // _txt_MinFlowRate
            // 
            this._txt_MinFlowRate.Location = new System.Drawing.Point(229, 78);
            this._txt_MinFlowRate.Name = "_txt_MinFlowRate";
            this._txt_MinFlowRate.Size = new System.Drawing.Size(130, 20);
            this._txt_MinFlowRate.TabIndex = 8;
            // 
            // _txt_MaxEnergy
            // 
            this._txt_MaxEnergy.Location = new System.Drawing.Point(48, 237);
            this._txt_MaxEnergy.Name = "_txt_MaxEnergy";
            this._txt_MaxEnergy.Size = new System.Drawing.Size(130, 20);
            this._txt_MaxEnergy.TabIndex = 7;
            // 
            // _txt_MaxPressure
            // 
            this._txt_MaxPressure.Location = new System.Drawing.Point(48, 154);
            this._txt_MaxPressure.Name = "_txt_MaxPressure";
            this._txt_MaxPressure.Size = new System.Drawing.Size(130, 20);
            this._txt_MaxPressure.TabIndex = 6;
            // 
            // _txt_MaxFlowRate
            // 
            this._txt_MaxFlowRate.Location = new System.Drawing.Point(48, 78);
            this._txt_MaxFlowRate.Name = "_txt_MaxFlowRate";
            this._txt_MaxFlowRate.Size = new System.Drawing.Size(130, 20);
            this._txt_MaxFlowRate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(275, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "MIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "MAX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Number of turbines";
            // 
            // _txt_NumberofTurbines
            // 
            this._txt_NumberofTurbines.Location = new System.Drawing.Point(48, 307);
            this._txt_NumberofTurbines.Name = "_txt_NumberofTurbines";
            this._txt_NumberofTurbines.Size = new System.Drawing.Size(130, 20);
            this._txt_NumberofTurbines.TabIndex = 12;
            // 
            // AddTurbine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AddTurbine";
            this.Text = "Add New Turbine";
            this.Load += new System.EventHandler(this.AddTurbine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btn_AddTurbine;
        private System.Windows.Forms.TextBox _txt_MinEnergy;
        private System.Windows.Forms.TextBox _txt_MinPressure;
        private System.Windows.Forms.TextBox _txt_MinFlowRate;
        private System.Windows.Forms.TextBox _txt_MaxEnergy;
        private System.Windows.Forms.TextBox _txt_MaxPressure;
        private System.Windows.Forms.TextBox _txt_MaxFlowRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _txt_NumberofTurbines;
    }
}