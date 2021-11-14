using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMPrakticniZadatak.DAL.Migrations
{
    public partial class Data_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Manufacturer", "Name", "Price", "Supplier" },
                values: new object[,]
                {
                    { new Guid("0708fdb5-b6f3-401b-a9d7-54aa8872c8cd"), "Uredski pribor", "Pakovanje A4 papira za print, 500 kom, 80g", "Double A", "A4 papir", 895.99m, "Dobavljac 1" },
                    { new Guid("0df7071e-a1b9-4ae0-a4e5-0e8b768ef23e"), "Uredski pribor", "Makaze za papir", "Maped", "Makaze", 569.99m, "Dobavljac 1" },
                    { new Guid("857de063-30fb-4594-aedd-a9862c6eae6f"), "Uredski pribor", "Hemijska olovka, 0.5mm, plava", "Pilot", "Hemijska olovka", 1099.99m, "Dobavljac 1" },
                    { new Guid("8e358a35-3974-4ece-9b9b-264afd4a8078"), "Uredski pribor", "Tehnicka olovka, 0.7mm", "Rotring", "Tehnicka olovka", 1299.99m, "Dobavljac 1" },
                    { new Guid("948382ff-d18c-4706-8218-0a0fb09ea916"), "Uredski pribor", "Heftalica", "Maped", "Heftalica", 779.99m, "Dobavljac 1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0708fdb5-b6f3-401b-a9d7-54aa8872c8cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0df7071e-a1b9-4ae0-a4e5-0e8b768ef23e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("857de063-30fb-4594-aedd-a9862c6eae6f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8e358a35-3974-4ece-9b9b-264afd4a8078"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("948382ff-d18c-4706-8218-0a0fb09ea916"));
        }
    }
}
