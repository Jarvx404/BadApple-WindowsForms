namespace BadApple
{
    partial class BadAppleForm
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
            this.aniTimer = new System.Windows.Forms.Timer(this.components);
            this.enBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.enBox)).BeginInit();
            this.SuspendLayout();
            // 
            // aniTimer
            // 
            this.aniTimer.Tick += new System.EventHandler(this.aniTick);
            // 
            // enBox
            // 
            this.enBox.BackgroundImage = global::BadApple.Properties.Resources.bad_code_bad;
            this.enBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enBox.Location = new System.Drawing.Point(12, 28);
            this.enBox.Name = "enBox";
            this.enBox.Size = new System.Drawing.Size(411, 259);
            this.enBox.TabIndex = 0;
            this.enBox.TabStop = false;
            // 
            // BadAppleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 316);
            this.Controls.Add(this.enBox);
            this.Name = "BadAppleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BadApple";
            ((System.ComponentModel.ISupportInitialize)(this.enBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer aniTimer;
        private System.Windows.Forms.PictureBox enBox;
    }
}

