using demoMongoDB.Models;
using demoMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProdutosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _ProdutoService;

        public ProdutosController(ProdutoService ProdutoService)
        {
            _ProdutoService = ProdutoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get() =>
            _ProdutoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProduto")]
        public ActionResult<Produto> Get(string id)
        {
            var Produto = _ProdutoService.Get(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Produto;
        }

        [HttpPost]
        public ActionResult<Produto> Create(Produto Produto)
        {
            _ProdutoService.Create(Produto);

            return CreatedAtRoute("GetProduto", new { id = Produto.Id.ToString() }, Produto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Produto ProdutoIn)
        {
            var Produto = _ProdutoService.Get(id);

            if (Produto == null)
            {
                return NotFound();
            }

            _ProdutoService.Update(id, ProdutoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Produto = _ProdutoService.Get(id);

            if (Produto == null)
            {
                return NotFound();
            }

            _ProdutoService.Remove(Produto.Id);

            return NoContent();
        }
    }
}