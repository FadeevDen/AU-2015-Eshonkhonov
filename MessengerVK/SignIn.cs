using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace MessengerVK
{
   public class SignIn
   {

       private const int appID= 5074413;                    // ID приложения
       private string login;                 // email или телефон
       private string password;              // пароль для авторизации
       private Settings scope;               //Уровень доступа
       private VkApi api;
       private User user;
   
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

        public SignIn(string login,string password,Settings scope)
       {
            
            this.login = login;
            this.password = password;
            this.scope = scope;
        }
        [STAThread]
       public void AuthMethod()
       {
            Api = new VkApi();
            Api.Authorize(appID, login, password, scope);
       }

       public void GetProfileInfo()
       {
           user = new User();
           if (api.UserId != null) user = api.Users.Get((long) api.UserId, ProfileFields.All, null);
       }
   }

   
}
