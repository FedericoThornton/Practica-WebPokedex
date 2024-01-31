using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Pokedex_Web
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion  { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();
                    DdlTipo.DataSource = lista;
                    DdlTipo.DataValueField = "id";
                    DdlTipo.DataTextField = "Descripcion";
                    DdlTipo.DataBind();

                    DdlDebilidad.DataSource = lista;
                    DdlDebilidad.DataValueField = "id";
                    DdlDebilidad.DataTextField = "Descripcion";
                    DdlDebilidad.DataBind();
                }

                // configuracion si estamos modificando
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
               //     List<Pokemon> lista = negocio.Listar(id);
              //      Pokemon seleccionado = lista[0];
                      Pokemon seleccionado = (negocio.Listar(id))[0];
                    // guardo pokemon seleccionado en la session
                    Session.Add("Pokeseleccionado", seleccionado);

                    //precargar todos los campos
                    txtId.Text = id;
                    TxtNombre.Text = seleccionado.Nombre;
                    TxtNumero.Text = seleccionado.Numero.ToString();
                    TxtDescripcion.Text = seleccionado.Descripcion;
                    TxtUrlImagen.Text = seleccionado.UrlImagen;
                    DdlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    DdlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    TxtUrlImagen_TextChanged(sender, e);

                    // configurar acciones
                    if(!seleccionado.Activo)
                    {
                        btnInactivar.Text = "Reactivar";
                    }
                }


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
              
                // redireccion a pantalla de error

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Numero = int.Parse(TxtNumero.Text);
                nuevo.Nombre = TxtNombre.Text;
                nuevo.Descripcion = TxtDescripcion.Text;
                nuevo.UrlImagen = TxtUrlImagen.Text;
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(DdlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(DdlDebilidad.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id= int.Parse(Request.QueryString["Id"].ToString());
                    negocio.ModificarConSP(nuevo);
                } else
                negocio.AgregarConSP(nuevo);


                Response.Redirect("PokemonLista.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void TxtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            ImagenPokemon.ImageUrl = TxtUrlImagen.Text;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.Eliminar(int.Parse(txtId.Text));
                    Response.Redirect("PokemonLista.aspx");
                }
               
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado = (Pokemon)Session["Pokeseleccionado"];

                negocio.Eliminarlogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("PokemonLista.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}