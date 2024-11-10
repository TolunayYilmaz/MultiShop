using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
       public Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
