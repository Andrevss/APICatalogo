using System.Collections.ObjectModel;

namespace APICatalogo.Models
{
    public class Categorie
    {
        public Categorie()
        {
            Products = new Collection<Product>();
        }
        public int CategorieId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
