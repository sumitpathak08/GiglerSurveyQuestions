﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services.ModelMapper
{
    public class MapperFactory : IMapperFactory
    {
        public MapperFactory()
        {
            
        }
        public TDestination Get<TSource, TDestination>(TSource source)
        {
            IMapper mapper = setConfig<TSource, TDestination>();
            return mapper.Map<TSource, TDestination>(source);
        }
        public IEnumerable<TDestination> GetList<TSource, TDestination>(IEnumerable<TSource> source)
        {
            IMapper mapper = setConfig<TSource, TDestination>();
            return mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
            //return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }
        public List<TDestination> GetList<TSource, TDestination>(List<TSource> source)
        {
            IMapper mapper = setConfig<TSource, TDestination>();
            return mapper.Map<List<TSource>, List<TDestination>>(source);
            //return Mapper.Map<List<TSource>, List<TDestination>>(source);
        }
        public IMapper setConfig<TSource, TDestination>()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>().IgnoreAllNonExisting();//.ForMember(x => x.DestinationPropertyName, opt => opt.Ignore());
            });
            IMapper mapper = config.CreateMapper();
            return mapper;

        }
    }

}
