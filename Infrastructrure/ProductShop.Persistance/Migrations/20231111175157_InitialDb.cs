using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Intel Celeron N4500 Jasper Lake", "https://image.alza.cz/products/NC027p0u0/NC027p0u0.jpg?width=500&height=500", "Acer Aspire 3 ", 6999m },
                    { 2, "128GB", "https://image.alza.cz/products/RI041b1/RI041b1.jpg?width=500&height=500", "iPhone 14 ", 18990m },
                    { 3, "20W Charger", "https://image.alza.cz/products/RI012i1b48/RI012i1b48.jpg?width=500&height=500", "Apple 20W USB-C", 589m },
                    { 4, "Závodní auto McLaren Formule 1", "https://image.alza.cz/products/LO42141/LO42141.jpg?width=500&height=500", "LEGO Technic", 3119m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
