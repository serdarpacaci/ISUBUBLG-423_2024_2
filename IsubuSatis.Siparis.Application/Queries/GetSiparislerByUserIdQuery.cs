using IsubuSatis.Siparis.Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Queries
{
    public class GetSiparislerByUserIdQuery : IRequest<List<SiparisDto>>
    {
        public string UserId { get; set; }
    }
}
