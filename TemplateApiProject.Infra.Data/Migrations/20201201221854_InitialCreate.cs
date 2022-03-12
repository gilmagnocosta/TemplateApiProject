using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TemplateApiProject.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archive",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ArchiveType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormattedAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documentation_CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documentation_RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Archive_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Archive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Profile = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfessionalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasAcademicFormation = table.Column<bool>(type: "bit", nullable: false),
                    EducationalInstitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professional_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Professional_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalServiceType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionTime = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalServiceType", x => x.Id);
                    table.UniqueConstraint("AK_ProfessionalServiceType_ProfessionalId_ServiceTypeId", x => new { x.ProfessionalId, x.ServiceTypeId });
                    table.ForeignKey(
                        name: "FK_ProfessionalServiceType_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalServiceType_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfessionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Text = table.Column<decimal>(type: "decimal(18,2)", maxLength: 500, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workday",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    InitialTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workday_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfessionalServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CheckinAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_ProfessionalServiceType_ProfessionalServiceTypeId",
                        column: x => x.ProfessionalServiceTypeId,
                        principalTable: "ProfessionalServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Birthdate", "CreatedAt", "CreatedBy", "FirstName", "Gender", "IsActive", "LastName", "PhotoId", "UpdatedAt", "UpdatedBy", "Address_City", "Address_Country", "Address_Neighborhood", "Address_Number", "Address_State", "Address_Street", "Address_ZipCode", "Contact_CellPhone", "Contact_Email", "Contact_Facebook", "Contact_Instagram", "Contact_PhoneNumber", "Contact_Twitter", "Documentation_CPF", "Documentation_RG" },
                values: new object[] { new Guid("5cafc63f-4bf4-46f5-9615-d343f34071e9"), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 12, 1, 19, 18, 52, 476, DateTimeKind.Local).AddTicks(9680), null, "User", 1, true, "Admin", null, null, null, "Admin", "Brazil", "Admin", "0", "Admin", "Admin", "00000-000", null, "admin@admin.com", null, null, null, null, "00000000000", "000000000" });

            migrationBuilder.InsertData(
                table: "ServiceType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "ImageName", "IsActive", "Name", "ShortName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("86e5a351-1ca3-44b9-bf10-9ed5f4b469b0"), new DateTime(2020, 12, 1, 19, 18, 52, 502, DateTimeKind.Local).AddTicks(9746), null, "Serviços de Fisioterapia", "ic_fisio", true, "Fisioterapia", "Fisio", null, null });

            migrationBuilder.InsertData(
                table: "ServiceType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "ImageName", "IsActive", "Name", "ShortName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("c5dc9e0c-9f55-4858-a469-2a9c49bc9235"), new DateTime(2020, 12, 1, 19, 18, 52, 503, DateTimeKind.Local).AddTicks(3404), null, "Serviços de Massoterapia", "ic_masso", true, "Massoterapia", "Masso", null, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "Password", "PersonId", "Profile", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[] { new Guid("776ad1e3-ed08-4df7-9d0e-b422c0b2150b"), new DateTime(2020, 12, 1, 19, 18, 52, 505, DateTimeKind.Local).AddTicks(3929), null, true, "AP8VfOkvQciXQkRl6DqkOPrcHfe7ycNGCkSm8ynYjnqP", new Guid("5cafc63f-4bf4-46f5-9615-d343f34071e9"), 1, null, null, "admin@admin.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_OrderId",
                table: "Appointment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ProfessionalServiceTypeId",
                table: "Appointment",
                column: "ProfessionalServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PersonId",
                table: "Patient",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PhotoId",
                table: "Person",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professional_PatientId",
                table: "Professional",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Professional_PersonId",
                table: "Professional",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalServiceType_ServiceTypeId",
                table: "ProfessionalServiceType",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProfessionalId",
                table: "Review",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workday_ProfessionalId",
                table: "Workday",
                column: "ProfessionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Workday");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProfessionalServiceType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Professional");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Archive");
        }
    }
}
