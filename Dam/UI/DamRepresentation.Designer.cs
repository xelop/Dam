﻿namespace Dam.UI
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
            this._lbl_TankHeight = new System.Windows.Forms.Label();
            this._lbl_TankVolume = new System.Windows.Forms.Label();
            this._cmb_Turbines = new System.Windows.Forms.ComboBox();
            this._btn_AddTurbine = new System.Windows.Forms.Button();
            this._lbl_TurbineStatus = new System.Windows.Forms.Label();
            this._btn_OnorOff = new System.Windows.Forms.Button();
            this._lbl_SingleEnergy = new System.Windows.Forms.Label();
            this._lbl_TotalEnergy = new System.Windows.Forms.Label();
            this._txt_CurrentFlow = new System.Windows.Forms.TextBox();
            this._lbl_CurrentFlow = new System.Windows.Forms.Label();
            this._btn_ChangeFlow = new System.Windows.Forms.Button();
            this._lbl_riverHeight = new System.Windows.Forms.Label();
            this._txt_Seconds = new System.Windows.Forms.TextBox();
            this._lbl_seconds = new System.Windows.Forms.Label();
            this._btn_seconds = new System.Windows.Forms.Button();
            this._lbl_Volume = new System.Windows.Forms.Label();
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
            // _lbl_TankHeight
            // 
            this._lbl_TankHeight.AutoSize = true;
            this._lbl_TankHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_TankHeight.ForeColor = System.Drawing.Color.Black;
            this._lbl_TankHeight.Location = new System.Drawing.Point(110, 273);
            this._lbl_TankHeight.Name = "_lbl_TankHeight";
            this._lbl_TankHeight.Size = new System.Drawing.Size(0, 16);
            this._lbl_TankHeight.TabIndex = 3;
            // 
            // _lbl_TankVolume
            // 
            this._lbl_TankVolume.AutoSize = true;
            this._lbl_TankVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_TankVolume.ForeColor = System.Drawing.Color.Black;
            this._lbl_TankVolume.Location = new System.Drawing.Point(41, 119);
            this._lbl_TankVolume.Name = "_lbl_TankVolume";
            this._lbl_TankVolume.Size = new System.Drawing.Size(0, 20);
            this._lbl_TankVolume.TabIndex = 7;
            // 
            // _cmb_Turbines
            // 
            this._cmb_Turbines.FormattingEnabled = true;
            this._cmb_Turbines.Location = new System.Drawing.Point(358, 139);
            this._cmb_Turbines.Name = "_cmb_Turbines";
            this._cmb_Turbines.Size = new System.Drawing.Size(121, 21);
            this._cmb_Turbines.TabIndex = 8;
            this._cmb_Turbines.SelectionChangeCommitted += new System.EventHandler(this._cmb_Turbines_SelectionChangeCommitted);
            // 
            // _btn_AddTurbine
            // 
            this._btn_AddTurbine.ForeColor = System.Drawing.Color.Black;
            this._btn_AddTurbine.Location = new System.Drawing.Point(382, 170);
            this._btn_AddTurbine.Name = "_btn_AddTurbine";
            this._btn_AddTurbine.Size = new System.Drawing.Size(75, 23);
            this._btn_AddTurbine.TabIndex = 9;
            this._btn_AddTurbine.Text = "Add Turbine";
            this._btn_AddTurbine.UseVisualStyleBackColor = true;
            this._btn_AddTurbine.Click += new System.EventHandler(this._btn_AddTrubine_Click);
            // 
            // _lbl_TurbineStatus
            // 
            this._lbl_TurbineStatus.AutoSize = true;
            this._lbl_TurbineStatus.BackColor = System.Drawing.Color.Transparent;
            this._lbl_TurbineStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_TurbineStatus.ForeColor = System.Drawing.Color.Black;
            this._lbl_TurbineStatus.Location = new System.Drawing.Point(282, 34);
            this._lbl_TurbineStatus.Name = "_lbl_TurbineStatus";
            this._lbl_TurbineStatus.Size = new System.Drawing.Size(165, 16);
            this._lbl_TurbineStatus.TabIndex = 10;
            this._lbl_TurbineStatus.Text = "Current Turbine Status:";
            // 
            // _btn_OnorOff
            // 
            this._btn_OnorOff.ForeColor = System.Drawing.Color.Black;
            this._btn_OnorOff.Location = new System.Drawing.Point(535, 31);
            this._btn_OnorOff.Name = "_btn_OnorOff";
            this._btn_OnorOff.Size = new System.Drawing.Size(75, 23);
            this._btn_OnorOff.TabIndex = 11;
            this._btn_OnorOff.Text = "Turn On/Off";
            this._btn_OnorOff.UseVisualStyleBackColor = true;
            this._btn_OnorOff.Click += new System.EventHandler(this._btn_OnorOff_Click);
            // 
            // _lbl_SingleEnergy
            // 
            this._lbl_SingleEnergy.AutoSize = true;
            this._lbl_SingleEnergy.BackColor = System.Drawing.Color.Transparent;
            this._lbl_SingleEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_SingleEnergy.ForeColor = System.Drawing.Color.Black;
            this._lbl_SingleEnergy.Location = new System.Drawing.Point(285, 67);
            this._lbl_SingleEnergy.Name = "_lbl_SingleEnergy";
            this._lbl_SingleEnergy.Size = new System.Drawing.Size(208, 16);
            this._lbl_SingleEnergy.TabIndex = 12;
            this._lbl_SingleEnergy.Text = "Selected Turbine\'s Energy: 0";
            // 
            // _lbl_TotalEnergy
            // 
            this._lbl_TotalEnergy.AutoSize = true;
            this._lbl_TotalEnergy.BackColor = System.Drawing.Color.Transparent;
            this._lbl_TotalEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_TotalEnergy.ForeColor = System.Drawing.Color.Black;
            this._lbl_TotalEnergy.Location = new System.Drawing.Point(285, 98);
            this._lbl_TotalEnergy.Name = "_lbl_TotalEnergy";
            this._lbl_TotalEnergy.Size = new System.Drawing.Size(191, 16);
            this._lbl_TotalEnergy.TabIndex = 13;
            this._lbl_TotalEnergy.Text = "Total Energy Production: 0";
            // 
            // _txt_CurrentFlow
            // 
            this._txt_CurrentFlow.Location = new System.Drawing.Point(709, 63);
            this._txt_CurrentFlow.Name = "_txt_CurrentFlow";
            this._txt_CurrentFlow.Size = new System.Drawing.Size(100, 20);
            this._txt_CurrentFlow.TabIndex = 14;
            this._txt_CurrentFlow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_CurrentFlow_KeyPress);

            // 
            // _lbl_CurrentFlow
            // 
            this._lbl_CurrentFlow.AutoSize = true;
            this._lbl_CurrentFlow.BackColor = System.Drawing.Color.Transparent;
            this._lbl_CurrentFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_CurrentFlow.ForeColor = System.Drawing.Color.Black;
            this._lbl_CurrentFlow.Location = new System.Drawing.Point(693, 31);
            this._lbl_CurrentFlow.Name = "_lbl_CurrentFlow";
            this._lbl_CurrentFlow.Size = new System.Drawing.Size(126, 16);
            this._lbl_CurrentFlow.TabIndex = 15;
            this._lbl_CurrentFlow.Text = "Current FlowRate";
            // 
            // _btn_ChangeFlow
            // 
            this._btn_ChangeFlow.ForeColor = System.Drawing.Color.Black;
            this._btn_ChangeFlow.Location = new System.Drawing.Point(719, 98);
            this._btn_ChangeFlow.Name = "_btn_ChangeFlow";
            this._btn_ChangeFlow.Size = new System.Drawing.Size(75, 23);
            this._btn_ChangeFlow.TabIndex = 16;
            this._btn_ChangeFlow.Text = "Change";
            this._btn_ChangeFlow.UseVisualStyleBackColor = true;
            this._btn_ChangeFlow.Click += new System.EventHandler(this._btn_ChangeFlow_Click);
            // 
            // _lbl_riverHeight
            // 
            this._lbl_riverHeight.AutoSize = true;
            this._lbl_riverHeight.BackColor = System.Drawing.SystemColors.Control;
            this._lbl_riverHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_riverHeight.ForeColor = System.Drawing.Color.Black;
            this._lbl_riverHeight.Location = new System.Drawing.Point(602, 366);
            this._lbl_riverHeight.Name = "_lbl_riverHeight";
            this._lbl_riverHeight.Size = new System.Drawing.Size(0, 20);
            this._lbl_riverHeight.TabIndex = 17;
            // 
            // _txt_Seconds
            // 
            this._txt_Seconds.Location = new System.Drawing.Point(709, 166);
            this._txt_Seconds.Name = "_txt_Seconds";
            this._txt_Seconds.Size = new System.Drawing.Size(100, 20);
            this._txt_Seconds.TabIndex = 18;
            this._txt_Seconds.Text = "1";
            this._txt_Seconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txt_Seconds_KeyPress);
            // 
            // _lbl_seconds
            // 
            this._lbl_seconds.AutoSize = true;
            this._lbl_seconds.BackColor = System.Drawing.Color.Transparent;
            this._lbl_seconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_seconds.ForeColor = System.Drawing.Color.Black;
            this._lbl_seconds.Location = new System.Drawing.Point(693, 144);
            this._lbl_seconds.Name = "_lbl_seconds";
            this._lbl_seconds.Size = new System.Drawing.Size(131, 16);
            this._lbl_seconds.TabIndex = 19;
            this._lbl_seconds.Text = "Seconds Relation";
            // 
            // _btn_seconds
            // 
            this._btn_seconds.ForeColor = System.Drawing.Color.Black;
            this._btn_seconds.Location = new System.Drawing.Point(719, 192);
            this._btn_seconds.Name = "_btn_seconds";
            this._btn_seconds.Size = new System.Drawing.Size(75, 23);
            this._btn_seconds.TabIndex = 20;
            this._btn_seconds.Text = "Change";
            this._btn_seconds.UseVisualStyleBackColor = true;
            this._btn_seconds.Click += new System.EventHandler(this._btn_seconds_Click);
            // 
            // _lbl_Volume
            // 
            this._lbl_Volume.AutoSize = true;
            this._lbl_Volume.BackColor = System.Drawing.Color.Transparent;
            this._lbl_Volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_Volume.ForeColor = System.Drawing.Color.Black;
            this._lbl_Volume.Location = new System.Drawing.Point(12, 31);
            this._lbl_Volume.Name = "_lbl_Volume";
            this._lbl_Volume.Size = new System.Drawing.Size(0, 16);
            this._lbl_Volume.TabIndex = 21;
            // 
            // DamRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dam.Properties.Resources.Dam2;
            this.ClientSize = new System.Drawing.Size(859, 537);
            this.Controls.Add(this._lbl_Volume);
            this.Controls.Add(this._btn_seconds);
            this.Controls.Add(this._lbl_seconds);
            this.Controls.Add(this._txt_Seconds);
            this.Controls.Add(this._lbl_riverHeight);
            this.Controls.Add(this._lbl_TankVolume);
            this.Controls.Add(this._btn_ChangeFlow);
            this.Controls.Add(this._lbl_CurrentFlow);
            this.Controls.Add(this._txt_CurrentFlow);
            this.Controls.Add(this._lbl_TotalEnergy);
            this.Controls.Add(this._lbl_SingleEnergy);
            this.Controls.Add(this._btn_OnorOff);
            this.Controls.Add(this._lbl_TurbineStatus);
            this.Controls.Add(this._btn_AddTurbine);
            this.Controls.Add(this._cmb_Turbines);
            this.Controls.Add(this._lbl_TankHeight);
            this.Controls.Add(this.RiverWater);
            this.Controls.Add(this.WaterContainer);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "DamRepresentation";
            this.Text = "DamRepresentation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DamRepresentation_FormClosing);
            this.Load += new System.EventHandler(this.DamRepresentation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RiverWater)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RiverWater;
        private System.Windows.Forms.Label _lbl_TankHeight;
        private System.Windows.Forms.Label _lbl_TankVolume;
        private System.Windows.Forms.ComboBox _cmb_Turbines;
        private System.Windows.Forms.Button _btn_AddTurbine;
        private System.Windows.Forms.Label _lbl_TurbineStatus;
        private System.Windows.Forms.Button _btn_OnorOff;
        private System.Windows.Forms.Label _lbl_SingleEnergy;
        private System.Windows.Forms.Label _lbl_TotalEnergy;
        private System.Windows.Forms.TextBox _txt_CurrentFlow;
        private System.Windows.Forms.Label _lbl_CurrentFlow;
        private System.Windows.Forms.Button _btn_ChangeFlow;
        public System.Windows.Forms.Panel WaterContainer;
        private System.Windows.Forms.Label _lbl_riverHeight;
        private System.Windows.Forms.TextBox _txt_Seconds;
        private System.Windows.Forms.Label _lbl_seconds;
        private System.Windows.Forms.Button _btn_seconds;
        private System.Windows.Forms.Label _lbl_Volume;

    }
}