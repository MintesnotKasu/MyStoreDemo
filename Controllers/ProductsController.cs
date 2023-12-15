using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                var response = await _repo.GetProductByIdAsync(id);

                if (response == null)
                {
                    return NotFound($"Record Not Found with Id {id}");
                }

                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }

        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            try
            {
                var productList = await _repo.GetAllProductsAsync();

                if (productList.Count == 0)
                {
                    return NoContent();
                }

                return Ok(productList);

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);

            }
           
        }            
        
    }
}
