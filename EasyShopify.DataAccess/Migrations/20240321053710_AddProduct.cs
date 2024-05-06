using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyShopify.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartCount = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShppingCartId);
                });
        }
    }
}
