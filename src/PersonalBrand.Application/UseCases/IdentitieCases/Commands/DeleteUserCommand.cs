using MediatR;
using PersonalBrand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Application.UseCases.IdentitieCases.Commands
{
    public class DeleteUserCommand: IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
