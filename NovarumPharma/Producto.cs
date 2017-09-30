using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovarumPharma
{
    class Producto
    {
        string nombre;
        decimal presentacionGM;
        decimal costoconIVA;

        public string Nombre { get => nombre; set => nombre = value; }
        public decimal PresentacionGM { get => presentacionGM; set => presentacionGM = value; }
        public decimal CostoconIVA { get => costoconIVA; set => costoconIVA = value; }

        public Producto()
        {

        }
        public Producto(string nom,decimal pres,decimal costo)
        {
            nom = Nombre;
            pres = PresentacionGM;
            costo = CostoconIVA;
        }
    }
}
