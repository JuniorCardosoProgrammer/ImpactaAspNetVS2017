using System;
using System.Windows.Forms;

namespace ImpactaAspNet.Capitulo01.Variaveis
{
    public partial class VariaveisForm : Form
    {
        int x = 32;
        int y = 16;
        int w = 45;
        int z = 32;
        int a = 10;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = 2;
            int b = 6, c = 10;
            var d = 13;

            //string nome = "Vítor";
            //var endereco = "R. Tal, 45";
            //var valor = 20.29;
            //var aprovado = true;

            var nascimento = new DateTime(1970, 12, 25);

            var A = 46;
            //a = 20;
            //a = "59";
            object coisa = "texto";
            coisa = DateTime.Now;

            //var e = 58;

            var @class = "3E";

            resultadolistBox.Items.Add("a = " + a);
            resultadolistBox.Items.Add(string.Concat("b = ", b));
            resultadolistBox.Items.Add(string.Format("c = {0}, d = {1}", c, d));
            resultadolistBox.Items.Add($"d = {d}");

            resultadolistBox.Items.Add($"c * d = {c * d}");
            resultadolistBox.Items.Add($"d / a = {d / a}");
            resultadolistBox.Items.Add($"d % a = {d % a}");
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 5;
            resultadolistBox.Items.Add($"x = {x}");

            //x = x - 3;
            x -= 3;

            resultadolistBox.Items.Add($"x = {x}");
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;

            a = 5;
            resultadolistBox.Items.Add("Exemplo de pré-incremento");
            resultadolistBox.Items.Add($"a = {a}");
            resultadolistBox.Items.Add($"2 + ++a = {2 + ++a}");
            resultadolistBox.Items.Add($"a = {a}");

            a = 5;
            resultadolistBox.Items.Add("Exemplo de pós-incremento");
            resultadolistBox.Items.Add($"a = {a}");
            resultadolistBox.Items.Add($"2 + a++ = {2 + a++}");
            resultadolistBox.Items.Add($"a = {a}");

            //if (a > 5)
            //{

            //}
        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadolistBox.Items.Add($"-----------------");

            resultadolistBox.Items.Add($"w <= x = {w <= x}");
            resultadolistBox.Items.Add($"x == z = {x == z}");
            resultadolistBox.Items.Add($"x != z = {x != z}");

        }

        private void ExibirValoresVariaveis()
        {
            resultadolistBox.Items.Add($"x = {x}");
            resultadolistBox.Items.Add($"y = {y}");
            resultadolistBox.Items.Add($"w = {w}");
            resultadolistBox.Items.Add($"z = {z}");
            resultadolistBox.Items.Add(new string('-',50));
        }

        private void lógicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadolistBox.Items.Add($"w <= x || y == 16 = {w <= x || y == 16}");
            resultadolistBox.Items.Add($"x == z && z != x = {x == z && z != x}");
            resultadolistBox.Items.Add($"!(y > w) = {!(y > w)}");
        }

        private void ternarioToolStripMenuItem_Click(object sender, EventArgs e) {
            int ano;

            ano = 2014;
            resultadolistBox
                .Items
                .Add($"O ano {ano} é bissexto? {(ano % 4 == 0 ? "Sim" : "Não")}");

            ano = 2020;
            resultadolistBox
                .Items
                .Add($"O ano {ano} é bissexto? {(DateTime.IsLeapYear(ano) ? "Sim" : "Não")}");

        }
    }
}
