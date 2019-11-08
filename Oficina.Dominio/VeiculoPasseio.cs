using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO - Herança.
    public class VeiculoPasseio : Veiculo
    {
        public TipoCarroceria TipoCarroceria { get; set; }

        //Polimorfismo por substituição.
        //(Quando a classe base define um método por abstract e a classe derivada substitui as ações usando o mesmo método usando override).
        //ToDo: OO - Polimorfismo po sobrescrita.
        public override List<string> Validar()
        {
            var erros = ValidarBase();

            if (!Enum.IsDefined(typeof(TipoCarroceria), Combustivel))
            {
                erros.Add($"A Carroceria {TipoCarroceria} não é válido.");
            }

            return erros;
        }
    }
}
