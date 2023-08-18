using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace carrentalapp.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_nm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_brnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_model = table.Column<int>(type: "int", nullable: true),
                    car_milage = table.Column<int>(type: "int", nullable: true),
                    car_rate = table.Column<int>(type: "int", nullable: true),
                    car_varient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_ac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_no = table.Column<long>(type: "bigint", nullable: false),
                    user_nm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_zip = table.Column<int>(type: "int", nullable: true),
                    user_adhar = table.Column<long>(type: "bigint", nullable: true),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_no);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    booking_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rentalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    returndate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    car_id = table.Column<long>(type: "bigint", nullable: true),
                    user_no = table.Column<long>(type: "bigint", nullable: true),
                    ammt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_Bookings_Cars_car_id",
                        column: x => x.car_id,
                        principalTable: "Cars",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_user_no",
                        column: x => x.user_no,
                        principalTable: "Users",
                        principalColumn: "user_no");
                });

            migrationBuilder.CreateTable(
                name: "Cancels",
                columns: table => new
                {
                    booking_id = table.Column<long>(type: "bigint", nullable: false),
                    rentalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    returndate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    car_id = table.Column<long>(type: "bigint", nullable: true),
                    user_no = table.Column<long>(type: "bigint", nullable: true),
                    carid = table.Column<long>(type: "bigint", nullable: true),
                    user_no1 = table.Column<long>(type: "bigint", nullable: true),
                    ammt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancels", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_Cancels_Cars_carid",
                        column: x => x.carid,
                        principalTable: "Cars",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Cancels_Users_user_no1",
                        column: x => x.user_no1,
                        principalTable: "Users",
                        principalColumn: "user_no");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_car_id",
                table: "Bookings",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_user_no",
                table: "Bookings",
                column: "user_no");

            migrationBuilder.CreateIndex(
                name: "IX_Cancels_carid",
                table: "Cancels",
                column: "carid");

            migrationBuilder.CreateIndex(
                name: "IX_Cancels_user_no1",
                table: "Cancels",
                column: "user_no1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Cancels");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
