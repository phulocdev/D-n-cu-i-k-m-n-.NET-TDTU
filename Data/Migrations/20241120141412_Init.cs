using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CharityConnect.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Cases_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseDonations",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DonationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDonations", x => new { x.CaseId, x.DonationId });
                    table.ForeignKey(
                        name: "FK_CaseDonations_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseDonations_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DateBegin", "Hide", "Meta", "Name", "Order" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8593), false, "nguoi-gia-neo-don", "Người già neo đơn", 1 },
                    { 2, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8595), false, "tre-em-mo-coi", "Trẻ em mồ côi", 2 },
                    { 3, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8596), false, "gia-dinh-kho-khan", "Gia đình khó khăn", 3 },
                    { 4, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8597), false, "benh-nhan-hiem-ngheo", "Bệnh nhân hiểm nghèo", 4 },
                    { 5, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8598), false, "nguoi-khuyet-tat", "Người khuyết tật", 5 },
                    { 6, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8600), false, "vung-sau-vung-xa", "Vùng sâu vùng xa", 6 },
                    { 7, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8601), false, "hoc-sinh-ngheo-hieu-hoc", "Học sinh nghèo hiếu học", 7 },
                    { 8, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8602), false, "nan-nhan-thien-tai", "Nạn nhân thiên tai", 8 }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "DonationId", "Amount", "DateBegin", "DonorName", "Hide", "Message", "Meta", "Order", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 100000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8619), "Nguyễn Văn Hà", false, "Chúc sức khỏe đến các bệnh nhân", "", 1, 0 },
                    { 2, 200000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8621), "Trần Thị Minh", false, "Mong rằng mọi người đều mạnh khỏe", "", 2, 1 },
                    { 3, 150000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8622), "Phạm Quốc Anh", false, "Hy vọng cộng đồng sẽ ngày càng đoàn kết", "", 3, 0 },
                    { 4, 500000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8624), "Võ Thanh Huy", false, "Gửi chút tấm lòng nhỏ bé", "", 4, 2 },
                    { 5, 300000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8625), "Nguyễn Thị Hương", false, "Cầu chúc cho mọi người bình an", "", 5, 1 },
                    { 6, 250000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8627), "Lê Văn Dũng", false, "Chúc chương trình thành công", "", 6, 0 },
                    { 7, 400000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8628), "Phạm Thị Mai", false, "Hy vọng giúp được các hoàn cảnh khó khăn", "", 7, 2 },
                    { 8, 180000, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8629), "Hoàng Văn Phong", false, "Tôi rất trân trọng những nỗ lực này", "", 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "DateBegin", "Hide", "Link", "Meta", "Name", "Order" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8464), false, "/home", "trang-chu", "Trang Chủ", 1 },
                    { 2, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8475), false, "/cases", "hoan-canh", "Hoàn Cảnh", 2 },
                    { 3, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8477), false, "/donations", "dong-gop", "Đóng Góp", 3 },
                    { 4, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8478), false, "/about", "thong-tin", "Thông Tin", 4 },
                    { 5, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8479), false, "/contact", "lien-he", "Liên Hệ", 5 }
                });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "CaseId", "CategoryId", "DateBegin", "Description", "Hide", "ImageUrl", "Location", "Meta", "Order", "Title" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8649), "Kêu gọi chung tay ủng hộ trẻ em nghèo ở vùng sâu vùng xa...", false, "https://via.placeholder.com/150", "Yên Bái", "", 1, "Hỗ trợ học sinh nghèo ở vùng sâu vùng xa" },
                    { 2, 3, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8651), "Cần sự hỗ trợ khẩn cấp để giúp gia đình bị mất nhà cửa sau cơn bão...", false, "https://via.placeholder.com/150", "Quảng Bình", "", 2, "Gia đình cần sự giúp đỡ sau bão lũ" },
                    { 3, 4, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8652), "Kêu gọi giúp đỡ chi phí cho bệnh nhân cần ghép thận gấp...", false, "https://via.placeholder.com/150", "Hà Nội", "", 3, "Hỗ trợ bệnh nhân cần ghép thận khẩn cấp" },
                    { 4, 5, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8654), "Hỗ trợ chi phí học tập và sinh hoạt cho trẻ em khuyết tật...", false, "https://via.placeholder.com/150", "Thừa Thiên Huế", "", 4, "Giúp đỡ trẻ em khuyết tật có cuộc sống tốt hơn" },
                    { 5, 6, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8655), "Chung tay xây dựng trường học kiên cố để trẻ em vùng sâu được học tập tốt hơn...", false, "https://via.placeholder.com/150", "Kon Tum", "", 5, "Xây dựng trường học cho trẻ em vùng sâu" },
                    { 6, 2, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8657), "Quyên góp để hỗ trợ chi phí học tập và sinh hoạt cho trẻ em mất cha mẹ vì COVID-19...", false, "https://via.placeholder.com/150", "TP. Hồ Chí Minh", "", 6, "Hỗ trợ trẻ em mồ côi do COVID-19" },
                    { 7, 8, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8659), "Kêu gọi sự giúp đỡ cho các gia đình bị ảnh hưởng bởi lũ quét miền Trung...", false, "https://via.placeholder.com/150", "Quảng Nam", "", 7, "Hỗ trợ nạn nhân lũ quét miền Trung" },
                    { 8, 1, new DateTime(2024, 11, 20, 21, 14, 12, 494, DateTimeKind.Local).AddTicks(8660), "Quyên góp để hỗ trợ sinh hoạt phí và chăm sóc sức khỏe cho người già neo đơn...", false, "https://via.placeholder.com/150", "Đà Nẵng", "", 8, "Chăm sóc người già neo đơn không nơi nương tựa" }
                });

            migrationBuilder.InsertData(
                table: "CaseDonations",
                columns: new[] { "CaseId", "DonationId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseDonations_DonationId",
                table: "CaseDonations",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CategoryId",
                table: "Cases",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseDonations");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
