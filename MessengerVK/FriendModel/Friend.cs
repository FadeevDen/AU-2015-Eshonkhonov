using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerVK
{
   public class Friend
   {
       private string name;
       private string avatar;
       private bool online;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Avatar
        {
            get
            {
                return avatar;
            }

            set
            {
                avatar = value;
            }
        }

        public bool Online
        {
            get
            {
                return online;
            }

            set
            {
                online = value;
            }
        }
    }
}
