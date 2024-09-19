using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FluxoCaixa.Classes
{
    public class Tabela
    {
        private int linhas;
        private int colunas;

        public string[,] celula;

        public Tabela(int linhas, int colunas)
        {
            celula = new string[linhas,colunas];
            this.linhas = linhas;
            this.colunas = colunas;
        }

        public string tabela(string [] titulo)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table>");
         
            str.Append("<tr>");
            for (int col = 0; col < colunas; col++)
            {
                str.Append("<TD>&nbsp;<B>");
                str.Append(titulo[col]);
                str.Append("</B>&nbsp;</TD>");
            }
            str.Append("</tr>");
        
            for (int lin = 0; lin < linhas; lin++)
            {
                str.Append("<tr>");
                for(int col = 0; col < colunas; col++)
                {
                    str.Append("<TD>&nbsp;");
                    str.Append(celula[lin, col]);
                    str.Append("&nbsp;</TD>");
                }
                str.Append("</tr>");
            }
            str.Append("<TR><TD colspan='");
            str.Append(colunas);
            str.Append("'><hr /></TD></TR>");
            str.Append("</table>");
            return str.ToString();
        }
     }
}