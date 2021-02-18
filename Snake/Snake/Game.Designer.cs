
namespace Snake
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.cube = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cube)).BeginInit();
            this.SuspendLayout();
            // 
            // cube
            // 
            this.cube.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cube.Location = new System.Drawing.Point(0, 0);
            this.cube.Name = "cube";
            this.cube.Size = new System.Drawing.Size(40, 40);
            this.cube.TabIndex = 0;
            this.cube.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cube);
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.cube)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cube;
        private System.Windows.Forms.Timer timer;
    }
}