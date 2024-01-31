using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Pokedex_Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgAvatar.ImageUrl = "https://cdn2.vectorstock.com/i/1000x1000/17/61/male-avatar-profile-picture-vector-10211761.jpg";
            if (!(Page is Login || Page is Registro || Page is Default || Page is Error))
            {
                if (!(Seguridad.sesionActiva(Session["trainee"])))

                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {

                    Trainee user = (Trainee)Session["trainee"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        ImgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }
            
               
            
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}