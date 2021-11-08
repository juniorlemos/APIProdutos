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
        public async Task<ActionResult> SelectByIdAsync(int id)
        {

            var produto = await _applicationServiceProduto.SelectByIdAsync(id);

            if (produto == null)
                return NotFound("Produto com esse código não existe");


                return Ok(produto);
        }


        [HttpGet("{page}/{itens}")]
        public async Task<ActionResult> SelectAllAsync([FromRoute]int page=1,[FromRoute]int itens =10)
        {
            if (page <= 0)
                page = 1;
            

            var produtos = await _applicationServiceProduto.SelectAllAsync(page,itens);
       
            return Ok( produtos);
        }



        [HttpPost]
        public async Task <ActionResult> InsertAsync([FromBody] ProdutoDto produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

               
               
                await _applicationServiceProduto.InsertAsync(produtoDTO);
                return Ok("O produto foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {

               var response = ex.Message;

                return StatusCode((int)HttpStatusCode.InternalServerError, response);
               
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProdutoDto produtoDTO)
        {

            try
            {
                if (produtoDTO == null)
                    return NotFound();

                await _applicationServiceProduto.UpdateAsync(produtoDTO);
                return Ok("O produto foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete()]
        public async Task <ActionResult> DeleteAsync(int id)
        {
            try
            {


                await _applicationServiceProduto.DeleteAsync(id);
                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
