using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DTOs
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Entity.Product, DTOs.ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null));

            CreateMap<Category, CategoryDto>();

        }
    }
}
