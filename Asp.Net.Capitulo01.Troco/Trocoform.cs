using System;
using System.Windows.Forms;

namespace Asp.Net.Capitulo01.Troco
{
    public partial class Trocoform : Form {
        public Trocoform() {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e) {
            decimal valorCompra = Convert.ToDecimal(valorCompraTextBox.Text);
            decimal valorPago = Convert.ToDecimal(valorPagoTextBox.Text);

            decimal troco = valorPago - valorCompra;

            trocoTextBox.Text = troco.ToString("C");

            //Convert - Arredonda.
            //var moeda1Real = Convert.ToInt32(troco);

            var moedas = new decimal[] { 1 , 0.5m, 0.25m, 0.10m, 0.05m, 0.01m };

            for (int i = 0; i < moedas.Length; i++) {
                moedasListView.Items[i].Text = ((int)(troco / moedas[i])).ToString();
                troco %= moedas[i];
            }

            //var j = 0;            
            //foreach (var moeda in moedas) {
            //    moedasListView.Items[j++].Text = ((int)(troco / moeda)).ToString();
            //    troco %= moeda;
            //}


            //var moeda1Real = (int)(troco / 1);
            ////troco = troco % 1;
            //troco %= 1;

            //var moeda50 = (int)(troco / 0.5m);
            //troco %= 0.5m;

            //var moeda25 = (int)(troco / 0.25m);
            //troco %= 0.25m;

            //var moeda10 = (int)(troco / 0.10m);
            //troco %= 0.10m;

            //var moeda5 = (int)(troco / 0.05m);
            //troco %= 0.05m;

            //var moeda1 = (int)(troco / 0.01m);
            //troco %= 0.01m;

            ////var meuInteiro = int.Parse(troco);

            //// ToDo: refatorar para usar vetor e for / RESOLVIDO! REFATORADO COM SUCESSO UTILIZANDO VETORES E ESTRUTURAS DE REPETIÇÃO.
            //moedasListView.Items[0].Text = moeda1Real.ToString();
            //moedasListView.Items[1].Text = moeda50.ToString();
            //moedasListView.Items[2].Text = moeda25.ToString();
            //moedasListView.Items[3].Text = moeda10.ToString();
            //moedasListView.Items[4].Text = moeda5.ToString();
            //moedasListView.Items[5].Text = moeda1.ToString();

        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
    }
}
