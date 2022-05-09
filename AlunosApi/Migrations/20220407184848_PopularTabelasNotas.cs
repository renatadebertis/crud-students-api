using Microsoft.EntityFrameworkCore.Migrations;

namespace AlunosApi.Migrations
{
    public partial class PopularTabelasNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Nome" },
                values: new object[] { "joana@gmail.com", "Joana Siqueira" });

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Idade", "Nome" },
                values: new object[] { "carolina@gmail.com", 34, "Carolina Nascimento" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Matemática" },
                    { 2, "Inglês" }
                });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "IdNotas", "AlunoId", "IdAluno", "IdDisciplina" },
                values: new object[,]
                {
                    { 1, null, 1, 2 },
                    { 2, null, 1, 1 },
                    { 3, null, 2, 2 },
                    { 4, null, 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Nome" },
                values: new object[] { "mariapenha@yahoo.com", "Maria da Penha" });

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Idade", "Nome" },
                values: new object[] { "manuelbueno@yahoo.com", 22, "Manuel Bueno" });
        }
    }
}
