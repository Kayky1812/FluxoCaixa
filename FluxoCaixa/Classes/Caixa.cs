using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluxoCaixa.Classes
{
    [Serializable]
    public class Caixa
    {
        public Caixa(int mes, int ano)
        {
            this.mes = mes;
            this.ano = ano;
        }

        public int mes { get; set; }
        public int ano { get; set; }
        public bool fechado { get; set; }

        private List<Lancamento> lista = new List<Lancamento>();


        public void add(Lancamento l)
        {
            this.lista.Add(l);
        }

        public String montaTabela()
        {
            Tabela tab = new Tabela(this.lista.Count, 6);
            int i = 0;
            foreach (Lancamento lancamento in this.lista)
            {
                tab.celula[i, 0] = lancamento.id + "";
                tab.celula[i, 1] = lancamento.descricao;
                tab.celula[i, 2] = lancamento.data.ToString("dd/MM/yyyy");
                tab.celula[i, 3] = String.Format("{0,10:N2}", lancamento.valor);
                tab.celula[i, 4] = lancamento.tipo == 'C' ? "Crédito" : "Débito";
                tab.celula[i, 5] = lancamento.responsavel.nome;

                
                i++;
            }

            string[] hd = {"Seq","Descrição","Data","Valor","C/D","Responsavel" };
            return tab.tabela(hd);
        }

        public Lancamento lancamento(int id)
        {
            foreach (Lancamento l in lista)
            {
                if (l.id == id) return l;
            }
            return null;
        }

        public Double saldo()
        {
            Double total = 0.0;

            foreach (Lancamento l in lista)
            {
                total += l.tipo == 'C' ? l.valor : -l.valor;
            }

            return total;
        }


        public void proximoPeriodo()
        {
            DateTime data = new DateTime(ano, mes, 01);
            data.AddMonths(1);
            ano = data.Year;
            mes = data.Month;

        }




        public Double saldo(double valorBase, DateTime ini, DateTime fim)
        {
            Double total = valorBase;

            foreach (Lancamento l in lista)
            {
                if (l.data.CompareTo(ini) >= 0 && l.data.CompareTo(fim) <= 0)
                {
                    total += l.tipo == 'C' ? l.valor : -l.valor;
                }
            }

            return total;
        }

        public void encontraMaiorID()
        {
            int max = 0;
            foreach (Lancamento l in lista)
            {
                if (l.id > max)
                {
                    max = l.id;
                }
            }
            Lancamento.setContador(max);
        }

    }
}