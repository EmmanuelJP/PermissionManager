using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRM.Model.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    EmployeeFirstName = table.Column<string>(nullable: true),
                    EmployeeLastName = table.Column<string>(nullable: true),
                    PermissionDate = table.Column<DateTime>(nullable: false),
                    PermissionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionTypes_PermissionTypeId",
                        column: x => x.PermissionTypeId,
                        principalTable: "PermissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Description", "UpdatedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 2, 18, 21, 26, 18, 494, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, -4, 0, 0, 0)), false, "Enfermedad", null });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Description", "UpdatedDate" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 2, 18, 21, 26, 18, 496, DateTimeKind.Unspecified).AddTicks(1534), new TimeSpan(0, -4, 0, 0, 0)), false, "Diligencias", null });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "CreatedDate", "Deleted", "Description", "UpdatedDate" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2022, 2, 18, 21, 26, 18, 496, DateTimeKind.Unspecified).AddTicks(1557), new TimeSpan(0, -4, 0, 0, 0)), false, "Otros", null });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionTypeId",
                table: "Permissions",
                column: "PermissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionTypes");
        }
    }
}
