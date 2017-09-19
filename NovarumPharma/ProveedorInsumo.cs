using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovarumPharma
{
    class ProveedorInsumo
    {
        int id_proveedor;
        double precioSinIVAmonedaCotizada;
        string moneda;
        double precioSinIVAenPesos;
        double iva;
        double precioConIVA;
        string un;
        DateTime fechaActualizacion;
        double preciodolar;
        

        public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public double PrecioSinIVAmonedaCotizada { get => precioSinIVAmonedaCotizada; set => precioSinIVAmonedaCotizada = value; }
        public string Moneda { get => moneda; set => moneda = value; }
        public double PrecioSinIVAenPesos { get => precioSinIVAenPesos; set => precioSinIVAenPesos = value; }
        public double Iva { get => iva; set => iva = value; }
        public double PrecioConIVA { get => precioConIVA; set => precioConIVA = value; }
        public string Un { get => un; set => un = value; }
        public DateTime FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }
        public double Preciodolar { get => preciodolar; set => preciodolar = value; }

        public ProveedorInsumo(int id, double preSinIVAmCotizada, string mon, double preSinIVAenPesos, double iv, double preconIVA, string UN, DateTime FA, double predolar)
        {
            id = Id_proveedor;
            preSinIVAmCotizada = PrecioSinIVAmonedaCotizada;
            mon = Moneda;
            preSinIVAenPesos = PrecioSinIVAenPesos;
            iv = Iva;
            preconIVA = PrecioConIVA;
            UN = Un;
            FA = FechaActualizacion;
            predolar = Preciodolar;

        }
        public ProveedorInsumo()
        {

        }
        
    }
}
