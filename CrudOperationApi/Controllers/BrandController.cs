using CrudOperationApi.Data;
using CrudOperationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BrandController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult PostBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return Ok("Added Suc");
        }
        [HttpGet]
        public IActionResult GetBrand()
        {
            var data=_context.Brands.ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetBrandId(int id)
        {
            var brand =_context.Brands.Find(id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }
        [HttpPut("{BrandId}")]
        public IActionResult EditBrand(Brand brand)
        {
            var update = _context.Brands.FirstOrDefault(x=>x.BrandId == brand.BrandId);
            update.BrandName = brand.BrandName;
            update.BrandPrice = brand.BrandPrice;
            _context.SaveChanges();
            return Ok("Brand Edited Successfully"); 
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            var data = _context.Brands.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(data);
            _context.SaveChanges();

            return Ok("Deleted Successfully");
        }
    }
}
