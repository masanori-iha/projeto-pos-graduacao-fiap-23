﻿using _3_DM2.Learning.Application.interfaces;
using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Domains;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DM2.Learning.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserAppService(IUserService userService,
                               IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetUserByName(string name)
        {
            return _mapper.Map<UserViewModel>(await _userService.GetUserByName(name));
        }

        public async Task<UserViewModel> GetUserById(Guid id)
        {
            return _mapper.Map<UserViewModel>(await _userService.GetUserById(id));
        }

        public async Task AddUser(UserViewModel userViewModel)
        {
            await _userService.AddUser(_mapper.Map<User>(userViewModel));
        }

        public async Task EditUser(UserViewModel userViewModel)
        {
            await _userService.Edituser(_mapper.Map<User>(userViewModel));
        }
    }
}
