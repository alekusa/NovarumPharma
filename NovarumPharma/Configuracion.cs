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
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            btnGuardar.Enabled = true;
        }
        private static Configuracion Instancia;
        public static Configuracion DefInstancia
        {
            get
            {
                if (Instancia == null || Instancia.IsDisposed)
                    Instancia = new Configuracion();
                return Instancia;
            }
            set
            {
                Instancia = value;
            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            Datos dato = new Datos();
            PrecioDolar pd = new PrecioDolar();
            pd.Preciodolar = Convert.ToDouble(txtConfigDolar.Text);

            string queryUpdate = "UPDATE CotizacionDolar SET preciodolar ='"+ pd.Preciodolar + "' WHERE id_dolar=1;";
            dato.ejecutarQuery(queryUpdate);
            txtConfigDolar.Clear();
            


        }
    }
}
