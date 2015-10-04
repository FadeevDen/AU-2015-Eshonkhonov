using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;


namespace MessengerVK
{
    public  class SignIn : ViewModelBase, INotifyPropertyChanged
    {
        private string _status;
        private const int appID = 5074413; // ID приложения
        public string login { get; set; } // email или телефон
        public string password { get; set; } // пароль для авторизации

        private Settings scope = Settings.All; //Уровень доступа
        private User user = new User();
        private AuthInformation authInformation=new AuthInformation();
        private VkApi api = new VkApi();
        private Visibility isVisibilitySingInForm=Visibility.Visible;
        private Visibility isVisibilityMessageManagerForm;
       
        public string status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged(() => status);
            }
        }
        private ICommand _buttonSign;
        public ICommand ButtonSign
        {
            get
            {
                return _buttonSign ?? (_buttonSign = new RelayCommand(async () =>
                {

                    if (login != null && password != null)
                    {
                        try
                        {
                            Api.Authorize(appID, login, password, scope);
                            user = Api.Users.Get(Int64.Parse(Api.UserId.ToString()), ProfileFields.All);
                            status = authInformation.AuthSuccessful;
                            await WaitAsynchronouslyAsync();
                            IsVisibilitySignInForm = Visibility.Collapsed;
                            App.MessengeManagerApplicationStartup();
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

        public VkApi Api
        {
            get
            {
                return api;
            }

            set
            {
                api = value;
                RaisePropertyChanged(() => Api);
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
                RaisePropertyChanged(()=>User);
            }
        }

        public Visibility IsVisibilitySignInForm
        {
            get
            {
                return isVisibilitySingInForm;
            }

            set
            {
                isVisibilitySingInForm = value;
                RaisePropertyChanged(() => IsVisibilitySignInForm);
            }
        }

        public Visibility IsVisibilityMessageManagerForm
        {
            get
            {
                return isVisibilityMessageManagerForm;
            }

            set
            {
                isVisibilityMessageManagerForm = value;
                RaisePropertyChanged(() => IsVisibilityMessageManagerForm);
            }
        }

        public async Task WaitAsynchronouslyAsync()
        {
            await Task.Delay(3000);
        }

       
    }
}
