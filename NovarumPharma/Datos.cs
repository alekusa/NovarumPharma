using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace NovarumPharma
{

    public class Datos
    {
        OleDbConnection conexion;
        OleDbCommand comando = new OleDbCommand();
        OleDbDataReader dr;
        public OleDbDataReader pDr
        {
            get { return dr; }
            set { dr = value; }
        }

        public void conectar()
        {
            conexion = new OleDbConnection(Properties.Settings.Default.conenova);
            conexion.Open();
            comando.Connection = conexion;
        }
        public void desconectar()
        {
            conexion.Close();
        }
        public void ejecutarQuery(string query)
        {
            conectar();
            comando.CommandText = query;
            comando.ExecuteNonQuery();
            desconectar();
        }
        public void actualizaGrid(DataGridView dg, string query, string tabla)
        {
            conectar();
            DataSet dataset = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conexion);
            dataAdapter.Fill(dataset, tabla);
            dg.DataSource = dataset;
            dg.DataMember = tabla;
            desconectar();
        }
        public void cargarComboBox(ComboBox comBox, string tabla, string dato, string pk)
        {
            //combo cargado con datatable
            DataTable dt = new DataTable();
            this.conectar();
            comando.CommandText = "select * from " + tabla;
            //executereder por que es un select... sino se usa nonquery
            dt.Load(comando.ExecuteReader());
            desconectar();
            comBox.DataSource = dt;
            comBox.DisplayMember = dato;
            comBox.ValueMember = pk;
        }
        public void leerTabla(string tabla)
        {
            dr = null;
            conectar();
            comando.CommandText = "select * from " + tabla;
            dr = comando.ExecuteReader();
        }


    }
}
