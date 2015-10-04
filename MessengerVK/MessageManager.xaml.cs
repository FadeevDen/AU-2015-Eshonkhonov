using System;
using System.Collections.ObjectModel;
using System.Windows;
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
        }
        //this method just test get friends list
        private void BnSend_Click(object sender, RoutedEventArgs e)
        {
            VkNet.VkApi Api = new VkNet.VkApi();
            Api.Authorize(5074413,"", "", Settings.All);
            User user = new User();
            user = Api.Users.Get(Int64.Parse(Api.UserId.ToString()), ProfileFields.All);
            ReadOnlyCollection<User> friends=Api.Friends.Get(user.Id, ProfileFields.FirstName);
            foreach (User x in friends)
            {
                ListViewFriendsList.Items.Add(x.FirstName);
            }
            
        }
    }
}
