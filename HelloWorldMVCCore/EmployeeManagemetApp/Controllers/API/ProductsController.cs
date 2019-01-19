using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Contracts;
using EmployeeManagement.Models.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagemetApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            this._productManager = productManager;
        }

        

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productManager.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "ProductGetById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post( Product product)
        {
            if (ModelState.IsValid)
            {
               var isAdded =  _productManager.Add(product);
                if (isAdded)
                {
                    return Ok(product);
                }
            }
            return BadRequest();
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
