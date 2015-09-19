using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
namespace VKM
{
    class Login
    {
        protected const int appId = 5074413; // указываем id приложения
        private string login; // email для авторизации
        private string password; // пароль
        Settings settings = Settings.All; // уровень доступа к данным
        private VkApi api;

        public Login(string login, string password)
        {
            api = new VkApi();
            this.login = login;
            this.password = password;
        }

        public Login()
        {
            api = new VkApi();
        }

        public void AuthMethod()
        {

            api.Authorize(appId, login, password, settings); // авторизуемся
        }

        public VkApi GetAPI()
        {
            return api;
        }
    }
}
