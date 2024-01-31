using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace negocio
{
    public static class Validacion
    {
        public static bool validatextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (String.IsNullOrEmpty(texto.Text))
                {
                    return false;
                } else
                {
                    return true;
                }

            }
            return false;
        }

 
    }
}
