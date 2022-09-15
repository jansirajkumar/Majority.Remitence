using AutoMapper;

namespace Majority.RemittanceProvider.Application.Tests.Helpers
{
    public static class AutoMapperHelper
    {
        public static IMapper GetMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(typeof(Transformers.MappingProfile));
            });

            return mappingConfig.CreateMapper();
        }
    }
}
