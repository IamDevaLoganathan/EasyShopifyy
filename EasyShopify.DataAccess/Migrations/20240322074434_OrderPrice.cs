using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyShopify.Migrations
{
    /// <inheritdoc />
    public partial class OrderPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderPrice",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "ShoppingCarts");
        }
    }
}
