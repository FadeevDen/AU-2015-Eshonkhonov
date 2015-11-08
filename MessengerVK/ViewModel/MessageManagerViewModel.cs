
using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MessengerVK.ViewModel
{


    public class MessageManagerViewModel :INotifyPropertyChanged
    {

        
         public MessageManagerViewModel()
        {
             FriendModel.FriendListSingelton.UpdateFriendList();
             FriendModel.FriendListSingelton.TimerUpdateFriendList();
             FriendsList = FriendModel.FriendListSingelton.GetInstance().FriendsList;
        }
        public List<Friend> FriendsList
        {
            get
            {
                return FriendModel.FriendListSingelton.GetInstance().FriendsList;
            }

            set
            {
                FriendModel.FriendListSingelton.GetInstance().FriendsList = value;
                OnPropertyChanged("FriendList");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Friend> GetFriendList()
        {
            return FriendsList;
        }

        public ICommand SortFriendsListByAlphabet
        {
            get
            {
                return new RelayCommand((args) =>
                {
                    GetSortListByOnline();
                });
            }
        }

        public List<Friend> GetSortListByOnline()
        {
            
            FriendsList = new List<Friend>(FriendsList.OrderByDescending(friend => friend.Online));
            return FriendsList;
        } 


    }
}


