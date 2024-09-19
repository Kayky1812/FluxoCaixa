using FluxoCaixa.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FluxoCaixa.Paginas
{
    public partial class CadUser : Page
    {
        static List<Usuario> lista = new List<Usuario>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("~/Default.aspx", false);
                return;
            }

            inicializaLabels();

            lista = SerializaUser.load();
            if (lista == null)
            {
                lista = new List<Usuario>();
            }
            tabela.Text = montaTabela(lista);
        }

        private void inicializaLabels()
        {
            lbLogin.Text = "Login";
            lbSenha.Text = "Senha";
            lbNome.Text = "Nome";
            lbAdm.Text = "Usuário ADM";
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            
            if (txNome.Text == "" || txSenha.Text == "" || txLogin.Text == "")
            {
                mensagem.Text = "Obrigatório Nome, senha e login";
                return;
            }

          
            if (txSenha.Text.Length < 6)
            {
                mensagem.Text = "Use pelo menos 6 dígitos para a senha";
                return;
            }

            
            var usuarioExistente = lista.FirstOrDefault(u => u.login.Equals(txLogin.Text, StringComparison.OrdinalIgnoreCase));

            if (usuarioExistente != null)
            {
                
                usuarioExistente.nome = txNome.Text;
                usuarioExistente.hash = txSenha.Text.GetHashCode(); 
                usuarioExistente.perfil = cbAdm.Checked ? 'A' : 'U';

                SerializaUser.save(lista);
                mensagem.Text = "Usuário atualizado com sucesso.";
            }
            else
            {
                
                Usuario novo = new Usuario(txLogin.Text, txSenha.Text, txNome.Text, cbAdm.Checked ? 'A' : 'U');
                lista.Add(novo);
                SerializaUser.save(lista);
                mensagem.Text = "Usuário criado com sucesso.";
            }

           
            txLogin.Text = txSenha.Text = txNome.Text = "";
            cbAdm.Checked = false;
            tabela.Text = montaTabela(lista);
        }



        public String montaTabela(List<Usuario> listaUsuarios)
        {
            Tabela tab = new Tabela(listaUsuarios.Count, 4);
            int i = 0;
            foreach (Usuario u in listaUsuarios)
            {
                tab.celula[i, 0] = (i + 1) + "";
                tab.celula[i, 1] = u.nome;
                tab.celula[i, 2] = u.login;
                tab.celula[i, 3] = u.perfil == 'A' ? "Adm" : "User";

                i++;
            }

            string[] hd = { "Seq", "Nome", "Login", "Tipo" };
            return tab.tabela(hd);
        }

        protected void btSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/menu.aspx", false);
            return;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string loginBuscado = txLogin.Text.Trim();
            if (string.IsNullOrEmpty(loginBuscado))
            {
                mensagem.Text = "Digite um login para realizar a busca.";
                return;
            }


            var usuarioEncontrado = lista.FirstOrDefault(u => u.login.Equals(loginBuscado, StringComparison.OrdinalIgnoreCase));

            if (usuarioEncontrado == null)
            {
                mensagem.Text = "Nenhum usuário com esse login localizado.";

                txLogin.Text = txSenha.Text = txNome.Text = "";
                cbAdm.Checked = false;
            }
            else
            {
                btnDeletar.Enabled = true;
                txLogin.Text = usuarioEncontrado.login;
                txSenha.Text = usuarioEncontrado.hash.ToString();
                txNome.Text = usuarioEncontrado.nome;
                cbAdm.Checked = usuarioEncontrado.perfil == 'A';

                mensagem.Text = "";


                tabela.Text = montaTabela(new List<Usuario> { usuarioEncontrado });
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txNome.Text = String.Empty;
            txLogin.Text = String.Empty;
            txSenha.Text = String.Empty;
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            

            string loginBuscado = txLogin.Text.Trim();
            
            if (string.IsNullOrEmpty(loginBuscado))
            {
                mensagem.Text = "Digite um login para realizar a busca.";
                return;
               
            }

            btnDeletar.Enabled = true;
            var usuarioEncontrado = lista.FirstOrDefault(u => u.login.Equals(loginBuscado, StringComparison.OrdinalIgnoreCase));
            
            if (usuarioEncontrado == null)
            {
                mensagem.Text = "Nenhum usuário com esse login localizado.";

                txLogin.Text = txSenha.Text = txNome.Text = "";
                cbAdm.Checked = false;
                
            }
            else 
            {
                btnDeletar.Enabled = true;
                lista.Remove(usuarioEncontrado);
                SerializaUser.save(lista);


                tabela.Text = montaTabela(lista);
            }
        }

    }
}
