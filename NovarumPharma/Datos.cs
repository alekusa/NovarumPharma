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

        public void Conectar()
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
            Conectar();
            comando.CommandText = query;
            comando.ExecuteNonQuery();
            desconectar();
        }
        public void actualizaGrid(DataGridView dg, string query, string tabla)
        {
            Conectar();
            DataSet dataset = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conexion);
            dataAdapter.Fill(dataset, tabla);
            dg.DataSource = dataset;
            dg.DataMember = tabla;
            desconectar();
        }

        public void cargarComboBox(ComboBox comBox, string tabla, string dato, string pk)
        {
            //box cargado con datatable
            DataTable dt = new DataTable();
            this.Conectar();
            comando.CommandText = "select * from " + tabla;
            //executereder por que es un select... sino se usa nonquery
            dt.Load(comando.ExecuteReader());
            desconectar();
            comBox.DataSource = dt;
            comBox.DisplayMember = dato;
            comBox.ValueMember = pk;
        }
        public double CalcularDolar()
        {
            double resultado;
            string qeri = "SELECT preciodolar FROM Proveedor_Insumo WHERE moneda = 'Dolar'";
            Conectar();
            OleDbCommand cmd = new OleDbCommand(qeri, conexion);
            resultado = Convert.ToDouble(cmd.ExecuteScalar());
            desconectar();
            return resultado;

        }
        public void cargarTXT(TextBox tx,TextBox tx1, TextBox tx2, TextBox tx3)
            {
                
                Conectar();
                string sentencia = "SELECT p.Nombre,i.nombre,cod_cat FROM Proveedores p, Proveedor_Insumo pi, Insumos i WHERE p.id_proveedor=pi.id_proveedor and pi.cod_insumo=i.cod_insumo and i.cod_insumo="+tx.Text+"";
                OleDbCommand comando = new OleDbCommand(sentencia, conexion);
                comando.Parameters.AddWithValue("", tx.Text);
                OleDbDataReader dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                
                        tx1.Text = Convert.ToString(dr["p.Nombre"]);
                        tx2.Text = Convert.ToString(dr["i.nombre"]);
                        tx3.Text = Convert.ToString(dr["cod_cat"]);

                    }
                    dr.Close();
            }
        
        


    }
}
