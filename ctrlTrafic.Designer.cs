namespace MyTraficLightProj
{
    partial class ctrlTrafic
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
            this.pbTraficLight = new System.Windows.Forms.PictureBox();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTraficLight)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTraficLight
            // 
            this.pbTraficLight.Image = global::MyTraficLightProj.Properties.Resources.Red;
            this.pbTraficLight.Location = new System.Drawing.Point(0, 3);
            this.pbTraficLight.Name = "pbTraficLight";
            this.pbTraficLight.Size = new System.Drawing.Size(295, 316);
            this.pbTraficLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTraficLight.TabIndex = 0;
            this.pbTraficLight.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(107, 348);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(70, 52);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "??";
            // 
            // ctrlTrafic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pbTraficLight);
            this.Name = "ctrlTrafic";
            this.Size = new System.Drawing.Size(298, 443);
            ((System.ComponentModel.ISupportInitialize)(this.pbTraficLight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTraficLight;
        private System.Windows.Forms.Label lblTime;
    }
}
