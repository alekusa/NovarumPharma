using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NovarumPharma
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminInsumos.DefInstancia.MdiParent = this;
            AdminInsumos.DefInstancia.Show();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProductoForms.DefInstancia.MdiParent = this;
            ProductoForms.DefInstancia.Show();
        }

        private void administrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProductoForms.DefInstancia.MdiParent = this;
            ProductoForms.DefInstancia.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Configuracion.DefInstancia.MdiParent = this;
            Configuracion.DefInstancia.Show();
        }
    }
}
