using System.Collections.Generic;

namespace Oficina.Dominio
{
    //acces modify - Modificador de acesso - define o escopo. obs: private não pode ser usado no nivel do namespace.
    //public - todas as classes podem acessar.
    //private - somente a classe pode acessar.
    //protected - as classes que herdam de outra classe podem acessar.
    //abstract - é usada em classes incompletas/abstratas e não permite que a classe base/pai seja instanciada.
    //criar uma classe dentro da outra não é uma boa prática de POO.
    //Aula 12 - Herança.
    public class Caminhao : Veiculo
    {
        public QuantidadeEixo QuantidadeEixo { get; set; }

        public override List<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
