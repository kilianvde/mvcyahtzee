namespace Yatzhee
{
    partial class TeerlingView
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TeerlingBox = new System.Windows.Forms.PictureBox();
            this.btnWerpTeerling = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TeerlingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TeerlingBox
            // 
            this.TeerlingBox.BackColor = System.Drawing.Color.White;
            this.TeerlingBox.Image = global::Yatzhee.Properties.Resources.dice1;
            this.TeerlingBox.Location = new System.Drawing.Point(16, 0);
            this.TeerlingBox.Name = "TeerlingBox";
            this.TeerlingBox.Size = new System.Drawing.Size(97, 127);
            this.TeerlingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TeerlingBox.TabIndex = 1;
            this.TeerlingBox.TabStop = false;
            this.TeerlingBox.Click += new System.EventHandler(this.TeerlingBox_Click);
            // 
            // btnWerpTeerling
            // 
            this.btnWerpTeerling.Location = new System.Drawing.Point(26, 133);
            this.btnWerpTeerling.Name = "btnWerpTeerling";
            this.btnWerpTeerling.Size = new System.Drawing.Size(75, 23);
            this.btnWerpTeerling.TabIndex = 2;
            this.btnWerpTeerling.Text = "Werp";
            this.btnWerpTeerling.UseVisualStyleBackColor = true;
            this.btnWerpTeerling.Click += new System.EventHandler(this.btnWerpTeerling_Click);
            // 
            // TeerlingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnWerpTeerling);
            this.Controls.Add(this.TeerlingBox);
            this.Name = "TeerlingView";
            this.Size = new System.Drawing.Size(132, 176);
            this.Load += new System.EventHandler(this.TeerlingView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TeerlingBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox TeerlingBox;
        private System.Windows.Forms.Button btnWerpTeerling;
    }
}
