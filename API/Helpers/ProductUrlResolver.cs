using API.DTO;
using AutoMapper;
using AutoMapper.Configuration;
using Core.Entities;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}