using System;

using System.Collections.Generic;

using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using FriendList = MessengerVK.FriendModel.FriendList;


namespace MessengerVK.ViewModel
{


    public class MessageManagerViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private List<Friend> friendsList = new List<Friend>();
       

        public MessageManagerViewModel()
        {

            FriendModel.FriendList.UpdateFriendList();
            FriendsList = FriendModel.FriendList.FriendsList;
        }

       
       
        public List<Friend> FriendsList
        {
            get { return friendsList; }

            set
            {
                friendsList = value;
                RaisePropertyChanged(() => FriendsList);
            }
        }

        public List<Friend> GetFriendList()
        {
            return FriendsList;
        }

        
    }
}


