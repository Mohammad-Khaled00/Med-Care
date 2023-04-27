using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doctor_Appointment.Migrations
{
    /// <inheritdoc />
    public partial class DoctorRepoError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
               name: "dailyAvailbilities",
               columns: table => new
               {
                   Dayid = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   DoctorID = table.Column<int>(type: "int", nullable: false),
                   date = table.Column<DateTime>(type: "datetime2", nullable: false),
                   starttime = table.Column<TimeSpan>(type: "time", nullable: false),
                   endtime = table.Column<TimeSpan>(type: "time", nullable: false),
                   isavailable = table.Column<bool>(type: "bit", nullable: false),
                   AppointmentDoctorID = table.Column<int>(type: "int", nullable: true),
                   AppointmentPatientID = table.Column<int>(type: "int", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_dailyAvailbilities", x => x.Dayid);
                   table.ForeignKey(
                       name: "FK_dailyAvailbilities_Appointments_AppointmentDoctorID_AppointmentPatientID",
                       columns: x => new { x.AppointmentDoctorID, x.AppointmentPatientID },
                       principalTable: "Appointments",
                       principalColumns: new[] { "DoctorID", "PatientID" });
                   table.ForeignKey(
                       name: "FK_dailyAvailbilities_Doctors_DoctorID",
                       column: x => x.DoctorID,
                       principalTable: "Doctors",
                       principalColumn: "DoctorID",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateIndex(
                name: "IX_dailyAvailbilities_AppointmentDoctorID_AppointmentPatientID",
                table: "dailyAvailbilities",
                columns: new[] { "AppointmentDoctorID", "AppointmentPatientID" });

            migrationBuilder.CreateIndex(
                name: "IX_dailyAvailbilities_DoctorID",
                table: "dailyAvailbilities",
                column: "DoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
