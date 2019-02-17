﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using YS.CMS.Domain.Entities;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Infra.Security
{
    public class UserHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public UserHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<UserManagerResultModel> CreateUser(RegisterModel model)
        {
            var user = new User { UserName = model.Login };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return new UserManagerResultModel { Succeeded = true };
            }
            return new UserManagerResultModel { Succeeded = false };
        }

        public async Task<UserManagerResultModel> LoginUser(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
            if (result.Succeeded)
            {
                return new UserManagerResultModel() { Succeeded = true };
            }
            return new UserManagerResultModel() { Succeeded = false };
        }
    }
}
