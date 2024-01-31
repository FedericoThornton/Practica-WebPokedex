using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Diagnostics;

namespace Pokedex_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();
            try
            {

                if (Validacion.validatextoVacio(txtEmail.Text) || Validacion.validatextoVacio(txtPassword.Text))
                {
                    Session.Add("error", "Debe completar ambos campos");
                    Response.Redirect("Error.aspx");
                }
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;
                
                if (negocio.Login(trainee))
                { 
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex ) { }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }


  //      private void Page_Error(object sender, EventArgs e)
        //{
//            Exception exc = Server.GetLastError();

            // Handle specific exception.
  //          if (exc is HttpUnhandledException)
        //    {
 //               ErrorMsgTextBox.Text = "An error occurred on this page. Please verify your " +
  //              "information to resolve the issue."
    //        }
            // Clear the error from the server.
//           Server.ClearError();
   //     }


    }
}