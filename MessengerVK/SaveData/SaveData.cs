using System.Windows;
using VkNet;
using VkNet.Model;

namespace MessengerVK
{
   
    public class SaveData
    {
        private VkApi api;
        private User user;

        public VkApi Api
        {
            get
            {
                return api;
            }

            set
            {
                api = value;
            }
        }

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public static SaveData saveData=new SaveData();
        public static void Save(VkApi api, User user)
        {
            saveData = new SaveData();
            saveData.Api = new VkApi();
            saveData.User = new User();
            saveData.Api = api;
            saveData.User = user;
            
        }
       
    }
}
