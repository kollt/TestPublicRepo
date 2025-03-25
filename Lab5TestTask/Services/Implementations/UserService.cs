using Lab5TestTask.Data;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// UserService implementation.
/// Implement methods here.
/// </summary>
public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser()
    {
        return await _dbContext.Users.OrderBy(u => u.Sessions.Count()).LastOrDefaultAsync();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users.Where(u => u.Sessions.Any(s=> s.DeviceType == Enums.DeviceType.Mobile)).ToListAsync();
    }
}
