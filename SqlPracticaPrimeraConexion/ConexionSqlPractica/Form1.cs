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
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemon; // atributo privado                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            public Form1()
        {
            InitializeComponent();
        }

      //  private void Form1_Load(object sender, EventArgs e)
      //  {
      //      PokemonConexion poketconexion = new PokemonConexion();
       //     listaPokemon = poketconexion.listar(); //va a la base de datos y devuelve los datos.
       //     dgv.DataSource = listaPokemon;
       //     dgv.Columns["UrlImagen"].Visible = false; // oculta la columna urlimagen
       //     pBPokemon.Load(listaPokemon[0].UrlImagen);                                                                                                                                                                                              
      //  }

       // private void dgv_SelectionChanged(object sender, EventArgs e)// cada vez que seleccionamos 
      //  {
      //     Pokemon seleccionado=(Pokemon) dgv.CurrentRow.DataBoundItem;
       //     pBPokemon.Load(seleccionado.UrlImagen);
       // }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaPokemon alta = new FrmAltaPokemon();
            alta.ShowDialog();//(show dialog) no permite que salgas de ventana hasta salir de ella


        }

        //capurar excepcion al cargar imagen que no se encuentra en la base de datos POKEDEX_DB

          private void Form1_Load(object sender, EventArgs e)
          {
              PokemonConexion poketconexion = new PokemonConexion();
              listaPokemon = poketconexion.listar(); //va a la base de datos y devuelve los datos.
            dgv.DataSource = listaPokemon;
            dgv.Columns["UrlImagen"].Visible = false;
            cargarImagen(listaPokemon[0].UrlImagen);
         }

         private void dgv_SelectionChanged(object sender, EventArgs e)// cada vez que seleccionamos 
         {
            Pokemon seleccionado = (Pokemon)dgv.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                                                              
         }

        //FUNCION

         private void cargarImagen(string imagen)
         {
            try
            {
                pBPokemon.Load(imagen);
           }
           catch (Exception ex)
           {

                pBPokemon.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
          }

          }








    }
}
