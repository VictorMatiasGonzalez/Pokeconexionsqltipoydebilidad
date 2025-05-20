using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
namespace ConexionSqlPractica
{
    public partial class FrmAltaPokemon : Form
    {//EVENT DE LA VENTANA ALTA POKEMON
        public FrmAltaPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)//leeremos los datos
        {//LA LOGICA SE HACE ACA PORQUE LAS CAJAS DE TEXTO GUARDAN LA INFO!!!!
            Pokemon poke = new Pokemon();//creamos nuevo pokemon
            PokemonConexion negocio = new PokemonConexion();//objeto pokemon conexion
            try
            {// al aceptar guardamos los datos de estas 3 cajas de texto
                poke.Numero = int.Parse(txtNumero.Text);//porque va un numero
                poke.Nombre = txtNombre.Text;
                poke.Descripcion = txtDescripcion.Text;
                poke.Tipo = (Elemento)cbTipo.SelectedItem;// ahora manda a sql tipo y descripcion tambien
                poke.Debilidad = (Elemento)cbDebilidad.SelectedItem;// aclaramos que es un elemento

                negocio.Agregar(poke);
                MessageBox.Show("Pokemon agregado");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());//muestra msj con erros ahora que estamos desarrollando
            }
        }

        private void FrmAltaPokemon_Load(object sender, EventArgs e)
        {//Cargamos en en load del formulario de alta, los combobox!
            ElementoNegocio elemento = new ElementoNegocio();//elemento negocio trae id/descripcion base dato elementos

            try

            {
                cbTipo.DataSource = elemento.listar();//combobox tipo
                cbDebilidad.DataSource = elemento.listar();//combobox debilidad
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}
