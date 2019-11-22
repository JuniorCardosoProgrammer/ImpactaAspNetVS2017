﻿namespace Pessoal.Dominio.Entidades
{
    public class Tarefa
    {
        //Página 61 (Apostila 2)
        public int? Id { get; set; }
        public string Nome { get; set; }
        public Prioridade Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Observacoes { get; set; }
    }
}