using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO - Classe ou abstração.
    public abstract class Veiculo
    {
        private string placa;
        // get e set são métodos.
        //propriedades aceitam métodos dentro de delas.
        // maneira errada de usar encapsulamento.
        public string Placa {
            get {
                //todo get tem return.
                return placa.ToUpper();
            }
            set {
                //todo set tem value.
                 placa = value.ToUpper();
            }
        }

        //public string Placa { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
        public int Ano { get; set; }
        public string Observacao { get; set; }

        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            //Para validar um enumerador usasse IsDefined().
            if (!Enum.IsDefined(typeof(Combustivel), Combustivel))
            {
                erros.Add($"O Combustível {Combustivel} não é válido.");
            }

            if (!Enum.IsDefined(typeof(Cambio), Cambio))
            {
                erros.Add($"O Câmbio {Cambio} não é válido.");
            }

            return erros;
        }

        //Para impor as classes derivadas a definir este método dentro delas.
        public abstract List<string> Validar();
    }
    
}