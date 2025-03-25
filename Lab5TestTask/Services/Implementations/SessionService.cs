using Lab5TestTask.Data;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// SessionService implementation.
/// Implement methods here.
/// </summary>
public class SessionService : ISessionService
{
    private readonly ApplicationDbContext _dbContext;

    public SessionService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Session> GetSessionAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Session>> GetSessionsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Session> GetSession()
    {
        return await _dbContext.Sessions.Where(s => s.DeviceType == Enums.DeviceType.Desktop).OrderBy(s => s.StartedAtUTC).FirstOrDefaultAsync();
    }
    public async Task<List<Session>> GetSessions()
    {
        return await _dbContext.Sessions.Where(s => s.User != null && (int)s.User.Status == 1).Where(s => s.EndedAtUTC < new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)).ToListAsync();
    }
}
