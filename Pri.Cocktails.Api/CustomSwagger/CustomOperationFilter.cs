using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;
using Pri.Cocktails.Api.Dtos.CocktailIngredients;

namespace Pri.Cocktails.Api.CustumSwagger
{
    public class CustomOperationFilter:IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.RequestBody != null && operation.RequestBody.Content.TryGetValue("multipart/form-data", out var openApiMediaType))
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var array = new OpenApiArray
             {
            new OpenApiString(JsonSerializer.Serialize(new CocktailIngredientRequestDto {IngredientId = 0, Amount="string",MeasuringUnitId=0}, options)),
             };
                if(openApiMediaType.Schema.Properties.Count >=5)
                openApiMediaType.Schema.Properties["Ingredient"].Example = array;
            }
        }
    }
}
