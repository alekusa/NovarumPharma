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

            string updateDolar = "UPDATE Proveedor_Insumo SET preciodolar ='"+ pd.Preciodolar + "' WHERE moneda='Dolar';";
            string updatePesos = "UPDATE Proveedor_Insumo SET preciodolar = 1 WHERE moneda='Pesos';";
            dato.ejecutarQuery(updateDolar);
            dato.ejecutarQuery(updatePesos);
            txtConfigDolar.Clear();
            


        }
    }
}
