namespace MyTraficLightProj
{
    partial class Form1
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
            this.ctrlTrafic2 = new MyTraficLightProj.ctrlTrafic();
            this.SuspendLayout();
            // 
            // ctrlTrafic2
            // 
            this.ctrlTrafic2.AutoSize = true;
            this.ctrlTrafic2.CurrentTraficStatus = MyTraficLightProj.ctrlTrafic.enLightState.Red;
            this.ctrlTrafic2.GreenDuration = ((byte)(15));
            this.ctrlTrafic2.Location = new System.Drawing.Point(92, 12);
            this.ctrlTrafic2.Name = "ctrlTrafic2";
            this.ctrlTrafic2.OrangeDuration = ((byte)(5));
            this.ctrlTrafic2.RedDuration = ((byte)(10));
            this.ctrlTrafic2.Size = new System.Drawing.Size(403, 433);
            this.ctrlTrafic2.TabIndex = 0;
            this.ctrlTrafic2.OnRedLight += new System.EventHandler<MyTraficLightProj.clsClassArgs.StatusChangedEventArgs>(this.ctrlTrafic1_OnRedLight);
            this.ctrlTrafic2.OnOrangeLight += new System.EventHandler<MyTraficLightProj.clsClassArgs.StatusChangedEventArgs>(this.ctrlTrafic1_OnRedLight);
            this.ctrlTrafic2.OnGreenLight += new System.EventHandler<MyTraficLightProj.clsClassArgs.StatusChangedEventArgs>(this.ctrlTrafic1_OnRedLight);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(699, 433);
            this.Controls.Add(this.ctrlTrafic2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlTrafic ctrlTrafic2;
    }
}

