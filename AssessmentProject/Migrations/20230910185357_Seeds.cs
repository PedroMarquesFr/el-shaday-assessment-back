using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssessmentProject.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonQualifications",
                columns: new[] { "Id", "QualificationName" },
                values: new object[,]
                {
                    { 1, "Cliente" },
                    { 2, "Fornecedor" },
                    { 3, "Colaborador" }
                });

            migrationBuilder.InsertData(
                table: "PersonRoles",
                columns: new[] { "Id", "RoleType" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Fisica" },
                    { 2, "Juridica" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Apelido", "CreatedAt", "Document", "Email", "IsActivated", "Name", "Password", "PersonAddress", "QualificationId", "RoleId", "TypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b407315e-e24d-4a8a-ba35-22fbf815011a"), "PersonOne", new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1104), "48750168088", "admin@admin.com", true, "Admin", "admin", "{\r\n  \"cep\": \"62040-020\",\r\n  \"logradouro\": \"Rua Raimundo Mendes Aguiar\",\r\n  \"complemento\": \"\",\r\n  \"bairro\": \"Coração de Jesus\",\r\n  \"localidade\": \"Sobral\",\r\n  \"uf\": \"CE\",\r\n  \"ibge\": \"2312908\",\r\n  \"gia\": \"\",\r\n  \"ddd\": \"88\",\r\n  \"siafi\": \"1559\"\r\n}", 3, 2, 1, new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1106) },
                    { new Guid("c6725529-d519-43e5-9acd-eb47edebf4f0"), "PersonTwo", new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1137), "82416611003", "person1@example.com", true, "Person 1", "password1", "{\r\n  \"cep\": \"62040-020\",\r\n  \"logradouro\": \"Rua Raimundo Mendes Aguiar\",\r\n  \"complemento\": \"\",\r\n  \"bairro\": \"Coração de Jesus\",\r\n  \"localidade\": \"Sobral\",\r\n  \"uf\": \"CE\",\r\n  \"ibge\": \"2312908\",\r\n  \"gia\": \"\",\r\n  \"ddd\": \"88\",\r\n  \"siafi\": \"1559\"\r\n}", 3, 1, 1, new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1137) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Name", "PersonId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4113635f-34cc-4165-913c-e66d831cb17d"), new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1153), "Department2", new Guid("b407315e-e24d-4a8a-ba35-22fbf815011a"), new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1154) },
                    { new Guid("99b9fa2b-97ef-41f1-8dfc-2c64ad6a6450"), new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1149), "Department1", new Guid("b407315e-e24d-4a8a-ba35-22fbf815011a"), new DateTime(2023, 9, 10, 18, 53, 56, 939, DateTimeKind.Utc).AddTicks(1152) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4113635f-34cc-4165-913c-e66d831cb17d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("99b9fa2b-97ef-41f1-8dfc-2c64ad6a6450"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("c6725529-d519-43e5-9acd-eb47edebf4f0"));

            migrationBuilder.DeleteData(
                table: "PersonQualifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonQualifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("b407315e-e24d-4a8a-ba35-22fbf815011a"));

            migrationBuilder.DeleteData(
                table: "PersonRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonQualifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
