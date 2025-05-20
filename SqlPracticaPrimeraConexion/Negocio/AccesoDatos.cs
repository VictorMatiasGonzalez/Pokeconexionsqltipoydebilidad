using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//conexion sql

namespace Negocio
{
     public class AccesoDatos//centralizamos el acceso a base datos
    {
        private SqlConnection conexion;//para leer base datos nesecito esto.
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()// constructor
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS;database=POKEDEX_DB;integrated security=true");
            comando = new SqlCommand();
            
        }

        public void setearConsulta(string consulta)//funcion
        {
            comando.CommandType = System.Data.CommandType.Text;// base de datos de texto
            comando.CommandText = consulta;
        }

        public void ejecutarLectura ()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //no tenemos el metodo insertar dato > lo creamos
        public void ejecutarAccion()//METODO INSERTAR POKEMON NUEVO A BASE SQL------------------------
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();// Agrega nuevo dato

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//----------------------------------------------------------------------------------------

        public void setearParametro(string nombre, object valor)//Agregar parametros a la consulta @Idtipo y @IdDebilidad-----
        {
            comando.Parameters.AddWithValue(nombre,valor);// se carga nombre valor y el objeto por parametros
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
        
    }


}
