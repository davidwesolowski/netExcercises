using System.ComponentModel.DataAnnotations;

namespace demo.Domain
{
    public class UserProfile
    {
        public UserProfile(UserData userData)
        {
            UserData = userData;
        }

        public UserProfile()
        {
            UserData = new UserData();
            
        }

        [UIHint("UserCard")] public UserData UserData { get; set; }
    }
}