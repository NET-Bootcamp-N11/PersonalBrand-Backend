using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using PersonalBrand.Application.UseCases.IdentitieCases.Queries;
using PersonalBrand.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBrand.Application.UseCases.IdentitieCases.Handlers.QueryHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IMemoryCache _memoryCache;

        public GetAllUsersQueryHandler(UserManager<UserModel> userManager, IMemoryCache memoryCache)
        {
            _userManager = userManager;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            object userModel = _memoryCache.Get("users");
            if (userModel == null)
            {
                ImmutableList<UserModel>? userModel1 = _userManager.Users.ToImmutableList();
                _memoryCache.Set("users", userModel1);
            }

            return userModel as IEnumerable<UserModel>;
        }
    }
}
