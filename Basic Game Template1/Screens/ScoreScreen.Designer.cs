﻿namespace Basic_Game_Template1
{
    partial class ScoreScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.winLabel = new System.Windows.Forms.Label();
            this.winButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.Location = new System.Drawing.Point(79, 116);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(141, 33);
            this.winLabel.TabIndex = 0;
            this.winLabel.Text = "You Win!!";
            // 
            // winButton
            // 
            this.winButton.Location = new System.Drawing.Point(109, 169);
            this.winButton.Name = "winButton";
            this.winButton.Size = new System.Drawing.Size(75, 23);
            this.winButton.TabIndex = 1;
            this.winButton.Text = "Menu";
            this.winButton.UseVisualStyleBackColor = true;
            this.winButton.Click += new System.EventHandler(this.winButton_Click);
            // 
            // ScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this.winButton);
            this.Controls.Add(this.winLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScoreScreen";
            this.Size = new System.Drawing.Size(294, 264);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ScoreScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Button winButton;
    }
}
