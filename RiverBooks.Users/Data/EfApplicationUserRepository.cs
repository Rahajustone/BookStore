﻿using Microsoft.EntityFrameworkCore;
using static RiverBooks.Users.UserModuleExtensions;

namespace RiverBooks.Users.Data;

public class EfApplicationUserRepository : IApplicationUserRepository
{
    private readonly UsersDbContext _dbContext;

    public EfApplicationUserRepository(UsersDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<ApplicationUser> GetUserWithCartByEmailAsync(string email)
    {
        return _dbContext.ApplicationUsers
            .Include(user => user.CartItems)
            .SingleAsync(user => user.Email == email);
    }

    public Task SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}