using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Common;
using API.Contracts;
using System.Collections.Generic;
using System;

namespace API
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        
        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var domainModels = await _service.GetAll();
            var viewModels = domainModels.Select(x => x.ToViewModel());
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadSingle(string id)
        {
            var domainModel = await _service.GetByID(id);
            return domainModel == null ? NotFound($"Product with the id {id} was not found.") : Ok(domainModel.ToViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateModel createModel)
        {
            if(ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                createModel.ProductID = obj.ToString();
            }

            var domainModel = createModel.ToDomain();
            var createdProduct = await _service.CreateNewProduct(domainModel);
            return createdProduct == null ? BadRequest("Product cannot be created.") : Ok(createdProduct.ToViewModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateModel updateModel)
        {
            var domainModel = updateModel.ToDomain();
            var updatedModel = await _service.UpdateProduct(domainModel);
            return updatedModel == null ? NotFound("Product cannot be updated. It doesnt exist in the database.") : Ok(updatedModel.ToViewModel());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deletedProduct = await _service.DeleteByID(id);
            return deletedProduct == null ? NotFound("Product cannot be deleted. It doesnt exist in the database.") : Ok(deletedProduct.ToViewModel());
        }
    }
}