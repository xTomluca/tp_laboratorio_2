using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;
        public static bool Insertar(Paquete p)
        {
            try
            {
                string nombre = "Suarez Tomas Luca";
                conexion.Open();
                comando.CommandText = string.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES('{0}','{1}','{2}')",p.DireccionEntrega,p.TrackingID, nombre);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
            return false;
        }
        static PaqueteDAO()
        {
            string connection = "Data Source = .\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=True";
            conexion = new SqlConnection(connection);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
    }
}
