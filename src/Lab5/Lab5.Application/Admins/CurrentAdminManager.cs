using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Admins;

internal class CurrentAdminManager : ICurrentAdminService
{
    public User? User { get; set; }
}