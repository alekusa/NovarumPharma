using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace NovarumPharma
{
    class funciones
    {
        public void limpiar(Panel panel)
        {
            foreach(Control c in panel.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
    }
}
