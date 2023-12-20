namespace Pri.Cocktails.Api.Dtos.Ingredients
{
    public class IngredientDetailResponseDto:BaseResponseDto
    {        
        public string Name { get; set; }
        public string IngredientType { get; set; }
        public string Picture { get; set; }
        public string Amount { get; set; }
        public int? UnitId { get; set; }
        public string Unit { get; set; }
    }
}
