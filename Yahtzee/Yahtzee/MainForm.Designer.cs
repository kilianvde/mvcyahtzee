namespace Yahtzee
{
    partial class Yahtzee
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
            this.pnlDobbelstenen = new System.Windows.Forms.Panel();
            this.pnlSpeler1 = new System.Windows.Forms.Panel();
            this.pnlSpeler2 = new System.Windows.Forms.Panel();
            this.btnGooiDobbel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlDobbelstenen
            // 
            this.pnlDobbelstenen.Location = new System.Drawing.Point(13, 13);
            this.pnlDobbelstenen.Name = "pnlDobbelstenen";
            this.pnlDobbelstenen.Size = new System.Drawing.Size(811, 218);
            this.pnlDobbelstenen.TabIndex = 0;
            // 
            // pnlSpeler1
            // 
            this.pnlSpeler1.Location = new System.Drawing.Point(13, 255);
            this.pnlSpeler1.Name = "pnlSpeler1";
            this.pnlSpeler1.Size = new System.Drawing.Size(293, 273);
            this.pnlSpeler1.TabIndex = 1;
            // 
            // pnlSpeler2
            // 
            this.pnlSpeler2.Location = new System.Drawing.Point(531, 255);
            this.pnlSpeler2.Name = "pnlSpeler2";
            this.pnlSpeler2.Size = new System.Drawing.Size(293, 273);
            this.pnlSpeler2.TabIndex = 2;
            // 
            // btnGooiDobbel
            // 
            this.btnGooiDobbel.Location = new System.Drawing.Point(312, 320);
            this.btnGooiDobbel.Name = "btnGooiDobbel";
            this.btnGooiDobbel.Size = new System.Drawing.Size(213, 113);
            this.btnGooiDobbel.TabIndex = 3;
            this.btnGooiDobbel.Text = "Gooi dobbelstenen";
            this.btnGooiDobbel.UseVisualStyleBackColor = true;
            // 
            // Yahtzee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 540);
            this.Controls.Add(this.btnGooiDobbel);
            this.Controls.Add(this.pnlSpeler2);
            this.Controls.Add(this.pnlSpeler1);
            this.Controls.Add(this.pnlDobbelstenen);
            this.Name = "Yahtzee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yahtzee";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDobbelstenen;
        private System.Windows.Forms.Panel pnlSpeler1;
        private System.Windows.Forms.Panel pnlSpeler2;
        private System.Windows.Forms.Button btnGooiDobbel;
    }
}

