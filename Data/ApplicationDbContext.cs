using CharityConnect.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharityConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<CaseDonation> CaseDonations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CaseDonation>()
                .HasKey(cd => new { cd.CaseId, cd.DonationId });

            modelBuilder.Entity<CaseDonation>()
             .HasOne(ci => ci.Case)
             .WithMany(cd => cd.CaseDonations)
             .HasForeignKey(ci => ci.CaseId);

            modelBuilder.Entity<CaseDonation>()
                .HasOne(ci => ci.Donation)
                .WithMany(cd => cd.CaseDonations)
                .HasForeignKey(ci => ci.DonationId);


            //Seed Data
            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    MenuId = 1,
                    Name = "Trang Chủ",
                    Link = "/home",
                    Meta = "trang-chu",
                    Hide = false,
                    Order = 1,
                    DateBegin = DateTime.Now
                },
                new Menu
                {
                    MenuId = 2,
                    Name = "Hoàn Cảnh",
                    Link = "/cases",
                    Meta = "hoan-canh",
                    Hide = false,
                    Order = 2,
                    DateBegin = DateTime.Now
                },
                new Menu
                {
                    MenuId = 3,
                    Name = "Đóng Góp",
                    Link = "/donations",
                    Meta = "dong-gop",
                    Hide = false,
                    Order = 3,
                    DateBegin = DateTime.Now
                },
                new Menu
                {
                    MenuId = 4,
                    Name = "Thông Tin",
                    Link = "/about",
                    Meta = "thong-tin",
                    Hide = false,
                    Order = 4,
                    DateBegin = DateTime.Now
                },
                new Menu
                {
                    MenuId = 5,
                    Name = "Liên Hệ",
                    Link = "/contact",
                    Meta = "lien-he",
                    Hide = false,
                    Order = 5,
                    DateBegin = DateTime.Now
                }
            );


            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Người già neo đơn", Hide = false, Meta = "nguoi-gia-neo-don", DateBegin = DateTime.Now, Order = 1 },
                new Category { CategoryId = 2, Name = "Trẻ em mồ côi", Hide = false, Meta = "tre-em-mo-coi", DateBegin = DateTime.Now, Order = 2 },
                new Category { CategoryId = 3, Name = "Gia đình khó khăn", Hide = false, Meta = "gia-dinh-kho-khan", DateBegin = DateTime.Now, Order = 3 },
                new Category { CategoryId = 4, Name = "Bệnh nhân hiểm nghèo", Hide = false, Meta = "benh-nhan-hiem-ngheo", DateBegin = DateTime.Now, Order = 4 },
                new Category { CategoryId = 5, Name = "Người khuyết tật", Hide = false, Meta = "nguoi-khuyet-tat", DateBegin = DateTime.Now, Order = 5 },
                new Category { CategoryId = 6, Name = "Vùng sâu vùng xa", Hide = false, Meta = "vung-sau-vung-xa", DateBegin = DateTime.Now, Order = 6 },
                new Category { CategoryId = 7, Name = "Học sinh nghèo hiếu học", Hide = false, Meta = "hoc-sinh-ngheo-hieu-hoc", DateBegin = DateTime.Now, Order = 7 },
                new Category { CategoryId = 8, Name = "Nạn nhân thiên tai", Hide = false, Meta = "nan-nhan-thien-tai", DateBegin = DateTime.Now, Order = 8 }
           );

            modelBuilder.Entity<Donation>().HasData(
                new Donation { DonationId = 1, DonorName = "Nguyễn Văn Hà", Amount = 100000, Message = "Chúc sức khỏe đến các bệnh nhân", Meta = "", Hide = false, Order = 1, PaymentMethod = 0, DateBegin = DateTime.Now },
                new Donation { DonationId = 2, DonorName = "Trần Thị Minh", Amount = 200000, Message = "Mong rằng mọi người đều mạnh khỏe", Meta = "", Hide = false, Order = 2, PaymentMethod = 1, DateBegin = DateTime.Now },
                new Donation { DonationId = 3, DonorName = "Phạm Quốc Anh", Amount = 150000, Message = "Hy vọng cộng đồng sẽ ngày càng đoàn kết", Meta = "", Hide = false, Order = 3, PaymentMethod = 0, DateBegin = DateTime.Now },
                new Donation { DonationId = 4, DonorName = "Võ Thanh Huy", Amount = 500000, Message = "Gửi chút tấm lòng nhỏ bé", Meta = "", Hide = false, Order = 4, PaymentMethod = 2, DateBegin = DateTime.Now },
                new Donation { DonationId = 5, DonorName = "Nguyễn Thị Hương", Amount = 300000, Message = "Cầu chúc cho mọi người bình an", Meta = "", Hide = false, Order = 5, PaymentMethod = 1, DateBegin = DateTime.Now },
                new Donation { DonationId = 6, DonorName = "Lê Văn Dũng", Amount = 250000, Message = "Chúc chương trình thành công", Meta = "", Hide = false, Order = 6, PaymentMethod = 0, DateBegin = DateTime.Now },
                new Donation { DonationId = 7, DonorName = "Phạm Thị Mai", Amount = 400000, Message = "Hy vọng giúp được các hoàn cảnh khó khăn", Meta = "", Hide = false, Order = 7, PaymentMethod = 2, DateBegin = DateTime.Now },
                new Donation { DonationId = 8, DonorName = "Hoàng Văn Phong", Amount = 180000, Message = "Tôi rất trân trọng những nỗ lực này", Meta = "", Hide = false, Order = 8, PaymentMethod = 1, DateBegin = DateTime.Now }
          );

            modelBuilder.Entity<Case>().HasData(

               new Case
               {
                   CaseId = 1,
                   CategoryId = 7, // "Học sinh nghèo hiếu học"
                   Title = "Hỗ trợ học sinh nghèo ở vùng sâu vùng xa",
                   Description = "Kêu gọi chung tay ủng hộ trẻ em nghèo ở vùng sâu vùng xa...",
                   Meta = "",
                   Hide = false,
                   Order = 1,
                   DateBegin = DateTime.Now,
                   Location = "Yên Bái"
               },
                new Case
                {
                    CaseId = 2,
                    CategoryId = 3, // "Gia đình khó khăn"
                    Title = "Gia đình cần sự giúp đỡ sau bão lũ",
                    Description = "Cần sự hỗ trợ khẩn cấp để giúp gia đình bị mất nhà cửa sau cơn bão...",
                    Meta = "",
                    Hide = false,
                    Order = 2,
                    DateBegin = DateTime.Now,
                    Location = "Quảng Bình"
                },
                new Case
                {
                    CaseId = 3,
                    CategoryId = 4, // "Bệnh nhân hiểm nghèo"
                    Title = "Hỗ trợ bệnh nhân cần ghép thận khẩn cấp",
                    Description = "Kêu gọi giúp đỡ chi phí cho bệnh nhân cần ghép thận gấp...",
                    Meta = "",
                    Hide = false,
                    Order = 3,
                    DateBegin = DateTime.Now,
                    Location = "Hà Nội"
                },
                new Case
                {
                    CaseId = 4,
                    CategoryId = 5, // "Người khuyết tật"
                    Title = "Giúp đỡ trẻ em khuyết tật có cuộc sống tốt hơn",
                    Description = "Hỗ trợ chi phí học tập và sinh hoạt cho trẻ em khuyết tật...",
                    Meta = "",
                    Hide = false,
                    Order = 4,
                    DateBegin = DateTime.Now,
                    Location = "Thừa Thiên Huế"
                },
                new Case
                {
                    CaseId = 5,
                    CategoryId = 6, // "Vùng sâu vùng xa"
                    Title = "Xây dựng trường học cho trẻ em vùng sâu",
                    Description = "Chung tay xây dựng trường học kiên cố để trẻ em vùng sâu được học tập tốt hơn...",
                    Meta = "",
                    Hide = false,
                    Order = 5,
                    DateBegin = DateTime.Now,
                    Location = "Kon Tum"
                },
                new Case
                {
                    CaseId = 6,
                    CategoryId = 2, // "Trẻ em mồ côi"
                    Title = "Hỗ trợ trẻ em mồ côi do COVID-19",
                    Description = "Quyên góp để hỗ trợ chi phí học tập và sinh hoạt cho trẻ em mất cha mẹ vì COVID-19...",
                    Meta = "",
                    Hide = false,
                    Order = 6,
                    DateBegin = DateTime.Now,
                    Location = "TP. Hồ Chí Minh"
                },
                new Case
                {
                    CaseId = 7,
                    CategoryId = 8, // "Nạn nhân thiên tai"
                    Title = "Hỗ trợ nạn nhân lũ quét miền Trung",
                    Description = "Kêu gọi sự giúp đỡ cho các gia đình bị ảnh hưởng bởi lũ quét miền Trung...",
                    Meta = "",
                    Hide = false,
                    Order = 7,
                    DateBegin = DateTime.Now,
                    Location = "Quảng Nam"
                },
                new Case
                {
                    CaseId = 8,
                    CategoryId = 1, // "Người già neo đơn"
                    Title = "Chăm sóc người già neo đơn không nơi nương tựa",
                    Description = "Quyên góp để hỗ trợ sinh hoạt phí và chăm sóc sức khỏe cho người già neo đơn...",
                    Meta = "",
                    Hide = false,
                    Order = 8,
                    DateBegin = DateTime.Now,
                    Location = "Đà Nẵng"
                }
             );

            modelBuilder.Entity<CaseDonation>().HasData(
                 new CaseDonation { CaseId = 1, DonationId = 2 },
                 new CaseDonation { CaseId = 2, DonationId = 3 },
                 new CaseDonation { CaseId = 3, DonationId = 1 },
                 new CaseDonation { CaseId = 4, DonationId = 4 },
                 new CaseDonation { CaseId = 5, DonationId = 5 },
                 new CaseDonation { CaseId = 6, DonationId = 6 },
                 new CaseDonation { CaseId = 7, DonationId = 7 },
                 new CaseDonation { CaseId = 8, DonationId = 8 }
             );

        }
    }
}
