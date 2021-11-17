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

namespace APIProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutosController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetId(int id)
        {

            var produto = await _applicationServiceProduto.SelectByIdAsync(id);

            if (produto == null)
                return NotFound("Produto com esse código não existe");


                return Ok(produto);
        }


        [HttpGet("{page}/{itens}")]
        public async Task<ActionResult> GetAll([FromRoute]int page=1,[FromRoute]int itens =10)
        {
            if (page <= 0)
                page = 1;
            

            var produtos = await _applicationServiceProduto.SelectAllAsync(page,itens);
       
            return Ok( produtos);
        }



        [HttpPost]
        public async Task <ActionResult> Post([FromBody] ProdutoDto produtoDTO)
        {
           
                
                   
                       var produto = await _applicationServiceProduto.InsertAsync(produtoDTO);
                       
            
            
            return CreatedAtAction(nameof(GetId),new { id = produto.Id},produto);
                  
            
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AlteraProdutoDto produtoDTO)
        {

          

               
              var produto = await _applicationServiceProduto.UpdateAsync(produtoDTO);


            if (produto == null) {


                return NotFound();
            }
            
            return Ok(produto);
              
                
         
        }
        [HttpDelete()]
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
