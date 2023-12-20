using Microsoft.AspNetCore.Http;

namespace Pri.Cocktails.Api.Dtos.GlassTypes
{
    public class GlassTypeResponseDto : BaseResponseDto 
    {
        public string Name { get; set; }
        public string Picture { get; set; }

    }
}
