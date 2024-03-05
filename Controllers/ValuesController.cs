using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication90.Models;

namespace WebApplication90.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProdectContext _context;
        public ValuesController(ProdectContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _context.Products.ToList();
                if (products.Count == 0)
                {
                    return NotFound("Product Not available");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _context.Products.Find(id);

                if (product == null)
                {
                    return NotFound($"Product details not found with{id}");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public IActionResult Post(Product model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Product Created");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Product model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("model data is invalid");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"product Id{model.Id} is invalid");
                }

            }
            try
            {
                var product = _context.Products.Find(model.Id);
                if (product == null)
                {

                    return BadRequest($"product not found with id{model.Id}");
                }
                product.Productname = model.Productname;
                product.Price = model.Price;
                product.Qty = model.Qty;
                _context.SaveChanges();
                return Ok("product detail Updated");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {

                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"product is not found with id {id}");
                }

                    _context.SaveChanges();
                    return Ok("product details delete");
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
    }

