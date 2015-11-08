using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace MessengerVK.FriendModel
{
    public class FriendProfileFields
    {
        public static void GetFriendProfileFields()
        {
            List<Friend> friendsListTemporary=new List<Friend>();
            ReadOnlyCollection<long> OnlineFriendsIds = Admin.GetInstance().ApiSingelton.Friends.GetOnline(Admin.GetInstance().UserSingelton.Id);
            ReadOnlyCollection<User> friendsListTemporaryReadOnly = Admin.GetInstance().ApiSingelton.Friends.Get(uid: (long)Admin.GetInstance().ApiSingelton.UserId, fields: ProfileFields.FirstName);
            friendsListTemporaryReadOnly = Admin.GetInstance().ApiSingelton.Friends.Get(uid: (long)Admin.GetInstance().ApiSingelton.UserId, fields: ProfileFields.LastName);
            friendsListTemporaryReadOnly = Admin.GetInstance().ApiSingelton.Friends.Get(long.Parse(Admin.GetInstance().ApiSingelton.UserId.ToString()), ProfileFields.Photo100);

            AddFriendsToList(OnlineFriendsIds, friendsListTemporaryReadOnly);
        }
       
        
        private static void AddFriendsToList(ReadOnlyCollection<long>  OnlineFriendsIds, ReadOnlyCollection<User> friendsListTemporaryReadOnly)
        {
            for (int i = 0; i < friendsListTemporaryReadOnly.Count; i++)
            {
                Friend friendTemplate = new Friend();
                for (int j = 0; j < OnlineFriendsIds.Count; j++)
                {
                    if (OnlineFriendsIds[j] == friendsListTemporaryReadOnly[i].Id)
                    {
                        friendTemplate.Online = true;
                    }
                }
                friendTemplate.Avatar = friendsListTemporaryReadOnly[i].PhotoPreviews.Photo100;
                friendTemplate.Name = friendsListTemporaryReadOnly[i].FirstName;
                FriendListSingelton.GetInstance().FriendsList.Add(friendTemplate);
            }
        }

        private static void RefreshFriendsList(ReadOnlyCollection<long> OnlineFriendsIds, ReadOnlyCollection<User> friendsListTemporaryReadOnly)
        {
            for (int i = 0; i < friendsListTemporaryReadOnly.Count; i++)
            {
                Friend friendTemplate = new Friend();
                for (int j = 0; j < OnlineFriendsIds.Count; j++)
                {
                    if (OnlineFriendsIds[j] == friendsListTemporaryReadOnly[i].Id)
                    {
                        friendTemplate.Online = true;
                    }
                }
                friendTemplate.Avatar = friendsListTemporaryReadOnly[i].PhotoPreviews.Photo100;
                friendTemplate.Name = friendsListTemporaryReadOnly[i].FirstName;
                if (FriendListSingelton.GetInstance().FriendsList.Count!= friendsListTemporaryReadOnly.Count)
                {
                    FriendListSingelton.GetInstance().FriendsList.Clear();
                    GetFriendProfileFields();
                }
                else
                {
                    FriendListSingelton.GetInstance().FriendsList[i] = friendTemplate;

                }
               
            }
        }

        public static async void GetFriendProfileFieldsTimerForAsyncMethod()
        {
            List<Friend> friendsListTemporary = new List<Friend>();
            ReadOnlyCollection<long> OnlineFriendsIds = Admin.GetInstance().ApiSingelton.Friends.GetOnline(Admin.GetInstance().UserSingelton.Id);
            ReadOnlyCollection<User> friendsListTemporaryReadOnly = Admin.GetInstance().ApiSingelton.Friends.Get(uid: (long)Admin.GetInstance().ApiSingelton.UserId, fields: ProfileFields.FirstName);
            friendsListTemporaryReadOnly = Admin.GetInstance().ApiSingelton.Friends.Get(uid: (long)Admin.GetInstance().ApiSingelton.UserId, fields: ProfileFields.LastName);
            friendsListTemporaryReadOnly = Admin.GetInstance().ApiSingelton.Friends.Get(long.Parse(Admin.GetInstance().ApiSingelton.UserId.ToString()), ProfileFields.Photo100);

            RefreshFriendsList(OnlineFriendsIds, friendsListTemporaryReadOnly);
        }
    }
}