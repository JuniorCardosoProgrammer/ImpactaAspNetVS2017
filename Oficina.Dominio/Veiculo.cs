namespace Oficina.Dominio // o namespace é associado a prateleiras e as classes a livros para classificar e agrupar as informações que serão utilizadas.
{
    public class Veiculo
    {
        public string Placa { get; set; } // property/propriedade - atalho prop + tab + tab.
        public Modelo Modelo { get; set; } // é possível fatiar? Se sim : Criar uma classe para a entidade.
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; } // tem um número finito/pequeno de dados então utilizar enum.
        public Cambio Cambio { get; set; }
        public int Ano { get; set; }
        public string Observacao { get; set; }
    }
}
