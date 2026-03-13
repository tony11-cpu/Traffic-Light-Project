using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTraficLightProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             ctrlTrafic2.Start();
        }

        private void ctrlTrafic1_OnRedLight(object sender, clsClassArgs.StatusChangedEventArgs e)
        {
            MessageBox.Show(e.NewStatus + " for " + e.Duration.ToString() + " seconds.");
        }
    }
}
