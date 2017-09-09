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
        

        public int Cod_Insumo { get => cod_Insumo; set => cod_Insumo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        

        public Insumos(int cod, string nom)
        {
            cod = Cod_Insumo;
            nom = Nombre;
           
        }
        public Insumos()
        {

        }
    }
}
