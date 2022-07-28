using Dapper.Application.Interfaces;
using Dapper.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.E_Product.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var data = await unitOfWork.E_Product.GetByIdAsync(productId);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet("{categoryId}&{sizeId}&{colorId}")]
        public async Task<IActionResult> GetByFilters(int categoryId, int sizeId, int colorId)
        {
            var data = await unitOfWork.E_Product.GetByFilterAsync(categoryId, sizeId, colorId);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(E_Product product)
        {
            var data = await unitOfWork.E_Product.AddAsync(product);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            var data = await unitOfWork.E_Product.DeleteAsync(productId);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(E_Product product)
        {
            var data = await unitOfWork.E_Product.UpdateAsync(product);
            return Ok(data);
        }
    }
}
