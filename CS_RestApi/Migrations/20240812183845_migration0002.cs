using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS_RestApi.Migrations
{
    /// <inheritdoc />
    public partial class migration0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderNumber",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderNumber",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderNumber",
                table: "Orders",
                column: "OrderNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemId",
                table: "OrderItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order",
                table: "OrderItems",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderNumber",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderNumber",
                table: "OrderItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderNumber",
                table: "OrderItems",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber");
        }
    }
}
