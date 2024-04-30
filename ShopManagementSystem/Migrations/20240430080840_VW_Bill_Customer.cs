using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class VW_Bill_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create View VW_Bill_Customer
                                   As
                                   Select BillingDate,Amount,PaymentMode,CustomerName from Billings b
                                   inner join Customers c
                                        on b.CustomerId = c.Id"
                                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop View VW_Bill_Customer");
        }
    }
}
