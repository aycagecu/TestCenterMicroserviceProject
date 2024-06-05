using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataWebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDevice_BaseProcess_BaseProcessId",
                table: "BaseDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProcess_TestCenter_TestCenterId",
                table: "BaseProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_BaseDevice_BaseDeviceId",
                table: "Register");

            migrationBuilder.RenameColumn(
                name: "BaseDeviceId",
                table: "Register",
                newName: "baseDeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_Register_BaseDeviceId",
                table: "Register",
                newName: "IX_Register_baseDeviceId");

            migrationBuilder.RenameColumn(
                name: "TestCenterId",
                table: "BaseProcess",
                newName: "testCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProcess_TestCenterId",
                table: "BaseProcess",
                newName: "IX_BaseProcess_testCenterId");

            migrationBuilder.RenameColumn(
                name: "BaseProcessId",
                table: "BaseDevice",
                newName: "baseProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDevice_BaseProcessId",
                table: "BaseDevice",
                newName: "IX_BaseDevice_baseProcessId");

            migrationBuilder.AlterColumn<int>(
                name: "baseDeviceId",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "testCenterId",
                table: "BaseProcess",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "baseProcessId",
                table: "BaseDevice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "port",
                table: "BaseDevice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "slaveId",
                table: "BaseDevice",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDevice_BaseProcess_baseProcessId",
                table: "BaseDevice",
                column: "baseProcessId",
                principalTable: "BaseProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProcess_TestCenter_testCenterId",
                table: "BaseProcess",
                column: "testCenterId",
                principalTable: "TestCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_BaseDevice_baseDeviceId",
                table: "Register",
                column: "baseDeviceId",
                principalTable: "BaseDevice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDevice_BaseProcess_baseProcessId",
                table: "BaseDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProcess_TestCenter_testCenterId",
                table: "BaseProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_BaseDevice_baseDeviceId",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "port",
                table: "BaseDevice");

            migrationBuilder.DropColumn(
                name: "slaveId",
                table: "BaseDevice");

            migrationBuilder.RenameColumn(
                name: "baseDeviceId",
                table: "Register",
                newName: "BaseDeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_Register_baseDeviceId",
                table: "Register",
                newName: "IX_Register_BaseDeviceId");

            migrationBuilder.RenameColumn(
                name: "testCenterId",
                table: "BaseProcess",
                newName: "TestCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseProcess_testCenterId",
                table: "BaseProcess",
                newName: "IX_BaseProcess_TestCenterId");

            migrationBuilder.RenameColumn(
                name: "baseProcessId",
                table: "BaseDevice",
                newName: "BaseProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDevice_baseProcessId",
                table: "BaseDevice",
                newName: "IX_BaseDevice_BaseProcessId");

            migrationBuilder.AlterColumn<int>(
                name: "BaseDeviceId",
                table: "Register",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TestCenterId",
                table: "BaseProcess",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BaseProcessId",
                table: "BaseDevice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDevice_BaseProcess_BaseProcessId",
                table: "BaseDevice",
                column: "BaseProcessId",
                principalTable: "BaseProcess",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProcess_TestCenter_TestCenterId",
                table: "BaseProcess",
                column: "TestCenterId",
                principalTable: "TestCenter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_BaseDevice_BaseDeviceId",
                table: "Register",
                column: "BaseDeviceId",
                principalTable: "BaseDevice",
                principalColumn: "Id");
        }
    }
}
