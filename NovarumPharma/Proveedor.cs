using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovarumPharma
{
    class Proveedor
    {
        int id_proveedor;
        string nombreProveedor;
        string contato;
        int telefonoUno;
        int telefonoDos;
        int fax;
        int celular;
        string email;
        int id_domicilio;

        public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public string NombreProveedor { get => nombreProveedor; set => nombreProveedor = value; }
        public string Contato { get => contato; set => contato = value; }
        public int TelefonoUno { get => telefonoUno; set => telefonoUno = value; }
        public int TelefonoDos { get => telefonoDos; set => telefonoDos = value; }
        public int Fax { get => fax; set => fax = value; }
        public int Celular { get => celular; set => celular = value; }
        public string Email { get => email; set => email = value; }
        public int Id_domicilio { get => id_domicilio; set => id_domicilio = value; }

        public Proveedor(int id_provee, string nomProv, string contact, int tel1, int tel2, int fa, int cel, string correo, int id_domi)
        {
            id_provee = Id_proveedor;
            nomProv = NombreProveedor;
            contact = Contato;
            tel1 = TelefonoUno;
            tel2 = TelefonoDos;
            fa = Fax;
            cel = Celular;
            correo = Email;
            id_domi = Id_domicilio;

        }
        public Proveedor()
        {

        }
    }
}
