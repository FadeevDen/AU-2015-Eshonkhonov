using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace MessengerVK.FriendModel
{
    public class FriendList
    {
        private static  List<Friend> friendsList = new List<Friend>();

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

        public static void UpdateFriendList()
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
                    else
                    {
                        friendTemplate.Online = false;
                    }
                }
                friendTemplate.Avatar = friendsListTemporary[i].PhotoPreviews.Photo100;
                friendTemplate.Name = friendsListTemporary[i].FirstName;
                friendsList.Add(friendTemplate);

            }
        }


    }
}
