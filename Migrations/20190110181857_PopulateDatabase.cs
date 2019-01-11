using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersAPI.Migrations
{
  public partial class PopulateDatabase : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("INSERT INTO Users(Name, Password, Email) VALUES('Joao', '123456', 'joao@teste.com')");
      migrationBuilder.Sql("INSERT INTO Users(Name, Password, Email) VALUES('gilmar', '123456', 'gilmar@teste.com')");
      migrationBuilder.Sql("INSERT INTO Users(Name, Password, Email) VALUES('maria', '123456', 'maria@teste.com')");
      migrationBuilder.Sql("INSERT INTO Users(Name, Password, Email) VALUES('Ronilda', '123456', 'Ronilda@teste.com')");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("DELETE FROM TASKS");

    }
  }
}
