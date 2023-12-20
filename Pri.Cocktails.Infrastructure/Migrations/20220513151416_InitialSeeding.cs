using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pri.Cocktails.Infrastructure.Migrations
{
    public partial class InitialSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Streetname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CocktailCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlassTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuringUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Cocktails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CocktailCategoryId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Instrucktions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GlassTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cocktails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cocktails_CocktailCategories_CocktailCategoryId",
                        column: x => x.CocktailCategoryId,
                        principalTable: "CocktailCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cocktails_GlassTypes_GlassTypeId",
                        column: x => x.GlassTypeId,
                        principalTable: "GlassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IngredientTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientTypes_IngredientTypeId",
                        column: x => x.IngredientTypeId,
                        principalTable: "IngredientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailTool",
                columns: table => new
                {
                    CocktailsId = table.Column<int>(type: "int", nullable: false),
                    ToolsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailTool", x => new { x.CocktailsId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_CocktailTool_Cocktails_CocktailsId",
                        column: x => x.CocktailsId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailTool_Tools_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailIngredient",
                columns: table => new
                {
                    CocktailId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasuringUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailIngredient", x => new { x.IngredientId, x.CocktailId });
                    table.ForeignKey(
                        name: "FK_CocktailIngredient_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailIngredient_MeasuringUnits_MeasuringUnitId",
                        column: x => x.MeasuringUnitId,
                        principalTable: "MeasuringUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "HouseNumber", "PostalCode", "Streetname" },
                values: new object[,]
                {
                    { 1, "Zeebrugge", "België", "65", "8380", "Evendijk-Oost" },
                    { 2, "Tremelo", "België", "16B", "3128", "Rozendaal" }
                });

            migrationBuilder.InsertData(
                table: "CocktailCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cognac/Brandewijn" },
                    { 2, "Likeur" },
                    { 3, "Rum" },
                    { 4, "Tequila" }
                });

            migrationBuilder.InsertData(
                table: "GlassTypes",
                columns: new[] { "Id", "Name", "Picture" },
                values: new object[,]
                {
                    { 8, "Shotglas", "Shotglas.png" },
                    { 7, "Pousse-caféglas", "Pousse-caféglas.png" },
                    { 6, "Cognacglas", "Cognacglas.png" },
                    { 5, "Champagneglas", "Champagneglas.png" },
                    { 4, "Martiniglas", "Martiniglas.png" },
                    { 3, "Old fashioned-glas", "Old fashioned-glas.png" },
                    { 2, "longdrinkglas", "Longdrinkglas.png" },
                    { 1, "Cocktailglas", "Coctail.png" }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 11, "Steenvruchten" },
                    { 10, "Room" },
                    { 9, "Suikers" },
                    { 8, "koolzuurhoudende dranken" },
                    { 7, "Siroop" },
                    { 5, "Vruchtensap" },
                    { 4, "Ijs" },
                    { 3, "Bier" },
                    { 2, "Likeur" },
                    { 1, "Sterke drank" },
                    { 6, "Fruit" }
                });

            migrationBuilder.InsertData(
                table: "MeasuringUnits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "eigen voorkeur" },
                    { 1, "deel" },
                    { 2, "gram" },
                    { 3, "tl" },
                    { 5, "enkele druppels" },
                    { 6, "enkele" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Name", "Picture" },
                values: new object[,]
                {
                    { 5, "Ijshamer", "Ijshamer.png" },
                    { 4, "Maatbeker", "Maatbeker.png" },
                    { 6, "Rasper", "Rasp.png" },
                    { 2, "Stirrer", "Stirrer.png" },
                    { 1, "Jigger", "Jigger.png" },
                    { 3, "Shaker", "Shaker.png" },
                    { 7, "Strainer", "Strainer.png" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b", 0, 1, "1c919f5d-938f-4ddd-83e0-6bd3e215cd92", new DateTime(1983, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@cocktails.com", true, "Benny", "Van Meerbeeck", false, null, "ADMIN@COCKTAILS.COM", "ADMIN@COCKTAILS.COM", "AQAAAAEAACcQAAAAED4f1uyt4/Yva4H8rdkw4VirPg8y7sf2qADogDwLkYxzBDEVjq1zKAgtVXE9dWIEuw==", null, false, "4ed5c643-1d97-4881-be6e-168a625d2cd4", false, "admin@cocktails.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a8005868-9fe2-49d7-bba8-398fb8191988", 0, 2, "fb22ad26-8789-4650-a869-691659d36c61", new DateTime(1967, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "arlette@cocktails.com", true, "Arlette", "Verheugen", false, null, "ARLETTE@COCKTAILS.COM", "ARLETTE@COCKTAILS.COM", "AQAAAAEAACcQAAAAEIh6tFcRKJdYBGVMkrm49KvbA4SMPDFYM5RLERlypkVwS12hFiYemygdDRIeARmaiw==", null, false, "aaf34067-c3e4-4959-a7fb-b310fc5dde02", false, "arlette@cocktails.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "admin", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 2, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 3, "registration-date", "22-05-13", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "user", "a8005868-9fe2-49d7-bba8-398fb8191988" },
                    { 6, "registration-date", "22-05-13", "a8005868-9fe2-49d7-bba8-398fb8191988" },
                    { 5, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "a8005868-9fe2-49d7-bba8-398fb8191988", "a8005868-9fe2-49d7-bba8-398fb8191988" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "CocktailCategoryId", "GlassTypeId", "Instrucktions", "Name", "Picture", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Doe het gehakte ij in een mengglas.;Scheck de cognac, appelbrandwijn en vermout erop.;Roer voorzichtig.;schenk het mengsel in een gekoeld cocktailglas.", "Corpse Reviver", "Corpse Reviver.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 2, 1, 2, "Doe de ingrediënten met ijs in een mengglas.;Roer en scheck het mengels door de strainer in een gekoeld glas", "Adam's Apple", "Adams apple.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 3, 2, 1, "Wrijf de rand van een cocktailglas in met Drambuie.;Meng de geraspte limoenschil en suiker en draai de rand van het glass door het mengsel.;Roer alle ingrediënten inclusief de rest van het suikermengsel in het met ijs gevulde cocktailglas.;Vul het geheel aan met spuitwater naar smaak.", "Lime Swizzle", null, "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 4, 2, 3, "Roer de eerste drie ingrediënten met ijs.;Schenk het mengels door een strainer in een whisky-of longdrinkglass,voeg meer ijs toe en vulhet geheel aan met spuitwater naar smaak.;Garneer met een paar frambozen.", "Highland Raider", "Highland Raider.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 6, 4, 2, "Scheck de tequila in een gekoeld longdrinkglas met gehakt ij en vul hem met sinaasappelsap.;Schenk langzaam de grenadine erbij en serveer deze longdrink met een rietje", "Tequila Sunrise", "Tequila Sunrise.png", "a8005868-9fe2-49d7-bba8-398fb8191988" },
                    { 5, 3, 2, "Shake de rum,gin en het ananassap met ijs.;Schenk het mengsel door de strainer in een gekoeld longdrinkglas", "Palm Beach", "Palm Beach.png", "a8005868-9fe2-49d7-bba8-398fb8191988" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientTypeId", "Name", "Picture", "UserId" },
                values: new object[,]
                {
                    { 15, 6, "Frambozen", "Frambozen.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 18, 4, "Gehakt ijs", "Gehakt ijs.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 16, 1, "Witte rum", "Witte rum.png", "a8005868-9fe2-49d7-bba8-398fb8191988" },
                    { 17, 5, "Ananassap", "Ananassap.png", "a8005868-9fe2-49d7-bba8-398fb8191988" },
                    { 19, 1, "Witte Tequila", "Witte Tequila.png", "a8005868-9fe2-49d7-bba8-398fb8191988" },
                    { 14, 2, "Glayva", "Glayva.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 13, 1, "Whisky", "Whisky.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 10, 5, "Limoensap", "Limoensap.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 11, 9, "Poedersuiker", "Poedersuiker.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 20, 5, "Sinaasappelsap", "Fruitsap.png", "a8005868-9fe2-49d7-bba8-398fb8191988" },
                    { 9, 6, "Limoenschil", "Limoen.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 8, 2, "Drambuie", "Drambule.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 7, 1, "Gele Chartreuse", "Gele Chartreuse.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 6, 1, "Droge vermout", "Droge Vermout.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 5, 1, "Gin", "Gin.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 4, 4, "ijs", "Ijs.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 3, 1, "zoete vermout", "Zoete vermout.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 2, 1, "Appelbrandwijn", "Appelbrandwijn.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 1, 1, "Cognac", "Cognac.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 12, 8, "Spuitwater", "Spuitwater.png", "4fc95d11-9c63-4a1c-b34f-b0bcec91a71b" },
                    { 21, 7, "Grenadine", "Grenadine.png", "a8005868-9fe2-49d7-bba8-398fb8191988" }
                });

            migrationBuilder.InsertData(
                table: "CocktailIngredient",
                columns: new[] { "CocktailId", "IngredientId", "Amount", "MeasuringUnitId" },
                values: new object[,]
                {
                    { 4, 8, "1", 1 },
                    { 6, 20, null, 4 },
                    { 3, 9, "1/4", 3 },
                    { 3, 10, null, 5 },
                    { 3, 11, "1", 3 },
                    { 3, 12, null, 4 },
                    { 4, 12, null, 4 },
                    { 4, 13, "1", 1 },
                    { 3, 8, "1 1/2", 1 },
                    { 4, 14, "1", 1 },
                    { 1, 18, null, 4 },
                    { 5, 5, "1", 1 },
                    { 5, 4, null, 4 },
                    { 6, 18, null, 4 },
                    { 5, 16, "1", 1 },
                    { 5, 17, "1", 1 },
                    { 6, 19, "2", 1 },
                    { 4, 15, null, 6 },
                    { 2, 7, "1", 1 },
                    { 6, 21, "1", 1 },
                    { 2, 5, "1", 1 },
                    { 4, 4, null, 4 },
                    { 3, 4, null, 4 },
                    { 2, 4, null, 4 },
                    { 1, 3, "1", 1 },
                    { 2, 2, "2", 1 },
                    { 1, 2, "1", 1 },
                    { 1, 1, "2", 1 },
                    { 2, 6, "1", 1 }
                });

            migrationBuilder.InsertData(
                table: "CocktailTool",
                columns: new[] { "CocktailsId", "ToolsId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 6, 1 },
                    { 3, 2 },
                    { 5, 1 },
                    { 5, 7 },
                    { 5, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 7 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "CocktailTool",
                columns: new[] { "CocktailsId", "ToolsId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailIngredient_CocktailId",
                table: "CocktailIngredient",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailIngredient_MeasuringUnitId",
                table: "CocktailIngredient",
                column: "MeasuringUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_CocktailCategoryId",
                table: "Cocktails",
                column: "CocktailCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_GlassTypeId",
                table: "Cocktails",
                column: "GlassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_UserId",
                table: "Cocktails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailTool_ToolsId",
                table: "CocktailTool",
                column: "ToolsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UserId",
                table: "Ingredients",
                column: "UserId");
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
                name: "CocktailIngredient");

            migrationBuilder.DropTable(
                name: "CocktailTool");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "MeasuringUnits");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "IngredientTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CocktailCategories");

            migrationBuilder.DropTable(
                name: "GlassTypes");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
