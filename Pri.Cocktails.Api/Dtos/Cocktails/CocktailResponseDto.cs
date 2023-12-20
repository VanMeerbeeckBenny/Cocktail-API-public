using System.Collections.Generic;
using Pri.Cocktails.Api.Dtos.GlassTypes;
using Pri.Cocktails.Api.Dtos.Ingredients;
using Pri.Cocktails.Api.Dtos.Tools;


namespace Pri.Cocktails.Api.Dtos.Cocktails
{
    public class CocktailResponseDto : BaseResponseDto
    {
        //[JsonPropertyName("Name")] for better deserialization
        public string Name { get; set; }
        public int? CoctailCategoryId { get; set; }
        public string CoctailCategory { get; set; }
        public string [] Instrucktions { get; set; }
        public int? GlassTypeId { get; set; }
        public string GlassTypeName { get; set; }
        public string GlassTypePicture { get; set; }
        public IEnumerable<ToolResponseDto> Tools { get; set; }
        public IEnumerable<IngredientDetailResponseDto> Ingredients { get; set; }
        public string Picture { get; set; }


    }
}
