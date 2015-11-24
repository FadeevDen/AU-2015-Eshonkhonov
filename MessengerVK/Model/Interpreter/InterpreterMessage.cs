using System;
using System.Text.RegularExpressions;
using MessengerVK.Builder;
using VkNet.Enums;

namespace MessengerVK.Interpreter
{
    /// <summary>
    /// The 'AbstractExpression' abstract class
    /// </summary>
  public  abstract class AbstractExpression
    {
        public abstract string Interpret(Message message, int IndexSelectedFriend,String SelectedFriendName,string SelectedFriendLastName);

        public static void HTMLTableCreater(out string path1, Message message, out string path2,string SelectedFriendName,string SelectedFriendLastName)
        {
            path1 = "<table align=" + "center" + "><tbody><tr><th width=" + "50px" + "><div><a><font color=" +
                    "#002133" + ">" + SelectedFriendName + "<br/>" +
                    SelectedFriendLastName +
                    "</font></div></th><th width=" + "400px" + "><div><a align="+"left><font color=" +
                    "#001433>" + message.Body + "</font><a/></div></div></th><th width=" + "50px" + "><div><a><font color=" +
                    "#bfbfbf>" + message.DateTime +
                    "</font></a></div></th></tr></tbody></table>";
            path2 = "<table align=" + "center" + "><tbody><tr><th width=" + "50px" + "><div><a><font color=" +
                    "#002133" + ">" + Admin.GetInstance().UserSingelton.FirstName + "<br/>" +
                    Admin.GetInstance().UserSingelton.LastName +
                    "</font></div></th><th width=" + "400px" + "><div><a align="+"left><font color=" +
                    "#001433>" + message.Body + "</font><a/></div></div></th><th width=" + "50px" + "><div><a><font color=" +
                    "#bfbfbf>" + message.DateTime +
                    "</font></a></div></th></tr></tbody></table>";
        }

       
    }
    /// <summary>
    /// The 'TerminalExpression' class for message whichtr no emoji
    /// </summary>
   public class TerminalExpression : AbstractExpression
    {
        public override string Interpret(Message message, int IndexSelectedFriend,string SelectedFriendName,string SelectedFriendLastName)
        {

            string[] patterns = new[]
            {":[)]", "(:[(])", "😊", "😃", "😉", "😆", "😜", "😋", "😍", "😎", "😒", "😏", "😔", "😢", "😭", "😩", "😨"};
            string beginImgTag = "<img width=" + "16px" + "height=" + "16px" + " src=";
            string endImgTag = "></img>";
            string[] urlSmiles = new[]
            {
                "http://vk.com/images/emoji/D83DDE0A_2x.png",
                "http://vk.com/images/emoji/D83DDE12_2x.png",
                "http://vk.com/images/emoji/D83DDE0A_2x.png",
                "http://vk.com/images/emoji/D83DDE03_2x.png",
                "http://vk.com/images/emoji/D83DDE09_2x.png",
                "http://vk.com/images/emoji/D83DDE06_2x.png",
                "http://vk.com/images/emoji/D83DDE1C_2x.png",
                "http://vk.com/images/emoji/D83DDE0B_2x.png",
                "http://vk.com/images/emoji/D83DDE0D_2x.png",
                "http://vk.com/images/emoji/D83DDE0E_2x.png",
                "http://vk.com/images/emoji/D83DDE12_2x.png",
                "http://vk.com/images/emoji/D83DDE0F_2x.png",
                "http://vk.com/images/emoji/D83DDE14_2x.png",
                "http://vk.com/images/emoji/D83DDE22_2x.png",
                "http://vk.com/images/emoji/D83DDE2D_2x.png",
                "http://vk.com/images/emoji/D83DDE29_2x.png",
                "http://vk.com/images/emoji/D83DDE28_2x.png"
            };
            
            for (int i = 0; i < patterns.Length; i++)
            {
                message.Body = Regex.Replace(message.Body, patterns[i],
                    replacement: beginImgTag + urlSmiles[i] + endImgTag);
            }
            string HtmlTableWithMessage=string.Empty, path1, path2;
            HTMLTableCreater(out path1,message,out path2,SelectedFriendName,SelectedFriendLastName);
            HtmlTableWithMessage = message.TypeMessage == MessageType.Received ? path1 : path2;
            return HtmlTableWithMessage;

        }

       }
    /// <summary>
    /// The 'NonterminalExpression' class for message with emoji
    /// </summary>
  public  class NonTerminalExpression : AbstractExpression
    {
        public override string Interpret(Message message,int IndexSelectedFriend,string SelectedFriendName,string SelectedFriendLastName)
        {

            string HtmlTableWithMessage = string.Empty, path1, path2;
            HTMLTableCreater(out path1, message, out path2,SelectedFriendName,SelectedFriendLastName);
            HtmlTableWithMessage = message.TypeMessage == MessageType.Received ? path1 : path2;
            return HtmlTableWithMessage;
        }
    }
}