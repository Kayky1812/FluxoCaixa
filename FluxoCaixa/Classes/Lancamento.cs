using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluxoCaixa.Classes
{
    [Serializable]
    public class Lancamento
    {
        public Double valor {get; set;}
        public DateTime data {get;set;}
        public string descricao {get;set;}
        public Usuario responsavel { get; set; }
        public char tipo {get; set;}

        public int id { get; private set; }

        private static int cont;
        public Lancamento(Double valor, DateTime data, 
            char tipo, String descricao, Usuario usuario)
        {
            
            id = ++cont;
            this.valor = valor;
            this.tipo = tipo;
            this.descricao = descricao;
            this.data = data;
            this.responsavel = usuario;
        }

        public static void setContador(int ct)
        {
            cont = ct;
        }
    }
}