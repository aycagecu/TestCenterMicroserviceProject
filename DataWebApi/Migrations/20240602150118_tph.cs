using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataWebApi.Migrations
{
    /// <inheritdoc />
    public partial class tph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseProcess_TestCenter_TestCenterId",
                        column: x => x.TestCenterId,
                        principalTable: "TestCenter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ipAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseProcessId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseDevice_BaseProcess_BaseProcessId",
                        column: x => x.BaseProcessId,
                        principalTable: "BaseProcess",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isWritable = table.Column<bool>(type: "bit", nullable: false),
                    isReadable = table.Column<bool>(type: "bit", nullable: false),
                    BaseDeviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Register_BaseDevice_BaseDeviceId",
                        column: x => x.BaseDeviceId,
                        principalTable: "BaseDevice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseDevice_BaseProcessId",
                table: "BaseDevice",
                column: "BaseProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProcess_TestCenterId",
                table: "BaseProcess",
                column: "TestCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_BaseDeviceId",
                table: "Register",
                column: "BaseDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "BaseDevice");

            migrationBuilder.DropTable(
                name: "BaseProcess");

            migrationBuilder.DropTable(
                name: "TestCenter");
        }
    }
}
