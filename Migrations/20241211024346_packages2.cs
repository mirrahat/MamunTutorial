using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MamunTutorial.Migrations
{
    /// <inheritdoc />
    public partial class packages2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PackagesPackageId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalClasses = table.Column<int>(type: "int", nullable: false),
                    TotalBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDisCount = table.Column<bool>(type: "bit", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PackagesPackageId",
                table: "Teachers",
                column: "PackagesPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Packages_PackagesPackageId",
                table: "Teachers",
                column: "PackagesPackageId",
                principalTable: "Packages",
                principalColumn: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Packages_PackagesPackageId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_PackagesPackageId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PackagesPackageId",
                table: "Teachers");
        }
    }
}
