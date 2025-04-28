using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Categorie>> GetCategoriesProducts()
        {
            return _context.Categories.Include(p=> p.Products).ToList();

        }

        [HttpGet]
        public ActionResult<IEnumerable<Categorie>> Get()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categorie> Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategorieId == id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Categorie category)
        {
            if (category == null)
            {
                return BadRequest("Categoria inválida");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = category.CategorieId }, category);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Categorie category)
        {
            if (id != category.CategorieId)
            {
                return BadRequest("Categoria inválida");
            }
            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategorieId == id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(new { message = "Categoria removida com sucesso" });
        }
    }
}
