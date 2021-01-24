
namespace Cliente_finale
{
    partial class Form
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
            this.SpostaCE = new System.Windows.Forms.Button();
            this.SpostaNE = new System.Windows.Forms.Button();
            this.SpostaNO = new System.Windows.Forms.Button();
            this.SpostaSO = new System.Windows.Forms.Button();
            this.SpostaSE = new System.Windows.Forms.Button();
            this.Imm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SpostaCE
            // 
            this.SpostaCE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SpostaCE.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SpostaCE.Enabled = false;
            this.SpostaCE.Location = new System.Drawing.Point(363, 188);
            this.SpostaCE.Name = "SpostaCE";
            this.SpostaCE.Size = new System.Drawing.Size(75, 75);
            this.SpostaCE.TabIndex = 0;
            this.SpostaCE.Text = "CE";
            this.SpostaCE.UseVisualStyleBackColor = true;
            this.SpostaCE.Click += new System.EventHandler(this.SpostaCE_Click);
            // 
            // SpostaNE
            // 
            this.SpostaNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SpostaNE.Enabled = false;
            this.SpostaNE.Location = new System.Drawing.Point(713, 12);
            this.SpostaNE.Name = "SpostaNE";
            this.SpostaNE.Size = new System.Drawing.Size(75, 75);
            this.SpostaNE.TabIndex = 1;
            this.SpostaNE.Text = "NE";
            this.SpostaNE.UseVisualStyleBackColor = true;
            this.SpostaNE.Click += new System.EventHandler(this.SpostaNE_Click);
            // 
            // SpostaNO
            // 
            this.SpostaNO.Enabled = false;
            this.SpostaNO.Location = new System.Drawing.Point(13, 12);
            this.SpostaNO.Name = "SpostaNO";
            this.SpostaNO.Size = new System.Drawing.Size(75, 75);
            this.SpostaNO.TabIndex = 2;
            this.SpostaNO.Text = "NO";
            this.SpostaNO.UseVisualStyleBackColor = true;
            this.SpostaNO.Click += new System.EventHandler(this.SpostaNO_Click);
            // 
            // SpostaSO
            // 
            this.SpostaSO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SpostaSO.Enabled = false;
            this.SpostaSO.Location = new System.Drawing.Point(12, 363);
            this.SpostaSO.Name = "SpostaSO";
            this.SpostaSO.Size = new System.Drawing.Size(75, 75);
            this.SpostaSO.TabIndex = 3;
            this.SpostaSO.Text = "SO";
            this.SpostaSO.UseVisualStyleBackColor = true;
            this.SpostaSO.Click += new System.EventHandler(this.SpostaSO_Click);
            // 
            // SpostaSE
            // 
            this.SpostaSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SpostaSE.Enabled = false;
            this.SpostaSE.Location = new System.Drawing.Point(713, 363);
            this.SpostaSE.Name = "SpostaSE";
            this.SpostaSE.Size = new System.Drawing.Size(75, 75);
            this.SpostaSE.TabIndex = 4;
            this.SpostaSE.Text = "SE";
            this.SpostaSE.UseVisualStyleBackColor = true;
            this.SpostaSE.Click += new System.EventHandler(this.SpostaSE_Click);
            // 
            // Imm
            // 
            this.Imm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Imm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Imm.Enabled = false;
            this.Imm.Location = new System.Drawing.Point(338, 12);
            this.Imm.Name = "Imm";
            this.Imm.Size = new System.Drawing.Size(125, 75);
            this.Imm.TabIndex = 5;
            this.Imm.Text = "Prossima Immagine";
            this.Imm.UseVisualStyleBackColor = true;
            this.Imm.Click += new System.EventHandler(this.Imm_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Imm);
            this.Controls.Add(this.SpostaSE);
            this.Controls.Add(this.SpostaSO);
            this.Controls.Add(this.SpostaNO);
            this.Controls.Add(this.SpostaNE);
            this.Controls.Add(this.SpostaCE);
            this.Name = "Form";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SpostaCE;
        private System.Windows.Forms.Button SpostaNE;
        private System.Windows.Forms.Button SpostaNO;
        private System.Windows.Forms.Button SpostaSO;
        private System.Windows.Forms.Button SpostaSE;
        private System.Windows.Forms.Button Imm;
    }
}

