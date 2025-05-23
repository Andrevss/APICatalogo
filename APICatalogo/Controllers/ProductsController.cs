﻿using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
         public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products.ToList();
            if(products is null)
            {
               return NotFound("Produtos não encontrados");
            }
            return products;
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Product> Get(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound("Produto não encontrado");
            }
            return product;
        }
        [HttpPost]
        public ActionResult Post(Product product)
        {
            if(product == null) 
            {
                return BadRequest("Produto inválido");
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id= product.ProductId }, product);

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product)
        {
            if(id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }

    }
}
