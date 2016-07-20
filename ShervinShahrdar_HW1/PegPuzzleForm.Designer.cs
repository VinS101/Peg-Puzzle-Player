namespace ShervinShahrdar_HW1
{
    partial class PegPuzzleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.TextBox();
            this.Settings = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(917, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome To Peg Puzzle Player!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(515, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "Play";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.canvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canvas.Location = new System.Drawing.Point(281, 48);
            this.canvas.Multiline = true;
            this.canvas.Name = "canvas";
            this.canvas.ReadOnly = true;
            this.canvas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.canvas.Size = new System.Drawing.Size(379, 332);
            this.canvas.TabIndex = 9;
            this.canvas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.canvas.Enter += new System.EventHandler(this.canvas_Enter);
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(382, 460);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(113, 49);
            this.Settings.TabIndex = 10;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(664, 460);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(121, 49);
            this.Restart.TabIndex = 11;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // PegPuzzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 572);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "PegPuzzleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peg Puzzle Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox canvas;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Restart;




    }
}

