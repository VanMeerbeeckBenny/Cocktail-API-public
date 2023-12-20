using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.Cocktails.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            var address = new Address[]
            {
                new Address {Id = 1,Streetname = "Baanderheerstraat",HouseNumber ="49" ,PostalCode = "8380",City = "Brugge",Country ="België"},
                new Address {Id = 2,Streetname = "Hagedoornlaan",HouseNumber ="16B" ,PostalCode = "8380",City = "Brugge",Country ="België"}
            };

            var users = new ApplicationUser[]
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin@cocktails.com",
                    NormalizedUserName = "ADMIN@COCKTAILS.COM",
                    Email = "admin@cocktails.com",
                    NormalizedEmail = "ADMIN@COCKTAILS.COM",
                    Firstname = "Benny",
                    Lastname = "Van Meerbeeck",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    DateOfBirth = new DateTime(1983,02,19),
                    AddressId = 1                    
                },
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "arlette@cocktails.com",
                    NormalizedUserName = "ARLETTE@COCKTAILS.COM",
                    Email = "arlette@cocktails.com",
                    NormalizedEmail = "ARLETTE@COCKTAILS.COM",
                    Firstname = "Arlette",
                    Lastname = "Verheugen",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    AddressId = 2,
                    DateOfBirth = new DateTime(1967,10,28),
                }               
            };

            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "admin");//only in development
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "user");            

            var claims = new IdentityUserClaim<string>[]
            {
                new IdentityUserClaim<string> {Id = 1,UserId = users[0].Id,ClaimType = ClaimTypes.Role,ClaimValue ="admin"},
                new IdentityUserClaim<string> {Id = 2,UserId = users[0].Id,ClaimType = ClaimTypes.NameIdentifier,ClaimValue =users[0].Id},
                new IdentityUserClaim<string> {Id = 3,UserId = users[0].Id,ClaimType = "registration-date",ClaimValue =DateTime.UtcNow.ToString("yy-MM-dd")},
                new IdentityUserClaim<string> {Id = 4,UserId = users[1].Id,ClaimType = ClaimTypes.Role,ClaimValue ="user"},
                new IdentityUserClaim<string> {Id = 5,UserId = users[1].Id,ClaimType = ClaimTypes.NameIdentifier,ClaimValue =users[1].Id},
                new IdentityUserClaim<string> {Id = 6,UserId = users[1].Id,ClaimType = "registration-date",ClaimValue =DateTime.UtcNow.ToString("yy-MM-dd")}
            };

            var ingredientTypes = new IngredientType[]
            {
                new IngredientType {Id = 1, Name = "Sterke drank"},
                new IngredientType {Id = 2, Name = "Likeur"},
                new IngredientType {Id = 3, Name = "Bier"},
                new IngredientType {Id = 4, Name = "Ijs"},
                new IngredientType {Id = 5, Name = "Vruchtensap" },
                new IngredientType {Id = 6, Name = "Fruit" },
                new IngredientType {Id = 7, Name = "Siroop"},
                new IngredientType {Id = 8, Name = "koolzuurhoudende dranken"},
                new IngredientType {Id = 9, Name = "Suikers"},
                new IngredientType {Id = 10, Name = "Room"},
                new IngredientType {Id = 11, Name = "Steenvruchten"}
            };

            var ingredients = new Ingredient[]
            {
                new Ingredient{ Id = 1, Name = "Cognac",IngredientTypeId =1,Picture ="Cognac.png",UserId = users[0].Id},
                new Ingredient{ Id = 2, Name = "Appelbrandwijn",IngredientTypeId =1,Picture = "Appelbrandwijn.png",UserId = users[0].Id},
                new Ingredient{ Id = 3, Name = "zoete vermout",IngredientTypeId =1,Picture="Zoete vermout.png",UserId = users[0].Id},
                new Ingredient{ Id = 4, Name = "ijs",IngredientTypeId =4,Picture ="Ijs.png",UserId = users[0].Id},
                new Ingredient{ Id = 5, Name = "Gin",IngredientTypeId =1,Picture ="Gin.png",UserId = users[0].Id},
                new Ingredient{ Id = 6, Name = "Droge vermout",IngredientTypeId =1,Picture ="Droge Vermout.png",UserId = users[0].Id},
                new Ingredient{ Id = 7, Name = "Gele Chartreuse",IngredientTypeId =1,Picture ="Gele Chartreuse.png",UserId = users[0].Id},
                new Ingredient{ Id = 8, Name = "Drambuie",IngredientTypeId =2,Picture ="Drambule.png",UserId = users[0].Id},
                new Ingredient{ Id = 9, Name = "Limoenschil",IngredientTypeId =6,Picture ="Limoen.png",UserId = users[0].Id},
                new Ingredient{ Id = 10, Name = "Limoensap",IngredientTypeId =5,Picture ="Limoensap.png",UserId = users[0].Id},
                new Ingredient{ Id = 11, Name = "Poedersuiker",IngredientTypeId =9,Picture ="Poedersuiker.png",UserId = users[0].Id},
                new Ingredient{ Id = 12, Name = "Spuitwater",IngredientTypeId =8,Picture ="Spuitwater.png",UserId = users[0].Id},
                new Ingredient{ Id = 13, Name = "Whisky",IngredientTypeId =1,Picture ="Whisky.png",UserId = users[0].Id},
                new Ingredient{ Id = 14, Name = "Glayva",IngredientTypeId =2,Picture ="Glayva.png",UserId = users[0].Id},
                new Ingredient{ Id = 15, Name = "Frambozen",IngredientTypeId =6,Picture ="Frambozen.png",UserId = users[0].Id},
                new Ingredient{ Id = 16, Name = "Witte rum",IngredientTypeId =1,Picture ="Witte rum.png",UserId = users[1].Id},
                new Ingredient{ Id = 17, Name = "Ananassap",IngredientTypeId =5,Picture ="Ananassap.png",UserId = users[1].Id},
                new Ingredient{ Id = 18, Name = "Gehakt ijs",IngredientTypeId =4,Picture ="Gehakt ijs.png",UserId = users[0].Id},
                new Ingredient{ Id = 19, Name = "Witte Tequila",IngredientTypeId =1,Picture ="Witte Tequila.png",UserId = users[1].Id},
                new Ingredient{ Id = 20, Name = "Sinaasappelsap",IngredientTypeId =5,Picture ="Fruitsap.png",UserId = users[1].Id},
                new Ingredient{ Id = 21, Name = "Grenadine",IngredientTypeId =7,Picture ="Grenadine.png",UserId = users[1].Id}
            };

            var glasses = new GlassType[]
            {
                new GlassType { Id = 1, Name ="Cocktailglas",Picture = "Coctail.png"},
                new GlassType { Id = 2, Name ="longdrinkglas" , Picture = "Longdrinkglas.png"},
                new GlassType { Id = 3, Name ="Old fashioned-glas" , Picture = "Old fashioned-glas.png"},
                new GlassType { Id = 4, Name ="Martiniglas",Picture = "Martiniglas.png"},
                new GlassType { Id = 5, Name ="Champagneglas" , Picture = "Champagneglas.png"},
                new GlassType { Id = 6, Name ="Cognacglas" , Picture = "Cognacglas.png"},
                new GlassType { Id = 7, Name ="Pousse-caféglas",Picture = "Pousse-caféglas.png"},
                new GlassType { Id = 8, Name ="Shotglas" , Picture = "Shotglas.png"},                
            };

            var cocktailCategories = new Category[]
            {
                new Category { Id = 1, Name = "Cognac/Brandewijn"},
                new Category { Id = 2, Name = "Likeur"},
                new Category { Id = 3, Name = "Rum"},
                new Category { Id = 4, Name = "Tequila"}
            };

            var measuringUnits = new MeasuringUnit[]
            {
                new MeasuringUnit { Id = 1, Name = "deel"},
                new MeasuringUnit { Id = 2, Name = "gram"},
                new MeasuringUnit { Id = 3, Name = "tl"},
                new MeasuringUnit { Id = 4, Name = "eigen voorkeur"},
                new MeasuringUnit { Id = 5, Name = "enkele druppels"},
                new MeasuringUnit { Id = 6, Name = "enkele"}
            };

            var Tools = new Tool[]
            {
                new Tool { Id = 1, Name = "Jigger" ,Picture = "Jigger.png"},
                new Tool { Id = 2, Name = "Stirrer",Picture ="Stirrer.png"},
                new Tool { Id = 3, Name = "Shaker", Picture = "Shaker.png"},
                new Tool { Id = 4, Name = "Maatbeker",Picture ="Maatbeker.png"},
                new Tool { Id = 5, Name = "Ijshamer", Picture ="Ijshamer.png"},
                new Tool { Id = 6, Name = "Rasper", Picture ="Rasp.png"},
                new Tool { Id = 7, Name = "Strainer", Picture ="Strainer.png"}

            };

            var cocktails = new Cocktail[]
            {
                new Cocktail {
                    Id = 1, Name ="Corpse Reviver",GlassTypeId = 1,CocktailCategoryId = 1,Picture ="Corpse Reviver.png",
                    Instrucktions="Doe het gehakte ij in een mengglas.;Scheck de cognac, appelbrandwijn en vermout erop.;" +
                                  "Roer voorzichtig.;schenk het mengsel in een gekoeld cocktailglas.",UserId = users[0].Id
                },
                new Cocktail {
                    Id = 2, Name ="Adam's Apple",GlassTypeId = 2,CocktailCategoryId = 1,Picture ="Adams apple.png",
                    Instrucktions="Doe de ingrediënten met ijs in een mengglas.;Roer en scheck het mengels door de strainer in een gekoeld glas",UserId = users[0].Id
                },
                new Cocktail {
                    Id = 3, Name ="Lime Swizzle",GlassTypeId = 1,CocktailCategoryId = 2,
                    Instrucktions="Wrijf de rand van een cocktailglas in met Drambuie.;" +
                    "Meng de geraspte limoenschil en suiker en draai de rand van het glass door het mengsel.;" +
                    "Roer alle ingrediënten inclusief de rest van het suikermengsel in het met ijs gevulde cocktailglas.;" +
                    "Vul het geheel aan met spuitwater naar smaak.",UserId = users[0].Id
                },
                new Cocktail {
                    Id = 4, Name ="Highland Raider",GlassTypeId = 3,CocktailCategoryId = 2,Picture ="Highland Raider.png",
                    Instrucktions="Roer de eerste drie ingrediënten met ijs.;" +
                    "Schenk het mengels door een strainer in een whisky-of longdrinkglass,voeg meer ijs toe en vul" +
                    "het geheel aan met spuitwater naar smaak.;" +
                    "Garneer met een paar frambozen.",UserId = users[0].Id
                },
                new Cocktail {
                    Id = 5, Name ="Palm Beach",GlassTypeId = 2,CocktailCategoryId = 3,Picture ="Palm Beach.png",
                    Instrucktions="Shake de rum,gin en het ananassap met ijs.;" +
                    "Schenk het mengsel door de strainer in een gekoeld longdrinkglas",UserId = users[1].Id
                },
                new Cocktail {
                    Id = 6, Name ="Tequila Sunrise",GlassTypeId = 2,CocktailCategoryId = 4,Picture ="Tequila Sunrise.png",
                    Instrucktions="Scheck de tequila in een gekoeld longdrinkglas met gehakt ij en vul hem met sinaasappelsap.;" +
                    "Schenk langzaam de grenadine erbij en serveer deze longdrink met een rietje",UserId = users[1].Id
                }
            };

            var CocktailTools = new[]
            {
                new {CocktailsId = 1, ToolsId = 1},
                new {CocktailsId = 1, ToolsId = 3},
                new {CocktailsId = 2, ToolsId = 1},
                new {CocktailsId = 2, ToolsId = 2},
                new {CocktailsId = 3, ToolsId = 1},
                new {CocktailsId = 3, ToolsId = 2},
                new {CocktailsId = 3, ToolsId = 6},
                new {CocktailsId = 4, ToolsId = 1},
                new {CocktailsId = 4, ToolsId = 2},
                new {CocktailsId = 4, ToolsId = 7},
                new {CocktailsId = 5, ToolsId = 1},
                new {CocktailsId = 5, ToolsId = 3},
                new {CocktailsId = 5, ToolsId = 7},
                new {CocktailsId = 6, ToolsId = 1}
            };

            var CocktailIngredients = new CocktailIngredient[]
            {
                new CocktailIngredient {CocktailId = 1
                ,IngredientId = 1,Amount="2",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 1
                ,IngredientId = 2,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 1
                ,IngredientId = 3,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 1
                ,IngredientId = 18,MeasuringUnitId=4},

                new CocktailIngredient {CocktailId = 2
                ,IngredientId = 2,Amount="2",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 2
                ,IngredientId = 5,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 2
                ,IngredientId = 6,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 2
                ,IngredientId = 7,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 2
                ,IngredientId = 4,MeasuringUnitId=4},

                new CocktailIngredient {CocktailId = 3
                ,IngredientId = 8,Amount="1 1/2",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 3
                ,IngredientId = 9,Amount="1/4",MeasuringUnitId = 3},
                new CocktailIngredient {CocktailId = 3
                ,IngredientId = 11,Amount="1",MeasuringUnitId = 3},
                new CocktailIngredient {CocktailId = 3
                ,IngredientId = 10,MeasuringUnitId = 5},
                new CocktailIngredient {CocktailId = 3
                ,IngredientId = 4,MeasuringUnitId=4},
                new CocktailIngredient {CocktailId = 3
                ,IngredientId = 12,MeasuringUnitId=4},

                new CocktailIngredient {CocktailId = 4
                ,IngredientId = 8,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 4
                ,IngredientId = 13,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 4
                ,IngredientId = 14,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 4
                ,IngredientId = 4,MeasuringUnitId=4},
                new CocktailIngredient {CocktailId = 4
                ,IngredientId = 12,MeasuringUnitId=4},
                new CocktailIngredient {CocktailId = 4
                ,IngredientId = 15,MeasuringUnitId = 6},

                new CocktailIngredient {CocktailId = 5
                ,IngredientId = 16,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 5
                ,IngredientId = 5,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 5
                ,IngredientId = 17,Amount="1",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 5
                ,IngredientId = 4,MeasuringUnitId=4},

                new CocktailIngredient {CocktailId = 6
                ,IngredientId = 19,Amount="2",MeasuringUnitId = 1},
                new CocktailIngredient {CocktailId = 6
                ,IngredientId = 18,MeasuringUnitId = 4},
                new CocktailIngredient {CocktailId = 6
                ,IngredientId = 20,MeasuringUnitId = 4},
                new CocktailIngredient {CocktailId = 6
                ,IngredientId = 21,Amount="1",MeasuringUnitId=1},

            };

            modelBuilder.Entity<Cocktail>()
                .HasMany(c => c.Tools)
                .WithMany(t => t.Cocktails)
                .UsingEntity(x => x.HasData(CocktailTools));

            modelBuilder.Entity<IngredientType>().HasData(ingredientTypes);
            modelBuilder.Entity<MeasuringUnit>().HasData(measuringUnits);
            modelBuilder.Entity<Ingredient>().HasData(ingredients);
            modelBuilder.Entity<GlassType>().HasData(glasses);
            modelBuilder.Entity<Category>().HasData(cocktailCategories);
            modelBuilder.Entity<Cocktail>().HasData(cocktails);
            modelBuilder.Entity<Tool>().HasData(Tools);
            modelBuilder.Entity<CocktailIngredient>().HasData(CocktailIngredients);

            modelBuilder.Entity<Address>().HasData(address);
            modelBuilder.Entity<ApplicationUser>().HasData(users);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(claims);
        }
    }
}
