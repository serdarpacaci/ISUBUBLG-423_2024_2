using IsubuSatis.Siparis.Application.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Commands
{
    //CQRS
    public class CreateSiparisCommand : IRequest<CreateSiparisDto>
    {
        public string UserId { get; set; }
        public List<SiparisItemDto> SiparisUrunleri { get; set; }
        public AddressDto Address { get; set; }
    }
}
