using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaivoa.CesarRamos;

namespace VaiVoa.CesarRamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaCartoesController : ControllerBase
    {
        private readonly SqlContext _context;

        public PessoaCartoesController(SqlContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public ListaPessoaCartaoResponse Get(string email)
        {
            Repositorio repositorio = new Repositorio(_context);

            var result = repositorio.ListarPesspasCartoes(email);

            return result;
        }


        [HttpPost]
        public PessoaCartaoResponse Post([FromBody] string email)
        {
            Repositorio repositorio = new Repositorio(_context);

            var resultado = repositorio.AdicionarPessoaCartao(email);

            return resultado;

        }

    }
}
