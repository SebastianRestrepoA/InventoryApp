using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace InventoryApp.CapaDatos
{
    public class DALProductos
    {
        private DALConexion conexion = new DALConexion();
        SqlCommand comando = new SqlCommand();
        SqlDataReader dataReader;
        DataTable table = new DataTable();


        public void CreateProduct(int codigo, float valor, string producto, string descripcion)
        {

            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "INV_INSERTAR_PRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@valor", valor);
            comando.Parameters.AddWithValue("@producto", producto);
            comando.Parameters.AddWithValue("@descripcion", descripcion);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
     
        public DataTable ReadAllProducts()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "INV_MOSTRAR_ALL_PRODUCTS";
            comando.CommandType = CommandType.StoredProcedure;
            dataReader = comando.ExecuteReader();
            table.Load(dataReader);
            conexion.CloseConnection();
            return table;

        }

        public void DeleteProduct(int codigo)
        {

            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "INV_ELIMINAR_PRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void UpdateProduct(int codigo, float valor, string producto, string descripcion)
        {

            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "INV_ACTUALIZAR_PRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@valor", valor);
            comando.Parameters.AddWithValue("@producto", producto);
            comando.Parameters.AddWithValue("@descripcion", descripcion);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
