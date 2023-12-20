using Pri.Cocktails.Api.Dtos.Ingredients;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Pri.Cocktails.Api.AutoMapper
{
    public class IngredientProfile
    {
        public static  IEnumerable<IngredientBasicResponseDto> CreateResponseDto(IEnumerable<Ingredient> ingredients, IImageService imageService)
        {
            return ingredients
                       .OrderBy(g => g.Name)
                       .Select(g => new IngredientBasicResponseDto
                       {
                           Id = g.Id,
                           Name = g.Name,
                           IngredientType = g.IngredientType.Name,
                           IngredientTypeId =  g.IngredientTypeId,
                           Picture = imageService.GetUrl<Ingredient>(g?.Picture)
                       }).ToList();
        }
    }
}
