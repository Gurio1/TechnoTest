using System.Threading.Tasks;
using TechnoTest.Models.Identity;
using TechnoTest.ViewModels;

namespace TechnoTest.Services.Abstractions;

public interface IUserService
{
    Task<UserViewModel> GetAsync(int id);
    Task<UserViewModel> CreateAsync(User user,string role);
}