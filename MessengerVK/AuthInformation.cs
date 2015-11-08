using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerVK
{
   public class AuthInformation
   {
       private static string authFailed="Authorization failed";
       private static string authSuccessful= "Authorization Successful";
       private static string nullField = "Enter Username and Password";
       private static string nullProfileFileds= "Unkown";
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

        public static string NullProfileFileds
        {
            get
            {
                return nullProfileFileds;
            }

            set
            {
                nullProfileFileds = value;
            }
        }
    }
}
