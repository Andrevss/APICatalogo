﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categories(Name, ImageUrl) Values('Bebidas', 'bebidas.jpg')");
            mb.Sql("Insert into Categories(Name, ImageUrl) Values('Eletronicos', 'eletronicos.jpg')");
            mb.Sql("Insert into Categories(Name, ImageUrl) Values('Drinks', 'drinks.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categories");
        }
    }
}
