using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Brands.Queries.GetAllCached
{
    public class GetAllBrandsCachedQuery : IRequest<Result<List<GetAllBrandsCachedResponse>>>
    {
        public GetAllBrandsCachedQuery()
        {
        }
    }

    public class GetAllBrandsCachedQueryHandler : IRequestHandler<GetAllBrandsCachedQuery, Result<List<GetAllBrandsCachedResponse>>>
    {
        private readonly IBrandCacheRepository _brandCache;
        private readonly IMapper _mapper;

        public GetAllBrandsCachedQueryHandler(IBrandCacheRepository brandCache, IMapper mapper)
        {
            _brandCache = brandCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllBrandsCachedResponse>>> Handle(GetAllBrandsCachedQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _brandCache.GetCachedListAsync();
            var mappedBrands = _mapper.Map<List<GetAllBrandsCachedResponse>>(brandList);
            return Result<List<GetAllBrandsCachedResponse>>.Success(mappedBrands);
        }
    }
}