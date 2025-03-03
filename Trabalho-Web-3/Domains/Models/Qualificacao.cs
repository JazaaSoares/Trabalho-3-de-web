﻿namespace Trabalho_Web_3.Domains.Models
{
    public class Qualificacao : BaseEntity
    {
        public Qualificacao(string titulo, string descricao, DateTime data)
        {
            Id = Guid.NewGuid().ToString("N");
            Titulo = titulo;
            Descricao = descricao;
            Data = data;
            CreatedAt = DateTime.Now;
        }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }
    }
}
