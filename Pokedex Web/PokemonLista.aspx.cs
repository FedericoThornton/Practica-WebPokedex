using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Pokedex_Web
{
    public partial class PokemonLista : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.esAdmin(Session["trainee"]))
            {
                Session.Add("error", "Se requiere permiso de Admin para acceder");
                Response.Redirect("Error.aspx", false);
            }
            filtroAvanzado = false;
            PokemonNegocio negocio = new PokemonNegocio();
            Session.Add("ListaPokemons", negocio.ListarConSP());
            dgvPokemons.DataSource = Session["ListaPokemons"];
            dgvPokemons.DataBind();

        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?Id=" + Id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["ListaPokemons"];
            String filtro = txtFiltro.Text;
            try
            {
                if (filtro.Length >= 2)
                {
                    List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    dgvPokemons.DataSource = listaFiltrada;
                    dgvPokemons.DataBind();
                }
                else
                {
                    List<Pokemon> listaFiltrada = lista;
                }


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void chkfiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkfiltroAvanzado.Checked;
            txtFiltro.Enabled = !filtroAvanzado;

        }

        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCriterio.Items.Clear();
            if (DdlCampo.SelectedItem.ToString() == "Número")
            {
                DdlCriterio.Items.Add("Igual a");
                DdlCriterio.Items.Add("Mayor a");
                DdlCriterio.Items.Add("Menor a");

            }
            else
            {
                DdlCriterio.Items.Add("Contiene");
                DdlCriterio.Items.Add("Comienza con");
                DdlCriterio.Items.Add("Termina con");
            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.Filtrar(DdlCampo.SelectedItem.ToString(),
                    DdlCriterio.SelectedItem.ToString(),
                    TxtFiltroavanzado.Text,
                    DdlEstado.SelectedItem.ToString());
                dgvPokemons.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}