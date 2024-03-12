using AutoMapper;
using MediatR;
using Medium.Application.Absatractions;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Domain.DTOs;
using Medium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Handler
{
    public class UpdateUserCommandHandler(IApplicationDbContext _dbContext) : IRequestHandler<UpdateUserCommand, User>
    {
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id == request.Id && x.IsDeleted != true);

            if (user != null)
            {
                user.ModifiedDate = DateTime.UtcNow;
                user.Name = request.Name;
                user.Email = request.Email;
                user.UserName= request.UserName;
                user.Bio = request.Bio;
                user.PhotoPath= request.PhotoPath;
                user.FollowersCount= request.FollowersCount;
                user.Login=request.Login;
                user.Password=request.Password;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return user;
            }
            return new User();
        }
    }
}
