﻿using _4_DM2.Learning.Domain.Entities;
using _4_DM2.Learning.Domain.Interfaces.Repositories;
using _5_DM2.Learning.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace _5_DM2.Learning.Infra.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(DM2Context dM2Context) : base(dM2Context) {}

    public async Task<bool> ValidateUser(string login, string password)
    {
        await Task.Delay(1);

        return true;
    }

    public async Task<User> GetUserByName(string name)
    {
        var user =  await _context.Users
                        .Include(user => user.UserImage)
                        .FirstOrDefaultAsync(user => user.Name.Equals(name));

        return user;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var user =  await _context.Users
                        .Include(user => user.UserImage)
                        .FirstOrDefaultAsync(user => user.Id.Equals(id));

        return user;
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);

        await SaveChanges();
    }

    public async Task EditUser(User user)
    {
        _context.Attach(user).State = EntityState.Modified;
        _context.Attach(user.UserImage).State = EntityState.Modified;

        await SaveChanges();
    }

    public async Task DeleteUser(Guid id)
    {
        User user = await GetUserById(id);

        _context.Remove(user);

        await SaveChanges();
    }
}
