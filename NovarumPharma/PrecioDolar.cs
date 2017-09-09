using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovarumPharma
{
    class PrecioDolar
    {
        int id;
        double preciodolar;

        public int Id { get => id; set => id = value; }
        public double Preciodolar { get => preciodolar; set => preciodolar = value; }

        public PrecioDolar(int cod, double pdolar)
        {
            cod = Id;
            pdolar = preciodolar;

        }
        public PrecioDolar()
        {

        }
    }
}
