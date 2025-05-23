using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdventureWorksCore.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultMeasures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Production",
                table: "UnitMeasure",
                columns: new[] { "UnitMeasureCode", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { "BOX", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Boxes" },
                    { "BTL", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Bottle" },
                    { "C", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Celsius" },
                    { "CAN", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Canister" },
                    { "CAR", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Carton" },
                    { "CBM", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Cubic meters" },
                    { "CCM", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Cubic centimeter" },
                    { "CDM", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Cubic decimeter" },
                    { "CM", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Centimeter" },
                    { "CM2", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Square centimeter" },
                    { "CR", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Crate" },
                    { "CS", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Case" },
                    { "CTN", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Container" },
                    { "DM", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Decimeter" },
                    { "DZ", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Dozen" },
                    { "EA", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Each" },
                    { "FT3", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Cubic foot" },
                    { "G", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Gram" },
                    { "GAL", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Gallon" },
                    { "IN", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Inch" },
                    { "KG", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Kilogram" },
                    { "KGV", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Kilogram/cubic meter" },
                    { "KM", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Kilometer" },
                    { "KT", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Kiloton" },
                    { "L", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Liter" },
                    { "LB", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "US pound" },
                    { "M", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Meter" },
                    { "M2", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Square meter" },
                    { "M3", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Cubic meter" },
                    { "MG", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Milligram" },
                    { "ML", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Milliliter" },
                    { "MM", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Millimeter" },
                    { "OZ", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Ounces" },
                    { "PAK", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Pack" },
                    { "PAL", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Pallet" },
                    { "PC", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Piece" },
                    { "PCT", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Percentage" },
                    { "PT", new DateTime(2008, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Pint, US liquid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "BOX");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "BTL");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "C");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CAN");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CAR");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CBM");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CCM");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CDM");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CM");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CM2");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CR");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CS");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "CTN");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "DM");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "DZ");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "EA");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "FT3");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "G");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "GAL");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "IN");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "KG");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "KGV");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "KM");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "KT");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "L");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "LB");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "M");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "M2");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "M3");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "MG");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "ML");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "MM");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "OZ");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "PAK");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "PAL");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "PC");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "PCT");

            migrationBuilder.DeleteData(
                schema: "Production",
                table: "UnitMeasure",
                keyColumn: "UnitMeasureCode",
                keyValue: "PT");
        }
    }
}
