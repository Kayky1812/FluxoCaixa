using System;

namespace FluxoCaixa.Classes
{
    [Serializable]
    public class Usuario
    {
        public String login { get; private set; }
        public int hash { get; set; }
        public String nome { get; set; }
        public char perfil { get;set; }
        public Usuario (String login, String password, 
            String nome, char perfil)
        {
            this.login = login;
            this.hash = password.GetHashCode();
            this.nome = nome;
            this.perfil = perfil;
        }
        public int CompareTo(Usuario u)
        {
            return this.login.CompareTo(u.login);
        }

        public Usuario(String login, int hash )
        {
            this.login = login;
            this.hash = hash;
            this.nome = login.ToUpper().Replace("."," ");
            this.perfil = 'A';
        }




    }
}