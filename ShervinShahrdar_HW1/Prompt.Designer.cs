namespace ShervinShahrdar_HW1
{
    partial class Prompt
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Question1 = new System.Windows.Forms.Label();
            this.InitialEmptyHoles = new System.Windows.Forms.TextBox();
            this.SizeOfN = new System.Windows.Forms.ComboBox();
            this.question2 = new System.Windows.Forms.Label();
            this.question3 = new System.Windows.Forms.Label();
            this.FinalPegs = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(145, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 236);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Question1
            // 
            this.Question1.AutoSize = true;
            this.Question1.Location = new System.Drawing.Point(12, 359);
            this.Question1.Name = "Question1";
            this.Question1.Size = new System.Drawing.Size(270, 13);
            this.Question1.TabIndex = 1;
            this.Question1.Text = "Please Specify the initial empty holes comma seperated:";
            // 
            // InitialEmptyHoles
            // 
            this.InitialEmptyHoles.Location = new System.Drawing.Point(288, 356);
            this.InitialEmptyHoles.Name = "InitialEmptyHoles";
            this.InitialEmptyHoles.Size = new System.Drawing.Size(221, 20);
            this.InitialEmptyHoles.TabIndex = 2;
            // 
            // SizeOfN
            // 
            this.SizeOfN.FormattingEnabled = true;
            this.SizeOfN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.SizeOfN.Location = new System.Drawing.Point(288, 329);
            this.SizeOfN.Name = "SizeOfN";
            this.SizeOfN.Size = new System.Drawing.Size(75, 21);
            this.SizeOfN.TabIndex = 3;
            this.SizeOfN.SelectedIndexChanged += new System.EventHandler(this.SizeOfN_SelectedIndexChanged);
            // 
            // question2
            // 
            this.question2.AutoSize = true;
            this.question2.Location = new System.Drawing.Point(142, 332);
            this.question2.Name = "question2";
            this.question2.Size = new System.Drawing.Size(140, 13);
            this.question2.TabIndex = 4;
            this.question2.Text = "Please specify the size of N:";
            // 
            // question3
            // 
            this.question3.AutoSize = true;
            this.question3.Location = new System.Drawing.Point(12, 382);
            this.question3.Name = "question3";
            this.question3.Size = new System.Drawing.Size(279, 13);
            this.question3.TabIndex = 5;
            this.question3.Text = "Please specify the final pegs remaining comma seperated:";
            // 
            // FinalPegs
            // 
            this.FinalPegs.Location = new System.Drawing.Point(288, 382);
            this.FinalPegs.Name = "FinalPegs";
            this.FinalPegs.Size = new System.Drawing.Size(221, 20);
            this.FinalPegs.TabIndex = 6;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(234, 426);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(101, 31);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Prompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 469);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FinalPegs);
            this.Controls.Add(this.question3);
            this.Controls.Add(this.question2);
            this.Controls.Add(this.SizeOfN);
            this.Controls.Add(this.InitialEmptyHoles);
            this.Controls.Add(this.Question1);
            this.Controls.Add(this.textBox1);
            this.Name = "Prompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Question1;
        private System.Windows.Forms.TextBox InitialEmptyHoles;
        private System.Windows.Forms.ComboBox SizeOfN;
        private System.Windows.Forms.Label question2;
        private System.Windows.Forms.Label question3;
        private System.Windows.Forms.TextBox FinalPegs;
        private System.Windows.Forms.Button Save;
    }
}