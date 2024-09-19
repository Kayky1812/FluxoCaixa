using FluxoCaixa.Classes;
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        List<Usuario> lista = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            lista = SerializaUser.load();
            if (lista == null)
            {
                lista = new List<Usuario>();
                lista.Add(new Usuario("Rangel", "@1234".GetHashCode()));
            } 
            
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;

            foreach (Usuario u in lista)
            {
                if (u.login == nome.Text.Trim() && u.hash == senha.Text.Trim().GetHashCode())
                {
                    Session["usuario"] = u;

                    if (u.perfil == 'A')
                    {
                        Response.Redirect("~/Paginas/menu.aspx", false);
                    } else
                    {
                        Response.Redirect("~/Paginas/formCaixa.aspx", false);
                    }
                    return;
                }
            }

            mensagem.Text = "Usuário não cadastrado ou senha inválida";
        }
    }
}