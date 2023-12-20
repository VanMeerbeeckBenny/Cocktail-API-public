namespace Pri.Cocktails.Api.Dtos.Ingredients
{
    public class IngredientBasicResponseDto:BaseResponseDto
    {
        public string Name { get; set; }
        public string IngredientType { get; set; }
        public int IngredientTypeId { get; set; }
        public string Picture { get; set; }
    }
}
