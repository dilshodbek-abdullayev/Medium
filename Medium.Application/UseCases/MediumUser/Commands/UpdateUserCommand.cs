using MediatR;
using Medium.Domain.DTOs;
using Medium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Commands
{
    public class UpdateUserCommand : UserDTO, IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
