using Dapper.Application.Interfaces;
using Dapper.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.E_Order.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var data = await unitOfWork.E_Order.GetByIdAsync(orderId);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(E_Order order)
        {
            var data = await unitOfWork.E_Order.AddAsync(order);
            return Ok(data);
        }

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> AddList(List<E_Order> order)
        {
            await unitOfWork.E_Order.AddListAsync(order);
            return Ok(1);
            //return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int orderId)
        {
            var data = await unitOfWork.E_Order.DeleteAsync(orderId);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(E_Order order)
        {
            var data = await unitOfWork.E_Order.UpdateAsync(order);
            return Ok(data);
        }
    }

}
