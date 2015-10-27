using System;
using System.Timers;
using System.Windows;
using MessengerVK.ViewModel;
using VkNet.Enums.Filters;
using VkNet.Model;


namespace MessengerVK
{
    /// <summary>
    /// Логика взаимодействия для MessageManager.xaml
    /// </summary>
    public partial class MessageManager : Window
    {
        public MessageManager()
        {

            InitializeComponent();
           

         
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageManagerViewModel myDataCtx = new MessageManagerViewModel();
            DataContext = myDataCtx.FriendsList;
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
      

      
    }
   

}
