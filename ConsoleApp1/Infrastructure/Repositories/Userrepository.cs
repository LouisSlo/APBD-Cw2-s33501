namespace ConsoleApp1.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Domain.Users;

public class Userrepository
{
    private readonly List<User> _users = new();
    public void Add(User user) => _users.Add(user);
    public User? GetById(Guid id) => _users.FirstOrDefault(u => u.Id == id);
    public List<User> GetAll() => _users;
}