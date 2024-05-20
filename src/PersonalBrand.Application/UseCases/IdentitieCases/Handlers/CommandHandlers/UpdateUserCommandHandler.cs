using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using PersonalBrand.Application.UseCases.IdentitieCases.Commands;
using PersonalBrand.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Application.UseCases.IdentitieCases.Handlers.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel>
    {
        private readonly UserManager<UserModel> _manager;
        private readonly IMemoryCache _memoryCache;

        public UpdateUserCommandHandler(UserManager<UserModel> manager, IMemoryCache memoryCache = null)
        {
            _manager = manager;
            _memoryCache = memoryCache;
        }

        public async Task<ResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _memoryCache.Remove("users");

            var user = await _manager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhotoUrl = request.PhotoUrl;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                user.UserName = request.UserName;

                var result = await _manager.UpdateAsync(user);

                return new ResponseModel
                {
                    Message = "Updated",
                    IsSuccess = true,
                    StatusCode = 204
                };
            }

            return new ResponseModel
            {
                Message = "User Not Found",
                IsSuccess = true,
                StatusCode = 404
            };


        }
    }
}
