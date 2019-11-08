using System.Collections.Generic;

namespace Oficina.Dominio
{
    public class Motocicleta : Veiculo
    {
        public TipoQuadro TipoQuadro { get; set; }

        //override define o metodo herdado.
        public override List<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
