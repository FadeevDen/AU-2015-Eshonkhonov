using MessengerVK.ViewModel;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;


namespace MessengerVK
{
    
    public  class SignInViewModel :INotifyPropertyChanged
    {
        private string _status;
        private const int appID = 5074413; // ID приложения
        private string login; // email или телефон
        private string password; // пароль для авторизации
        private static AuthInformation authInformation;
        private Visibility isVisible;
        private Settings scope; //Уровень доступа
        private User user;
        private VkApi api;
        private ICommand buttonSign;

        public event PropertyChangedEventHandler PropertyChanged;

        public string status
        {
            get { return _status; }
            set
            {
                _status = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this,
                        new PropertyChangedEventArgs("status"));
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

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this,
                        new PropertyChangedEventArgs("Login"));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this,
                        new PropertyChangedEventArgs("Password"));
            }
        }

        public Visibility IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                isVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this,
                        new PropertyChangedEventArgs("IsVisible"));
            }
        }
        //Methods
        public SignInViewModel()
        {
            scope = Settings.All;
            User = new User();
            authInformation = new AuthInformation();
            api = new VkApi();
            MainWindow.messageManager = new MessageManager();
        }
        public void StartUpMessageManager()
        {           
            MainWindow.messageManager.InitializeComponent();           
            MainWindow.messageManager.ShowDialog();
        }
        private async Task Wait()
        {
            await Task.Delay(1000);
        }

        public async void Authorization()
        {
            if (login != null && password != null)
            {
                try
                {
                    Api.Authorize(appID, Login, Password, scope);
                    User = Api.Users.Get(Int64.Parse(Api.UserId.ToString()), ProfileFields.All);
                    status = authInformation.AuthSuccessful;
                    SaveData.Save(Api, User);
                    await Wait();
                    IsVisible = Visibility.Collapsed;
                    StartUpMessageManager();
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
        }
       
        public ICommand ButtonSign
        {
            get { return buttonSign ?? (buttonSign = new RelayCommand((args) => { Password = ((PasswordBox)args).Password; Authorization(); })); }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
