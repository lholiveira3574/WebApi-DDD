

using System;
using AutoMapper;
using WebApi.CrossCutting.Mappings;

namespace WebApi.Service.Test
{
    public abstract class BaseTestService
    {
        public IMapper Mapper { get; set; }
        public BaseTestService()
        {
            Mapper = new AtuoMapperFixture().GetMapper();
        }

        public class AtuoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new DtoToModelProfile());
                    cfg.AddProfile(new EntityToDtoProfile());
                });

                return config.CreateMapper();
            }
            
            public void Dispose()
            {
                
            }
        }
    }
}
