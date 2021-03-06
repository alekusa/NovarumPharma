﻿using System;
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
        public void UpdatePorcentaje(string NewPorcentajeMP, string codInsumo, string idReceta)
        {
            try
            {
                Conectar();
                comando.CommandText = "UPDATE Insumos_Receta SET cantMP="+ NewPorcentajeMP + " WHERE cod_insumo="+codInsumo+" and id_receta="+idReceta+"";
                comando.ExecuteNonQuery();
                desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void cargarTXBoxInsumos(TextBox tx,TextBox tx1, TextBox tx2, TextBox tx3, TextBox tx4, TextBox tx5)
            {
                
                Conectar();
                string BusquedaPorCodInsumo = "SELECT p.Nombre,i.nombre,cod_cat,precioConIVA,un FROM Proveedores p, Proveedor_Insumo pi, Insumos i WHERE p.id_proveedor=pi.id_proveedor and pi.cod_insumo=i.cod_insumo and i.cod_insumo=" + tx.Text + "";
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
            else
            {
                tx1.Clear();
                tx2.Clear();
                tx3.Clear();
                tx4.Clear();
                tx5.Clear();
            }
                    dr.Close();
            }

        public void cargarDatoProducto(TextBox tx, TextBox tx1)
        {

            Conectar();
            string BusquedaPorCodInsumo = "SELECT r.id_receta FROM Producto p, Receta r  WHERE p.id_producto=r.id_producto and p.nombre='"+tx.Text+"'";
            OleDbCommand comando = new OleDbCommand(BusquedaPorCodInsumo, conexion);
            comando.Parameters.AddWithValue("", tx.Text);
            OleDbDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                tx1.Text = Convert.ToString(dr["id_receta"]);
                dr.Close();
            }
            desconectar();
        }

        public void recuperarIDproducto(TextBox t1, TextBox idProducto, TextBox presentacion)
        {
           
            Conectar();
            string BusquedaPorCodInsumo = "SELECT id_producto, presentacionGM FROM Producto WHERE nombre='" + t1.Text + "'";
            OleDbCommand comando = new OleDbCommand(BusquedaPorCodInsumo, conexion);
            comando.Parameters.AddWithValue("", t1.Text);
            OleDbDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                idProducto.Text = Convert.ToString(dr["id_producto"]);
                presentacion.Text = Convert.ToString(dr["presentacionGM"]);
                dr.Close();
            }
            else
            {
                dr.Close();
            }
            desconectar();
        }
        
        


        public string validarExistenciaInsumoreceta(int ID1, int ID2)
        {
            conexion.Close();
            string resultado = "";
                        
            string dato1 = "SELECT * FROM Insumos_Receta WHERE cod_insumo=" + ID1 + " and id_receta="+ ID2 +"";
            OleDbCommand comando = new OleDbCommand(dato1, conexion);
            conexion.Open();
            OleDbDataReader leer = comando.ExecuteReader();
            
            if (leer.Read() == true)
            {
                resultado = "repe";
            }
            else
            {
                resultado = "no";
            }
            leer.Close();
            return resultado;
            
            
        }
        public string ValidarExistenciaProducto(string ID1)
        {
            conexion.Close();
            
            string resultado = "";

            string dato1 = "SELECT * FROM Producto WHERE nombre='" + ID1 + "'";
            OleDbCommand comando = new OleDbCommand(dato1, conexion);
            conexion.Open();
            OleDbDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                resultado = "esta";
            }
            else
            {
                resultado = "no";
            }
            leer.Close();
            conexion.Close();
            desconectar();
            return resultado;


        }
        public Int32 ValidarExistenciaInsumo(int ID1)
        {
            conexion.Close();

            Int32 resultado = 0;

            string dato1 = "SELECT * FROM Insumos WHERE cod_insumo=" + ID1 + "";
            OleDbCommand comando = new OleDbCommand(dato1, conexion);
            conexion.Open();
            OleDbDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                resultado = 0;
            }
            else
            {
                resultado = 1;
            }
            leer.Close();
            conexion.Close();
            desconectar();
            return resultado;


        }
        



    }
}
