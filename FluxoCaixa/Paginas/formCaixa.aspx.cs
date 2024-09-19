using FluxoCaixa.Classes;
using System;
using System.Globalization;

namespace FluxoCaixa.Paginas
{
    public partial class formCaixa : System.Web.UI.Page
    {
        public static Caixa caixa = new Caixa(08,2024);

        private Usuario usuario = new Usuario("",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("~/Default.aspx", false);
                return;
            }
            inicializaLabels();
            inicializaBotoes();
            string periodo = DateTime.Now.Month.ToString("D2") + DateTime.Now.Year.ToString();
            caixa = Serializa.load("08,2024");         
            if (caixa == null) caixa = new Caixa(08,2024);
            caixa.encontraMaiorID();
            tabela.Text = caixa.montaTabela();
            lbValorSaldo.Text = 
                String.Format("{0,10:N2}", caixa.saldo());
        }

        private void inicializaLabels()
        {
            lbCredito.Text = "Crédito";
            lbData.Text = "Data"; 
            lbDebito.Text = "Débito";
            lbDescricao.Text = "Descrição";
            lbSaldo.Text = "Saldo";
            lbValor.Text = "Valor";
        }

        private void inicializaBotoes()
        {
            btOk.Text = " OK ";
            btSair.Text = " Sair ";
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            DateTime data;
            Double valor;
            char creditoDebito;

            if (DateTime.TryParse(txData.Text, out data) == false)
            {
                mensagem.Text = "Data digitada inválida";
                txData.Focus();
                return;
            }
            if (Double.TryParse(txValor.Text, out valor) == false)
            {
                mensagem.Text = "Valor digitado inválido";
                txValor.Focus();
                return;
            }


            if (!rbCredito.Checked && !rbDebito.Checked)
            {
                mensagem.Text = "Selecione se crédito ou débito";
                return;
            }

            lbValorSaldo.Text = String.Format("{0,10:N2}", caixa.saldo());

            if (valor < 0)
            {
                mensagem.Text = "Valor não pode ser negativo";
                return;
            }

            if (rbDebito.Checked && valor > caixa.saldo())
            {
                mensagem.Text = "Saldo insuficiente";
                return ;
            }

            creditoDebito = rbCredito.Checked ? 'C' : 'D';

            Lancamento l = 
             new Lancamento(valor, data, creditoDebito, txDescricao.Text,
             usuario);

            caixa.add(l);

            Serializa.save(caixa);

            tabela.Text = caixa.montaTabela();

            lbValorSaldo.Text = String.Format("{0,10:N2}", caixa.saldo());

        }

        protected void btSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", false);
            return;
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            // A) Pegar o caixa carregado (corrente) e setar o flag fechado com true
            caixa.fechado = true;

            // B) Salvar o arquivo caixa (serializar) com o nome anterior 
            Serializa.save(caixa);


            // C) Pegar o saldo do caixa que foi fechado

            double valor = caixa.saldo();

            // D) Criar um novo caixa com o periodo seguinte

            caixa.proximoPeriodo();
            caixa = new Caixa(caixa.mes, caixa.ano);


            // E) No novo caixa Inserir um lançamento com a data atual, valor atual do saldo do caixa, anterior, descrição: Transporte e usuario corrente
            Lancamento novoLancamento = new Lancamento(valor, DateTime.Now, 'C' ,"Transporte", usuario);
            caixa.add(novoLancamento);

            // Salvar o novo caixa e passar a utiliza-lo como caixa atual 

            Serializa.save(caixa);
            tabela.Text = caixa.montaTabela();
            lbValorSaldo.Text = String.Format("{0,10:N2}", caixa.saldo());


        }

        protected void btCalcula_Click(object sender, EventArgs e)
        {
            //validar as datas iniciais e finais 

            string dataInicialStr = txDatainicial.Text;
            string dataFinalStr = txDataFinal.Text;

            DateTime dataInicial;
            DateTime dataFinal;

            bool isDataInicialValida = DateTime.TryParseExact(dataInicialStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataInicial);
            bool isDataFinalValida = DateTime.TryParseExact(dataFinalStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataFinal);

            if (!isDataInicialValida || !isDataFinalValida)
            {
                mensagem.Text = "Uma ou ambas as datas são inválidas. Por favor, insira datas no formato dd/MM/yyyy.";
                return;
            }

            if (dataFinal < dataInicial)
            {
                mensagem.Text = "A data final não pode ser anterior à data inicial.";
                return;
            }


            //datas devem estar em ordem 

            

            //formatar o valor que devera ser mostrado


            //cadastrar pelo menos 20 lancamentos
            //selecionar um periodo no mes corrente 

        }
    }
}