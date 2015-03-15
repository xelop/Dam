namespace Dam
{
    partial class DamAttributeSelection
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
            this.AttrbutesName = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AttributesSet = new System.Windows.Forms.Panel();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.FlowRateTextBox = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.KmOption = new System.Windows.Forms.RadioButton();
            this.MetersOption = new System.Windows.Forms.RadioButton();
            this.AttrbutesName.SuspendLayout();
            this.AttributesSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // AttrbutesName
            // 
            this.AttrbutesName.Controls.Add(this.label5);
            this.AttrbutesName.Controls.Add(this.label4);
            this.AttrbutesName.Controls.Add(this.label3);
            this.AttrbutesName.Controls.Add(this.label2);
            this.AttrbutesName.Controls.Add(this.label1);
            this.AttrbutesName.Dock = System.Windows.Forms.DockStyle.Left;
            this.AttrbutesName.Location = new System.Drawing.Point(0, 0);
            this.AttrbutesName.Name = "AttrbutesName";
            this.AttrbutesName.Size = new System.Drawing.Size(277, 378);
            this.AttrbutesName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tank";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "- Heigth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "- Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "- Length";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Water Flow Rate";
            // 
            // AttributesSet
            // 
            this.AttributesSet.Controls.Add(this.MetersOption);
            this.AttributesSet.Controls.Add(this.KmOption);
            this.AttributesSet.Controls.Add(this.Start);
            this.AttributesSet.Controls.Add(this.FlowRateTextBox);
            this.AttributesSet.Controls.Add(this.LengthTextBox);
            this.AttributesSet.Controls.Add(this.WidthTextBox);
            this.AttributesSet.Controls.Add(this.HeightTextBox);
            this.AttributesSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.AttributesSet.Location = new System.Drawing.Point(283, 0);
            this.AttributesSet.Name = "AttributesSet";
            this.AttributesSet.Size = new System.Drawing.Size(248, 378);
            this.AttributesSet.TabIndex = 1;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(76, 94);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightTextBox.TabIndex = 0;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(76, 144);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthTextBox.TabIndex = 1;
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(76, 191);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.LengthTextBox.TabIndex = 2;
            // 
            // FlowRateTextBox
            // 
            this.FlowRateTextBox.Location = new System.Drawing.Point(76, 270);
            this.FlowRateTextBox.Name = "FlowRateTextBox";
            this.FlowRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.FlowRateTextBox.TabIndex = 3;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(161, 343);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // KmOption
            // 
            this.KmOption.AutoSize = true;
            this.KmOption.Location = new System.Drawing.Point(98, 10);
            this.KmOption.Name = "KmOption";
            this.KmOption.Size = new System.Drawing.Size(73, 17);
            this.KmOption.TabIndex = 5;
            this.KmOption.TabStop = true;
            this.KmOption.Text = "Kilometers";
            this.KmOption.UseVisualStyleBackColor = true;
            this.KmOption.CheckedChanged += new System.EventHandler(this.KmOption_CheckedChanged);
            // 
            // MetersOption
            // 
            this.MetersOption.AutoSize = true;
            this.MetersOption.Location = new System.Drawing.Point(98, 34);
            this.MetersOption.Name = "MetersOption";
            this.MetersOption.Size = new System.Drawing.Size(57, 17);
            this.MetersOption.TabIndex = 6;
            this.MetersOption.TabStop = true;
            this.MetersOption.Text = "Meters";
            this.MetersOption.UseVisualStyleBackColor = true;
            // 
            // DamAttributeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 378);
            this.Controls.Add(this.AttributesSet);
            this.Controls.Add(this.AttrbutesName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DamAttributeSelection";
            this.Text = "DamAttributeSelection";
            this.AttrbutesName.ResumeLayout(false);
            this.AttrbutesName.PerformLayout();
            this.AttributesSet.ResumeLayout(false);
            this.AttributesSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AttrbutesName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel AttributesSet;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.RadioButton MetersOption;
        private System.Windows.Forms.RadioButton KmOption;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox FlowRateTextBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
    }
}