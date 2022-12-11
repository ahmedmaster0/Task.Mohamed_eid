using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class create_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IBAN = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionsEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iqama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BankTypesId = table.Column<int>(type: "int", nullable: false),
                    DamageTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPersons_BankType_BankTypesId",
                        column: x => x.BankTypesId,
                        principalTable: "BankType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPersons_DamageType_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPersonsId = table.Column<int>(type: "int", nullable: false),
                    RegionsId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaQuarter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsurranceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationData_DataPersons_DataPersonsId",
                        column: x => x.DataPersonsId,
                        principalTable: "DataPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationData_RegionsEntity_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "RegionsEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankType",
                columns: new[] { "Id", "IBAN", "Name" },
                values: new object[,]
                {
                    { 1, "SA3456789456123456789123", "البنك الاهلي السعودي" },
                    { 2, "SA3456789456123456789188", "بنك الرياض" }
                });

            migrationBuilder.InsertData(
                table: "DamageType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مركبة" },
                    { 2, "افراد" },
                    { 3, "اخري" }
                });

            migrationBuilder.InsertData(
                table: "RegionsEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "مكه المكرمة" },
                    { 2, "المدينة المنوره" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankType_IBAN",
                table: "BankType",
                column: "IBAN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataPersons_BankTypesId",
                table: "DataPersons",
                column: "BankTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPersons_DamageTypeId",
                table: "DataPersons",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationData_DataPersonsId",
                table: "LocationData",
                column: "DataPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationData_RegionsId",
                table: "LocationData",
                column: "RegionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationData");

            migrationBuilder.DropTable(
                name: "DataPersons");

            migrationBuilder.DropTable(
                name: "RegionsEntity");

            migrationBuilder.DropTable(
                name: "BankType");

            migrationBuilder.DropTable(
                name: "DamageType");
        }
    }
}
