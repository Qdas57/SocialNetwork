using SocialNetwork.Models.Output;
using SocialNetwork.Services.Services;

namespace SocialNetwork.Services.Mapping
{
    public static class UserToProfileOutput
    {
        public static ProfileOutput ToProfileOutput(this UserOutput user)
        {
            var age = DateTime.Now.Year - user.BirthDate.Year;

            CommonService commonService = new CommonService();

            string ageDeclination = commonService.DeclinationOfTheYear(age);

            string onservice = commonService.OnService(user.RegisterDate);

            return new ProfileOutput()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Avatar = user.Avatar,
                BirthDate = user.BirthDate.ToString("D"),
                Age = age,
                AgeDeclination = ageDeclination,
                OnService = onservice
            };
        }
    }
}
