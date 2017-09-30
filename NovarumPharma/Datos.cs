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
        public void cargarTXT(TextBox tx,TextBox tx1, TextBox tx2, TextBox tx3, TextBox tx4, TextBox tx5)
            {
                
                Conectar();
                string BusquedaPorCodInsumo = "SELECT p.Nombre,i.nombre,cod_cat,precioConIVA,un FROM Proveedores p, Proveedor_Insumo pi, Insumos i WHERE p.id_proveedor=pi.id_proveedor and pi.cod_insumo=i.cod_insumo and i.cod_insumo=" + tx.Text+"";
                OleDbCommand comando = new OleDbCommand(BusquedaPorCodInsumo, conexion);
                comando.Parameters.AddWithValue("", tx.Text);
                OleDbDataReader dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                
                        tx1.Text = Convert.ToString(dr["p.Nombre"]);
                        tx2.Text = Convert.ToString(dr["i.nombre"]);
                        tx3.Text = Convert.ToString(dr["cod_cat"]);
                        tx4.Text = Convert.ToString(dr["precioConIVA"]);
                        tx5.Text = Convert.ToString(dr["un"]);

                    }
                    dr.Close();
            }
        public string validarExistencia(int ID1, int ID2)
        {
            conexion.Close();
            string comparacion1 = "";
            string comparacion2 = "";
            string resultado = "";
            
            string dato1 = "SELECT * FROM Insumos_Receta WHERE cod_insumo=" + ID1 + "";
            OleDbCommand comando = new OleDbCommand(dato1, conexion);
            conexion.Open();
            OleDbDataReader leer = comando.ExecuteReader();
            
            if (leer.Read() == true)
            {
                comparacion1 = "esta";
            }
            else
            {
                comparacion1 = "no";
            }
            leer.Close();
            string dato2 = "select * FROM Insumos_Receta WHERE id_receta='" + ID2 + "'";
            OleDbCommand comando1 = new OleDbCommand(dato1, conexion);
            
            OleDbDataReader leer1 = comando.ExecuteReader();
            if (leer1.Read() == true)
            {
                comparacion2 = "esta";
            }
            else
            {
                comparacion2 = "no";
            }
            if((comparacion1 == "esta") && (comparacion2 == "esta"))
                {
                    resultado = "repetido";
                }
            else
                { 
                    resultado = "Norepetido";
                }
            conexion.Close();
            
            return resultado;
            
            
        }
        


    }
}
