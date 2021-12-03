using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Application.DTOs;
using Modelo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canducci.Pagination;
using System.Net;
using Modelo.Domain.Entities;
using Modelo.Application.DTOs.ModelView;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace APIProduto.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(IApplicationServiceProduto applicationServiceProduto, ILogger<ProdutosController> logger)
        {
            _applicationServiceProduto = applicationServiceProduto;
            _logger = logger;
        }

        /// <summary>
        /// Retorna um produto consultado pelo id.
        /// </summary>
        /// <param name="id" example="1">Id do produto.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetId(int id)
        {

            var produto = await _applicationServiceProduto.SelectByIdAsync(id);

            if (produto == null)
                return NotFound("Produto com esse código não existe");


                return Ok(produto);
        }

        /// <summary>
        /// Retorna todos produtos cadastrados na base.
        /// </summary>
        [HttpGet("{page}/{itens}")]
        [ProducesResponseType(typeof(ProdutoView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll([FromRoute]int page=1,[FromRoute]int itens =10)
        {
            if (page <= 0)
                page = 1;
            

            var produtos = await _applicationServiceProduto.SelectAllAsync(page,itens);
       
            return Ok( produtos);
        }


        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <param name="produtoDTO"></param>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutoView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult> Post([FromBody] ProdutoDto produtoDTO)
        {
           
                
                   
                       var produto = await _applicationServiceProduto.InsertAsync(produtoDTO);
                       
            
            
            return CreatedAtAction(nameof(GetId),new { id = produto.Id},produto);
                  
            
        }

        /// <summary>
        /// Altera um produto.
        /// </summary>
        /// <param name="produtoDTO"></param>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutoView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromBody] AlteraProdutoDto produtoDTO)
        {

          

               
              var produto = await _applicationServiceProduto.UpdateAsync(produtoDTO);


            if (produto == null) {


                return NotFound();
            }
            
            return Ok(produto);
              
                
         
        }

        /// <summary>
        /// Exclui um produto.
        /// </summary>
        /// <param name="id" example="1">Id do produto</param>
        /// <remarks>Ao excluir um produto o mesmo será removido permanentemente da base.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult> Delete(int id)
        {
            
            
           var produtoExcluido = await _applicationServiceProduto.DeleteAsync(id);
            if (produtoExcluido != null)
            {

                return NoContent();

            }
            return NotFound();

        }
    }
}
