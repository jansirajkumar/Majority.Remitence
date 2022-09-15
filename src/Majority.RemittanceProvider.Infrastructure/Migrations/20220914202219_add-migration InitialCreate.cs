using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Majority.RemittanceProvider.Infrastructure.Migrations
{
    public partial class addmigrationInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    BankCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => new { x.AccountNumber, x.BankCode });
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    BaseCurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DestinationCurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExchangeRateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    ExchangeRateToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => new { x.BaseCurrencyCode, x.DestinationCurrencyCode, x.IsActive });
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromAmount = table.Column<double>(type: "float", nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Fees = table.Column<double>(type: "float", nullable: false),
                    TransactionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "TransferModes",
                columns: table => new
                {
                    TransferModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferModeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferModeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferModes", x => x.TransferModeId);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MICRCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => new { x.BankCode, x.CountryCode });
                    table.ForeignKey(
                        name: "FK_Banks_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => new { x.Code, x.CountryCode });
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionSender",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderFromState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSender", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionSender_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTo",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToBankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToBankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToBankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToBankCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTo", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionTo_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeesDetails",
                columns: table => new
                {
                    FeesDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferModeId = table.Column<int>(type: "int", nullable: false),
                    FromCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeesPercentage = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesDetails", x => x.FeesDetailsId);
                    table.ForeignKey(
                        name: "FK_FeesDetails_TransferModes_TransferModeId",
                        column: x => x.TransferModeId,
                        principalTable: "TransferModes",
                        principalColumn: "TransferModeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Beneficiaries",
                columns: new[] { "AccountNumber", "BankCode", "BeneficiaryName" },
                values: new object[,]
                {
                    { "12345", "BOA", "Johny" },
                    { "12345", "HSB", "Robin" },
                    { "123456789", "BOA", "Rajkumar" },
                    { "123456789", "HSB", "Isebella" },
                    { "123456789", "WF", "Jansi" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "CurrencyCode", "IsActive", "Name" },
                values: new object[,]
                {
                    { "AU", "AUD", true, "Australia" },
                    { "IN", "INR", true, "India" },
                    { "NO", "NOK", true, "Norway" },
                    { "PK", "PAK", true, "Pakistan" },
                    { "SE", "SEK", true, "Sweden" },
                    { "SG", "SGD", true, "Singapore" },
                    { "UK", "GBP", true, "United Kingdom" },
                    { "US", "USD", true, "United States Of America" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Code", "CountryCode", "Name" },
                values: new object[,]
                {
                    { "AUD", "AU", "Australian Dollar" },
                    { "GBP", "UK", "Pound sterling" },
                    { "INR", "IN", "Indian Rupee" },
                    { "NOK", "NO", "Norwegin Krona" },
                    { "PKR", "PK", "Pakistan rupee" },
                    { "SEK", "SE", "Swedish Krona" },
                    { "SGD", "SG", "Singapore Dollar" },
                    { "USD", "US", "US dollar" }
                });

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "BaseCurrencyCode", "DestinationCurrencyCode", "IsActive", "ExchangeRateDate", "ExchangeRateToken", "Rate" },
                values: new object[,]
                {
                    { "USD", "AUD", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7106), "91e30ae2-2d7e-40b3-97d1-0499ea78e39d", 1.452348 },
                    { "USD", "DKK", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7205), "57c0278c-267e-42e6-a679-9a2246332fde", 7.3286899999999999 },
                    { "USD", "EUR", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7189), "0a5fe2e7-426f-46bc-9520-400b786edbb5", 0.98550499999999996 },
                    { "USD", "GBP", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7194), "35a0da8a-5396-4f8c-ab92-430cdf358b59", 0.85326500000000005 },
                    { "USD", "INR", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7184), "6cb6c704-53fc-42fa-89ad-1f03166239fd", 79.142250000000004 },
                    { "USD", "NOK", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7200), "3cfea2f9-6ea8-4f0d-815a-daf1616b8496", 9.8188010000000006 },
                    { "USD", "PKR", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7230), "d5985913-7f0d-4827-8146-30c2a2aa5bd1", 231.166079 },
                    { "USD", "SEK", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7179), "ad9a1166-5ef5-466d-b7a0-3dd34c7f07b9", 10.456480000000001 },
                    { "USD", "SGD", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7235), "7ee5e504-7055-48e0-9c31-32aa3cb88404", 1.39439 },
                    { "USD", "USD", true, new DateTime(2022, 9, 14, 20, 22, 18, 844, DateTimeKind.Utc).AddTicks(7172), "e048da39-d1a4-47a7-a20a-638a3be63733", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "TransferModes",
                columns: new[] { "TransferModeId", "TransferModeDescription", "TransferModeName" },
                values: new object[,]
                {
                    { 1, "Transfer money from bank", "Bank" },
                    { 2, "Credit card transfer", "Credit" },
                    { 3, "Transfer money using RTGS", "Bank" },
                    { 4, "Transfer money using trustly", "Trustly" }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankCode", "CountryCode", "AccountNumber", "Address", "BankName", "City", "IFSCCode", "MICRCode", "PhoneNumber", "PinCode", "StreetAddress" },
                values: new object[,]
                {
                    { "BOA", "SE", "12345578", null, "BankofAmerica", null, "431011201", "43101120", null, null, null },
                    { "BOA", "US", "12345578", null, "BankofAmerica", null, "431011201", "43101120", null, null, null },
                    { "CG", "US", "12345578", null, "Citigroup", null, "431011201", "43101120", null, null, null },
                    { "GS", "US", "12345578", null, "Goldman Sachs", null, "431011201", "43101120", null, null, null },
                    { "HB", "SE", "12345578", null, "Handelsbanken", null, "431011201", "43101120", null, null, null },
                    { "HSB", "US", "12345578", null, "HSBC Bank of America", null, "431011201", "43101120", null, null, null },
                    { "MS", "US", "12345578", null, "Morgan Stanely", null, "431011201", "43101120", null, null, null },
                    { "SEB", "SE", "12345578", null, "SEB", null, "431011201", "43101120", null, null, null },
                    { "SWE", "SE", "1234558", null, "Swed", null, "431011201", "43101120", null, null, null },
                    { "WF", "US", "1234558", null, "Wells Fargo", null, "431011201", "43101120", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "FeesDetails",
                columns: new[] { "FeesDetailsId", "FeesPercentage", "FromCountryCode", "IsAvailable", "ToCountryCode", "TransferModeId" },
                values: new object[,]
                {
                    { 1, 0.59999999999999998, "US", true, "SE", 1 },
                    { 2, 0.80000000000000004, "US", true, "SE", 2 },
                    { 3, 0.90000000000000002, "US", true, "SE", 3 },
                    { 4, 0.59999999999999998, "SE", true, "US", 1 },
                    { 5, 0.80000000000000004, "SE", true, "US", 2 },
                    { 6, 0.90000000000000002, "SE", true, "US", 4 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Code", "CountryCode", "Name" },
                values: new object[,]
                {
                    { "CA", "US", "California" },
                    { "GE", "US", "Georgia" },
                    { "GT", "SE", "Gothernberg" },
                    { "NY", "US", "NewYork" },
                    { "SK", "SE", "Stockholm" },
                    { "TE", "US", "Texas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CountryCode",
                table: "Banks",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_FeesDetails_TransferModeId",
                table: "FeesDetails",
                column: "TransferModeId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryCode",
                table: "States",
                column: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "FeesDetails");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "TransactionSender");

            migrationBuilder.DropTable(
                name: "TransactionTo");

            migrationBuilder.DropTable(
                name: "TransferModes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
