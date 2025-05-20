using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // libreria para conectar a sql
using Dominio;

namespace Negocio
{
     public class PokemonConexion
    {//Aca nos conectaremos a la base de datos pokemon en sql
                                     // METODO :FUNCION ESPECIAL par ser usada dentro de un objeto            
        public List<Pokemon> listar()// hacemos una lista de la clase pokemon/ metodo publico para acceder exterior
        {                            //Esta va ser una funcion(metodo) que lea registros de la base de datos, va a devolver varios pokemon o registros, agrupados en una lista
            List<Pokemon> lista = new List<Pokemon>();// creamos lista de pokemon
            SqlConnection conexion = new SqlConnection();//conectar
            SqlCommand comando = new SqlCommand();//accionar en sql
            SqlDataReader lector; //lee datos.

            try// manejar excepciones                                   
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=POKEDEX_DB;integrated security=true";  //base datos POKEDEX                   
                comando.CommandType = System.Data.CommandType.Text;//lee solo texto que hay en base datos
                comando.CommandText = "select Numero, Nombre,P.Descripcion , UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad  from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad";                                                                                                                        
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())// va a leer las lineas y columas de la base de datps POKEMONS
                {
                    Pokemon aux = new Pokemon();                  //el while lee el lector
                    aux.Numero = (int) lector ["Numero"];
                    aux.Nombre = Convert.ToString (lector ["Nombre"]);
                    aux.Descripcion = (string)lector ["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento();// Tipo es un objeto,es un objeto de tipo elemento
                    aux.Tipo.Descripcion = (string) lector ["Tipo"];// me traigo del objeto tipo la descripcion.
                    aux.Debilidad = new Elemento(); //crea un elemento de nombre debilidad
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];//debilidad un objeto de tipo elemento


                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
            


           
        }

        public void Agregar (Pokemon nuevo)// Metodo para insertar nuevo pokemon-----------------------
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into POKEMONS (Numero,Nombre,Descripcion,Activo,IdTipo,IdDebilidad) values(" + nuevo.Numero + ",'" + nuevo.Nombre + "','" + nuevo.Descripcion + " ',1,@IdTipo,@IdDebilidad)");//1era de dos formas-@2da forma// agregamos idtipo y iddebilidad
                datos.setearParametro("@IdTipo", nuevo.Tipo.Id);// agregamos parametros de tipo y debilidad y los manda a sql
                datos.setearParametro("@IdDebilidad", nuevo.Debilidad.Id);
                //No se ejecuta un reader porque se esta insertando datos nuevos
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
      //----------------------------------------------------------------------------------------

    }
}
