using Pri.Cocktails.Api.Dtos.Cocktails;
using Pri.Cocktails.Api.Dtos.Ingredients;
using Pri.Cocktails.Api.Dtos.Tools;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Pri.Cocktails.Api.AutoMapper
{
    public class CocktailProfile
    {     

        public static IEnumerable<CocktailResponseDto> CreateResponseDto(IEnumerable<Cocktail> cocktails, IImageService imageService)
        {
            return cocktails.Select(c => new CocktailResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Picture = imageService.GetUrl<Cocktail>(c?.Picture),
                CoctailCategoryId = c.CocktailCategoryId,
                CoctailCategory = c.CocktailCategory.Name,
                GlassTypeName = c.Glass.Name,
                GlassTypeId = c.GlassTypeId,
                GlassTypePicture = imageService.GetUrl<GlassType>(c.Glass.Picture),
                Instrucktions = c.Instrucktions.Split(";"),
                Tools = c.Tools
                                   .Select(t => new ToolResponseDto
                                   {
                                       Id = t.Id,
                                       Name = t.Name,
                                       Picture = imageService.GetUrl<Tool>(t.Picture)
                                   }),
                Ingredients = c.CocktailIngredient
                                   .Where(ci => ci.CocktailId == c.Id)
                                   .Select(ci => new IngredientDetailResponseDto
                                   {
                                       Id = ci.IngredientId,
                                       Name = ci.Ingredient.Name,
                                       IngredientType = ci.Ingredient.IngredientType.Name,
                                       Amount = ci.Amount,
                                       UnitId = ci.MeasuringUnitId,
                                       Unit = ci.MeasuringUnit?.Name ?? "",
                                       Picture = imageService.GetUrl<Ingredient>(ci.Ingredient?.Picture)
                                   }),

            });
        }
    }
}
