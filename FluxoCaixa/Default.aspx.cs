using FluxoCaixa.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FluxoCaixa
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             

            Usuario u = (Usuario)Session["usuario"];
            if (u != null)
            {
                Response.Redirect("~/Paginas/menu.aspx", false);
                return; // Estava faltando isso
            }
            Response.Redirect("~/Paginas/Login.aspx", false);
        }
    }
}