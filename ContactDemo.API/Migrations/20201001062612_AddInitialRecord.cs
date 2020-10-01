using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactDemo.API.Migrations
{
    public partial class AddInitialRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Contact(Name,JobTitle,Company,PhoneNo,Email,Address,LastDateConnected) " +
                "values('Steve Smith','CEO','Microsoft','111-222-3333','steve.smith@microsoft.com','NewYork, USA','2020-08-23')");
            migrationBuilder.Sql("insert into Contact(Name,JobTitle,Company,PhoneNo,Email,Address,LastDateConnected) " +
                "values('John Stones','Vice-President','Disney','222-333-4444','johnstones@disney.com','NewYork, USA','2020-09-09')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Contact");
        }
    }
}
