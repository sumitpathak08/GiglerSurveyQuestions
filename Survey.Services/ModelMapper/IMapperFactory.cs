using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services.ModelMapper
{
    public interface IMapperFactory
    {
        TDestination Get<TSource, TDestination>(TSource source);
        IEnumerable<TDestination> GetList<TSource, TDestination>(IEnumerable<TSource> source);

        List<TDestination> GetList<TSource, TDestination>(List<TSource> source);
    }
}
