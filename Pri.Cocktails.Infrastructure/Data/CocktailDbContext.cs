using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Cocktails.Infrastructure.Data
{
    public class CocktailDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<CocktailIngredient> CocktailIngredient { get; set; }
        public DbSet<Category> CocktailCategories { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MeasuringUnit> MeasuringUnits { get; set; }
        public DbSet<Tool> Tools { get; set; }

        public CocktailDbContext(DbContextOptions<CocktailDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CocktailIngredient>()
                .HasKey(x => new { x.IngredientId, x.CocktailId });

            modelBuilder.Entity<CocktailIngredient>()
                .HasOne(x => x.Ingredient)
                .WithMany(x => x.CocktailIngredient)
                .HasForeignKey(x => x.IngredientId);

            modelBuilder.Entity<CocktailIngredient>()
                .HasOne(x => x.Cocktail)
                .WithMany(x => x.CocktailIngredient)
                .HasForeignKey(x => x.CocktailId);

            Seeder.Seed(modelBuilder);

        }
    }
}
