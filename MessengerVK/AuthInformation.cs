﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerVK
{
   public class AuthInformation
   {
       private string authFailed="Authorization failed";
       private string authSuccessful= "Authorization Successful";
       private string nullField = "Enter Username and Password";
        public string AuthFailed
        {
            get
            {
                return authFailed;
            }
        }

        public string AuthSuccessful
        {
            get
            {
                return authSuccessful;
            }

        }

        public string NullField
        {
            get
            {
                return nullField;
            }
        }
    }
}
