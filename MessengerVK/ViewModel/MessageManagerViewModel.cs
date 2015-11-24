using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Windows.Input;
using MessengerVK.Builder;
using Message = MessengerVK.Builder.Message;


namespace MessengerVK.ViewModel
{


    public class MessageManagerViewModel : INotifyPropertyChanged
    {
        ICommand writeMessage;

        int indexSelectedFriend;

        public int IndexSelectedFriend
        {
            get { return indexSelectedFriend; }
            set
            {
                indexSelectedFriend = value;
                OnPropertyChanged("IndexSelectedFriend");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MessageManagerViewModel()
        {

            FriendModel.FriendListSingelton.UpdateFriendList();
            FriendModel.FriendListSingelton.TimerUpdateFriendList();
            FriendsList = FriendModel.FriendListSingelton.GetInstance().FriendsList;
        }


        public List<Friend> FriendsList
        {
            get { return FriendModel.FriendListSingelton.GetInstance().FriendsList; }

            set
            {
                FriendModel.FriendListSingelton.GetInstance().FriendsList = value;
                OnPropertyChanged("FriendList");
            }
        }

        public List<Message> MessageList
        {
            get { return ChatHistory.GetInstance(FriendsList[IndexSelectedFriend].Id).ChatHistoryList; }
            set
            {
                ChatHistory.GetInstance(FriendsList[IndexSelectedFriend].Id).ChatHistoryList = value;
                OnPropertyChanged("MessageList");
            }
        }


        private string _myHtml;

        public string MyHtml
        {
            get { return _myHtml; }
            set
            {
                if (_myHtml != value)
                {
                    _myHtml = value;
                    OnPropertyChanged("MyHtml");
                }
            }
        }

        public ICommand WriteMessage
        {
            get
            {
                return writeMessage = new RelayCommand((o =>
                {

                    WriteMessageMethod();

                }));
            }
        }

        private void WriteMessageMethod()
        {
            MessageList = new List<Message>();
            MessageList = ChatHistory.GetInstance(FriendsList[IndexSelectedFriend].Id).ChatHistoryList;
            Director director = new Director();
            Builder.Builder builder2 = new ChatWithEmoji();
            Builder.Builder builder = new ChatWithOutEmoji();
            String SelectedFriendName = FriendsList[IndexSelectedFriend].Name;
            string SelectedFriendLastName = FriendsList[IndexSelectedFriend].LastName;
            string path = "";
            _myHtml = String.Empty;
            MyHtml = MessageList.Count >= 0 ? IfHaveAnyMessageWithSelectedFriend(path, builder, builder2,SelectedFriendName,SelectedFriendLastName) : string.Empty;

        }

        private string IfHaveAnyMessageWithSelectedFriend(string path, Builder.Builder builder, Builder.Builder builder2,string Name,string LastName)
        {
            foreach (var vm in MessageList)
            {
                path += vm.HasEmoji.Value
                    ?(vm.Body.Length > 0 ? builder2.BuildChat(vm, IndexSelectedFriend,Name,LastName) : "")
                    :( vm.Body.Length > 0 ? builder.BuildChat(vm, IndexSelectedFriend,Name,LastName) : "");
            }
            string result = "<html><head><meta charset=" + "utf-8" +
                            "/><style>table{ width: 100%;}</style></head><body><div>" + path +
                            "</div></body></html>";
            return result;
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


