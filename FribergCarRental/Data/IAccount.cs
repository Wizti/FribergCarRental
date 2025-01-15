﻿using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data
{
    public interface IAccount
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByUsernameAsync(string username);
        void Add(CreateViewModel createVM);
    }
}
