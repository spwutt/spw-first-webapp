using spw_first_webapp.Model;

namespace spw_first_webapp.Services
{
    public interface IProfileService
    {
        Task<MyProfile> GetProfile();
    }

    public class ProfileService : IProfileService
    {
        private readonly IRequestService _requestservice;

        public ProfileService(IRequestService requestservice)
        {
            _requestservice = requestservice;
        }

        public async Task<MyProfile> GetProfile()
        {
            MyProfile result = null;

            try
            {
                string url = $"/api/profile/myprofile";

                result = await _requestservice.GetAsync<MyProfile>("myapi", url);
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
