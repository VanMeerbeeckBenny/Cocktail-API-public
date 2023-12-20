using Microsoft.AspNetCore.Http;
using Pri.Cocktails.Api.Dtos.CocktailIngredients;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.Cocktails.Api.Dtos.Cocktails
{
    public class CocktailUpdateRequestDto : CocktailRequestDto
    {
        [Required(ErrorMessage = "Please provied a {0}")]
        public int Id { get; set; }
    }
}
