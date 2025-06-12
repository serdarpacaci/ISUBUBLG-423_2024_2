using IsubuSatis.Siparis.Application.Queries.Dtos;
using IsubuSatis.Siparis.Persistence;
using MediatR;

namespace IsubuSatis.Siparis.Application.Queries.Handlers
{
    public class GetSiparislerbyUserIdQueryHandler : IRequestHandler<GetSiparislerByUserIdQuery, List<SiparisDto>>
    {
        private readonly SiparisDbContext siparisDbContext;

        public GetSiparislerbyUserIdQueryHandler(SiparisDbContext siparisDbContext)
        {
            this.siparisDbContext = siparisDbContext;
        }
        public Task<List<SiparisDto>> Handle(GetSiparislerByUserIdQuery request, CancellationToken cancellationToken)
        {
            //siparisDbContext.

            return Task.FromResult(new List<SiparisDto>());
        }
    }
}
