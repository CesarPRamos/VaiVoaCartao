
using System;
using System.Collections.Generic;
using System.Linq;
using Vaivoa.CesarRamos;

namespace VaiVoa.CesarRamos
{
    public class Repositorio
    {
        private readonly SqlContext context;

        public Repositorio(SqlContext _context)
        {
            context = _context;
        }


        public PessoaCartaoResponse AdicionarPessoaCartao(string email)
        {

            var rand = new Random();
            var randCard = "4990.5102" + rand.Next(0, 999).ToString() + "." + rand.Next(0, 999).ToString();

            var pessoa = new PessoaCartao()
            {
                DataCriacao = DateTime.Now,
                Email = email,
                NumeroCartaoVirtual = randCard

            };
            context.Add(pessoa);
            context.SaveChanges();

            return new PessoaCartaoResponse()
            {
                Email = pessoa.Email,
                NumeroCartaoVirtual = randCard
            };


        }

        public ListaPessoaCartaoResponse ListarPesspasCartoes(string email)
        {
            var lista = new List<PessoaInformacao>();
            var resultado = context.PessoaCartoes.Where(x => x.Email == email)
                .OrderBy(x => x.DataCriacao)
                .ToList();

            foreach (var p in resultado)
            {
                var pessoa = new PessoaInformacao()
                {
                    Email = p.Email,
                    DataCriacao = p.DataCriacao,
                    NumeroCartaoVirtual = p.NumeroCartaoVirtual
                };
                lista.Add(pessoa);
            }

            return new ListaPessoaCartaoResponse() { Informe = lista };

        }
    }
}
