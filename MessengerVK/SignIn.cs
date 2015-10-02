using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Exception;

namespace MessengerVK
{
    public class SignIn : ViewModelBase
    {
        private string _status;
        private const int appID = 5074413; // ID приложения
        private Settings scope = Settings.All; //Уровень доступа
        private User user;
        private ICommand _buttonSign;

        private AuthInformation authInformation=new AuthInformation();
        private VkApi api = new VkApi();

        public string login { get; set; } // email или телефон
        public string password { get; set; } // пароль для авторизации

        public string status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged(() => status);
            }
        }

        public ICommand ButtonSign
        {
            get
            {
                return _buttonSign ?? (_buttonSign = new RelayCommand(() =>
                {

                    if (login != null && password != null)
                    {
                        try
                        {
                            api.Authorize(appID, login, password, scope);
                            user = api.Users.Get(Int64.Parse(api.UserId.ToString()), ProfileFields.All);
                            status = authInformation.AuthSuccessful;
                            /* IReadOnlyCollection<User> friends = new Collection<User>();
                       friends = api.Friends.Get(user.Id, ProfileFields.FirstName);
                       foreach(User x in friends)
                       MessageBox.Show(x.FirstName);*/

                        }
                        catch
                        {
                            status = authInformation.AuthFailed;
                        }
                    }
                    else
                    {
                        status = authInformation.NullField;
                    }
                }));
            }
        }
    }
}
