using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.DataAccess.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    TcNo = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    InfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NewsName = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.InfoId);
                    table.ForeignKey(
                        name: "FK_Infos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    InfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Infos_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Infos",
                        principalColumn: "InfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Ekonomi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Siyaset" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Spor" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Ulusal" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 5, "Genel" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 1, 5, "İtalya'da açıklarındaki feribot yangınında kaybolan TIR şoförü Mehmet Çakır'dan (42) 130 gündür haber alınamadı. Aydınlı olan Çakır'ın eniştesi Davut Gür (52), Hala bir ses yok.Ablası, annesi ve babası merak içinde.En azından öldüyse cenazesini memleketine defnetmek istiyoruz.Artık akıbetini öğrenmek istiyoruz dedi", "https://im.haberturk.com/2022/06/27/3473052_5f7955d6a10f726bfac7565d7f8ed46c_640x640.jpg", "İtalya da kaybolan Türk şoförden haber alınamıyor" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 2, 4, "Ürdün'ün Akabe kentinde tankerin patlaması sonucu sızan zehirli gazdan 10 kişi öldü, 250’den fazla kişi yaralandı", "https://im.haberturk.com/2022/06/27/ver1656350244/3473039_810x458.jpg", "Son dakika haberi Ürdün'de tanker patladı: 10 kişi öldü" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 3, 4, "NATO Genel Sekreteri Jens Stoltenberg, Madrid´de yapılacak NATO Liderler Zirvesi öncesi basın mensuplarının sorularını yanıtladı. Stoltenberg, İsveç, Finlandiya ve Türkiye arasında yapılacak toplantıya ilişkin Amaç elbette Finlandiya ve İsveç konusunda ilerleme kaydetmek.Herhangi bir söz vermeyeceğim ama sizi temin ederim ki ilerlemeyi sağlamak için aktif olarak çalışıyoruz dedi.", "https://im.haberturk.com/2022/06/27/ver1656345623/3472996_810x458.jpg", "Stoltenberg´den Türkiye açıklaması: Amacımız ilerleme kaydetmek" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 4, 2, "Son dakika haberi CHP'de Aykut Erdoğdu ve Tuba Torun istifa etti", "https://im.haberturk.com/2022/06/29/ver1656507938/3473528_810x458.jpg", "CHP İstanbul Milletvekili Aykut Erdoğdu ve Yüksek Disiplin Kurulu üyesi Tuba Torun Erdoğdu partiden istifa etti. Erdoğdu ve Torun'un CHP'nin kendileri üzerinden yıpratılmaması amacıyla bu kararı aldıklarını belirtildi" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 5, 3, "Son dakika transfer haberi... Galatasaray, Joao Pedro ile prensipte anlaştı", "https://im.haberturk.com/2022/06/29/3473478_be511c925b75dc7ecc2a46d64446ba17_640x640.jpg", "Galatasaray, İtalya Serie A ekiplerinden Cagliari'de forma giyen Joao Pedro'yu kadrosuna katmak üzere..." });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 6, 3, "Son dakika Fenerbahçe haberleri... Süper Lig ekibi Fenerbahçe'nin deneyimli futbolcusu Enner Valencia, geleceğine ilişkin açıklamalarda bulundu. Valencia, 'Menajerim gelecek hafta Türkiye'ye gelecek, Fenerbahçe ile geleceğim hakkında konuşacak dedi!", "https://im.haberturk.com/2022/06/29/ver1656493754/3473479_810x458.jpg", "Son dakika Fenerbahçe haberleri... Valencia'dan flaş açıklama: Menajerim gelecek!" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 7, 3, "Spor Toto Süper Lig'den düşen Yeni Malatyaspor Kulübü, olağanüstü seçimli genel kurul kararı aldı", "https://im.haberturk.com/2022/06/29/ver1656511157/3473583_810x458.jpg", "Yeni Malatyaspor Kulübü olağanüstü genel kurul kararı aldı" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 8, 3, "Anadolu Efes, Adrien Moerman ile yolların ayrıldığını açıkladı", "https://im.haberturk.com/2022/06/29/ver1656492854/3473474_810x458.jpg", "Anadolu Efes'te ayrılık" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 9, 3, "Son dakika haberine göre; Fenerbahçe, Fatih Karagümrük'ten Emre Mor'un transferi için prensip anlaşmasına varıldığını açıkladı! Sarı-lacivertli kulübün paylaşımında Kulübümüz, Emre Mor transferi için Fatih Karagümrük Kulübü ve oyuncunun kendisi ile prensip anlaşmasına varmıştır ifadelerine yer verildi", "https://im.haberturk.com/2022/06/29/ver1656487958/3473369_810x458.jpg", "Son dakika: Fenerbahçe Emre Mor transferini açıkladı!" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 10, 3, "Galatasaray Nef, ABDli oyuncu Raymar Morgan'ı kadrosuna kattı. Raymar Morgan, Türkiye'de daha önce Pınar Karşıyaka ve TOFAŞ'ta forma giymişti", "https://im.haberturk.com/2022/06/28/ver1656435892/3473333_810x458.jpg", "Raymar Morgan, Galatasaray Nef'e transfer oldu" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 11, 3, "Beşiktaş, yeni sezon hazırlıklarına bu akşam yaptığı çalışmayla devam etti. Valerien Ismael yönetiminde yapılan antrenman, yaklaşık 1.5 saat sürdü. Siyah-beyazlı ekip, yeni sezon hazırlıklarına, yarın saat 10.30 ve 16.00´da yapacağı çalışmalarla devam edecek", "https://im.haberturk.com/2022/06/28/ver1656440926/3473346_810x458.jpg", "Beşiktaş'ta yeni sezon hazırlıkları sürdü" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 12, 3, "Aytemiz Alanyaspor, genç oyuncu Mert Yusuf Torlak'ı 5 yıllığına kadrosuna kattı", "https://im.haberturk.com/2022/06/28/ver1656426239/3473301_810x458.jpg", "Mert Yusuf, 5 yıllığına Alanyaspor’da" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 13, 3, "Galatasaray'da yeni sezon hazırlıklarına başlayan futbolcular, sağlık kontrolünden geçti", "https://im.haberturk.com/2022/06/28/ver1656418200/3473264_810x458.jpg", "Galatasaraylı futbolcular sağlık kontrolünden geçti" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 14, 3, "Son dakika Fenerbahçe transfer haberleri... Fenerbahçe golcü transferinde önceliğini Dominikli forvete verdi. Sarı-Lacivertliler, Real Madrid’in 6 milyon Euro'luk maliyeti nedeniyle kadroda düşünmediği 28 yaşındaki forvetle masaya oturdu. Olumlu geçen görüşmelerin kısa sürede netleşmesi bekleniyor. İşte son dakika haberinin detayları", "https://im.haberturk.com/2022/06/28/3473182_0fe84dd1097b9557ee2b9f146c3a560b_640x640.jpg", "Son dakika Fenerbahçe transfer haberleri - Hedefteki isim Mariano Diaz!" });

            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "InfoId", "CategoryId", "Content", "ImageUrl", "NewsName" },
                values: new object[] { 15, 3, "Aytemiz Alanyaspor, genç oyuncu Mert Yusuf Torlak'ı 5 yıllığına kadrosuna kattı", "https://im.haberturk.com/2022/06/28/ver1656426239/3473301_810x458.jpg", "Mert Yusuf, 5 yıllığına Alanyaspor’da" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "InfoId", "UserName" },
                values: new object[] { 1, "İnanılmaz bir haber", 1, "Murat Kuşcan" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "InfoId", "UserName" },
                values: new object[] { 2, "Umarım Erkenden bulunur..", 1, "Berke Dursunoğlu" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "InfoId", "UserName" },
                values: new object[] { 3, "Allah ailesine sabır versin..", 1, "Onurcan Cengiz" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "InfoId", "UserName" },
                values: new object[] { 4, "Umarım kaçırılıp böbreklerini satmamışlardır..", 1, "Ozan Çepni" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_InfoId",
                table: "Comments",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_CategoryId",
                table: "Infos",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
