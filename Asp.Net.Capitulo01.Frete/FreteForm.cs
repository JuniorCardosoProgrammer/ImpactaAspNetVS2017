using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Asp.Net.Capitulo01.Frete
{
    public partial class FreteForm : Form
    {
        public FreteForm()
        {
            InitializeComponent();
        }
        //AULA 04 - CAPÍTULO 01 - WINDOWS FORM
        /*
        Para criar novos projetos na mesma solução 
          basta clicar com o botão direito em solução -> adicionar - > novo projeto.
          windows form .net framework.

          Sempre usar F4 para selecionar as propriedades 
          e sempre definir o name e o text dos objetos que forem utilizados na janela form.


            para definir o botão de enter e esc basta clicar no form principal apertar 


            ctrl+k+d = alinhar código
            ctrl+k+f = alinhar código


             crtl+. é atalho para sugetões


         Método void não tem retorno 'return'
         */
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            //a variável erros recebe uma listagem de erros do método ValidarFormulario();
            var erros = ValidarFormulario();

            //se não houver erros ele excuta o método Calcular();
            if (erros.Count() == 0)
            {
                Calcular();
            }
            else
            {
                //é uma classe do framework que chama um popup de alerta. configurável
                //o método join seleciona e "concatena" todos os elementos de uma lista
                //Environment.NewLine é o mesmo \n\r ou <br>, ou seja uma quebra de linha
                MessageBox.Show(string.Join(Environment.NewLine, erros), //lista/array/conjunto de dados
                    "Validação", //título do popup
                    MessageBoxButtons.OK, //Botão de Confirmar
                    MessageBoxIcon.Error //ícone
                    );
            }
        }

        private void Calcular()
        {
            var percentualFrete = 0M; //o M converte em decimal
            var valor = Convert.ToDecimal(valorTextBox.Text.Trim());
            var nordeste = new List<string> { "BA", "AL", "CE" };

            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentualFrete = 0.2m;
                break;

                case "RJ":
                    percentualFrete = 0.3m;
                    break;

                case "MG": //ctrl + shif + u transforma em caixa alta
                    percentualFrete = 0.35m;
                    break;

                case "AM":
                    percentualFrete = 0.6m;
                    break;

                case var uf when nordeste.Contains(uf):
                    percentualFrete = 0.7m;
                    break;

                default:
                    percentualFrete = 0.7m;
                    break;
            } //swift é uma estrutura de decisão permormática. Onde diminuimos a quantidade de código e evitamos que o restante do código seja processado quando já foi processado e manipulado os dados necessários.

            freteTextBox.Text = percentualFrete.ToString("p2");//p2 Tem a visualização em porcentual.
            totalTextBox.Text = ((1 + percentualFrete) * valor).ToString("C");//C Tem a visualização em valor monetário.
        }
        /*
            var aceita diferentes tipos de dado.
            object aceita qualquer tipo de dado, mas não informa que tipo de dado foi armazenado/encontrado/atribuído.
        */
        private List<string> ValidarFormulario()
        {
            var erros = new List<string>();
            var cliente = clienteTextBox.Text.Trim();
            //var valor = Convert.ToDecimal(valorTextBox.Text.Trim());

            //if (clienteTextBox.Text == "") - não serve se for preenchido com espaço
            //método Trim() remove espaços em branco antes e depois do valor recebido/selecionado/enviado
            //é possível usar TrimEnd() e TrimStart() para remover espaços só no final ou só no começo
            if (cliente == string.Empty)
            {
                erros.Add("O campo Cliente é obrigatório.");
            }

            //utilizar a tecla tab duas vezes escreve a estrutura do código automaticamente
            //no combobox para fazer a validação e saber se não foi selecionado nenhum item o combobox deve ser comparado ao índice -1 (já que o primeiro valor é igual a 0)
            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("Selecione a UF.");
            }

            if (string.IsNullOrEmpty(valorTextBox.Text.Trim()))
            {
                erros.Add("O campo Valor é obrigatório");
            }
            else
            {
                //O método TryParse retorna um bool e o valor analisado
                //
                if (!decimal.TryParse(valorTextBox.Text.Trim(), out decimal valorConvertido))
                {
                    erros.Add("O campo Valor é obrigatório.");
                }
            }

            return erros;
        }

        private void limparButton_Click(object sender, EventArgs e) {
            clienteTextBox.Clear(); //Serve para limpar valores das caixas de textos selecionadas.
            valorTextBox.Text = ""; //Não serve para limpar valores.
            ufComboBox.SelectedIndex = -1; //O Combobox/Select não deve ser apagado os itens. mas escolher um índice que esteja vazio. Neste caso -1.
            freteTextBox.Text = null;// Não serve para limpar. null é ausência de valor. se o usuário já preencheu o formulário então não substituirá por null.
            totalTextBox.Text = string.Empty;
        }
    }
}
