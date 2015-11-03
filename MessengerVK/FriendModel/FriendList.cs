using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using MessengerVK.ViewModel;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace MessengerVK.FriendModel
{
    public class FriendList
    {
        private static List<Friend> friendsList = new List<Friend>();

        public static List<Friend> FriendsList
        {
            get
            {
                return friendsList;
            }

            set
            {
                friendsList = value;

            }
        }

        public  List<Friend> GetFriendList()
        {
            return FriendsList;
        }
       public static void TimerUpdateFriendList()
        {
          
            Timer timerUpadate = new Timer();
            timerUpadate.Interval = 30000;      
            timerUpadate.Elapsed +=UpdateFriendListTimer;
           
            timerUpadate.Enabled = true;
            timerUpadate.AutoReset = true;
            timerUpadate.Start();
        }
       
        public  static void UpdateFriendList()
        {
           
                ReadOnlyCollection<User> friendsListTemporary = SaveData.saveData.Api.Friends.Get((long)SaveData.saveData.Api.UserId, ProfileFields.FirstName);
                friendsListTemporary = SaveData.saveData.Api.Friends.Get(long.Parse(SaveData.saveData.Api.UserId.ToString()), ProfileFields.Photo100);
                var f = SaveData.saveData.Api.Friends.GetOnline(SaveData.saveData.User.Id);

                for (int i = 0; i < friendsListTemporary.Count; i++)
                {
                    Friend friendTemplate = new Friend();
                    for (int j = 0; j < f.Count; j++)
                    {
                        if (f[j] == friendsListTemporary[i].Id)
                        {
                            friendTemplate.Online = true;
                        }
                    }
                    friendTemplate.Avatar = friendsListTemporary[i].PhotoPreviews.Photo100;
                    friendTemplate.Name = friendsListTemporary[i].FirstName;
                    friendsList.Add(friendTemplate);
               
            }
        }
        public  static void UpdateFriendListTimer(object sender, ElapsedEventArgs e)
        {
           
                ReadOnlyCollection<User> friendsListTemporary = SaveData.saveData.Api.Friends.Get((long)SaveData.saveData.Api.UserId, ProfileFields.FirstName);
                friendsListTemporary = SaveData.saveData.Api.Friends.Get(long.Parse(SaveData.saveData.Api.UserId.ToString()), ProfileFields.Photo100);
                var f = SaveData.saveData.Api.Friends.GetOnline(SaveData.saveData.User.Id);

                for (int i = 0; i < friendsListTemporary.Count; i++)
                {
                    Friend friendTemplate = new Friend();
                    for (int j = 0; j < f.Count; j++)
                    {
                        if (f[j] == friendsListTemporary[i].Id)
                        {
                            friendTemplate.Online = true;
                        }
                    }
                    friendTemplate.Avatar = friendsListTemporary[i].PhotoPreviews.Photo100;
                    friendTemplate.Name = friendsListTemporary[i].FirstName;
                    if (friendsList.Count!=friendsListTemporary.Count)
                    {
                       friendsList.Clear();
                       UpdateFriendList();
                    }
                    else
                    {
                        friendsList[i] = friendTemplate;
                    }
                    

                }
        }

        public ICommand Sort
        {
            get
            {
                return new RelayCommand((args)=>
                {
                    friendsList.OrderBy(item => item.Name);
                }); 
            }

        }


    }
}
