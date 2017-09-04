using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovarumPharma
{
    class Insumos
    {
        int cod_Insumo;
        string nombre;
        string un;
        DateTime fechaactual;

        public int Cod_Insumo { get => cod_Insumo; set => cod_Insumo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Un { get => un; set => un = value; }
        public DateTime Fechaactual { get => fechaactual; set => fechaactual = value; }

        public Insumos(int cod, string nom, string u, DateTime fecha)
        {
            cod = cod_Insumo;
            nom = nombre;
            u = un;
            fecha = fechaactual;
        }
        public Insumos()
        {

        }
    }
}
