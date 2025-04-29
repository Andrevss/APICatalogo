using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Product(Name, Description, Price, Stock, ImageUrl, DateRegistration, CategorieId) Values('Cerveja', 'Cerveja gelada', 5.50, 10, 'cerveja.jpg', now(), 1)");
            mb.Sql("Insert into Product(Name, Description, Price, Stock, ImageUrl, DateRegistration, CategorieId) Values('Refrigerante', 'Refrigerante gelado', 4.50, 20, 'refrigerante.jpg', now(), 1)");
            mb.Sql("Insert into Product(Name, Description, Price, Stock, ImageUrl, DateRegistration, CategorieId) Values('Smartphone', 'Smartphone de última geração', 1500.00, 5, 'smartphone.jpg', now(), 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Product");
        }
    }
}
