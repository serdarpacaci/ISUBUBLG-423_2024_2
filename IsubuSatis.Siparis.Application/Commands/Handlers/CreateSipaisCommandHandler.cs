using IsubuSatis.Siparis.Application.Commands.Dtos;
using IsubuSatis.Siparis.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Application.Commands.Handlers
{
    public class CreateSipaisCommandHandler : IRequestHandler<CreateSiparisCommand, CreateSiparisDto>
    {
        private readonly SiparisDbContext context;

        public CreateSipaisCommandHandler(SiparisDbContext context)
        {
            this.context = context;
        }
        public Task<CreateSiparisDto> Handle(CreateSiparisCommand request, CancellationToken cancellationToken)
        {
            // await context.Siparisler.AddAsync(new)
            // await context.SaveChangesAsync();

            //

            //if (cancellationToken.IsCancellationRequested)



            return Task.FromResult(new CreateSiparisDto());

        }
    }
}
