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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel>
    {
        private readonly UserManager<UserModel> _manager;
        private readonly IMemoryCache _memoryCache;

        public CreateUserCommandHandler(UserManager<UserModel> manager, IMemoryCache memoryCache)
        {
            _manager = manager;
            _memoryCache = memoryCache;
        }

        public async Task<ResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _memoryCache.Remove("users");
            var user = new UserModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhotoUrl = request.PhotoUrl,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
            };

            await _manager.CreateAsync(user, request.Password);
            return new ResponseModel
            {
                Message = "Yaratildi",
                IsSuccess = true,
                StatusCode = 201
            };
        }
    }
}
