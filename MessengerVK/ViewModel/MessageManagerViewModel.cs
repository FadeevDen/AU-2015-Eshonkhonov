
using System.Collections.Generic;

using System.ComponentModel;

namespace MessengerVK.ViewModel
{


    public class MessageManagerViewModel :INotifyPropertyChanged
    {

        private List<Friend> friendsList = new List<Friend>();
         public MessageManagerViewModel()
        {
            FriendModel.FriendList.UpdateFriendList();
            FriendModel.FriendList.TimerUpdateFriendList();
            FriendsList = FriendModel.FriendList.FriendsList;
        }
        public List<Friend> FriendsList
        {
            get { return friendsList; }

            set
            {
                friendsList = value;
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

        
    }
}


