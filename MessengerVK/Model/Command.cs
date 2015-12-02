using System;
using MessengerVK.Builder;
using VkNet.Enums;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Windows;

namespace MessengerVK
{
    interface ICommandSaveToWord
    {
        void Execute(long id, string AdminFristName, string AdminLastName, string FriendFristName, string FriendLastName,int count, List<Message> MessageList);
        void Undo();
    }
    // Receiver
    class ChatHistorySaver
    {
        public void Save(long id, string AdminFristName, string AdminLastName, string FriendFristName, string FriendLastName,int count, List<Message> MessageList)
        {
            try
            {  Word.Application wordApp = new Word.Application();
                Word.Document wordDocument;
                wordDocument = wordApp.Documents.Add(DocumentType: Word.WdNewDocumentType.wdNewBlankDocument);
                var range = wordDocument.Content;
                Word.Tables Tables = wordDocument.Tables;
                Tables.Add(range, count, 3, true, true);
                FilTable(id, Tables, AdminFristName, AdminLastName, FriendFristName, FriendLastName, count, MessageList);
                wordDocument.Close();
                wordApp.Quit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }
        private static void FilTable(long id, Word.Tables Tables, string AdminFristName, string AdminLastName, string FriendFristName, string FriendLastName,int count, List<Message> MessageList)
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <=count; j++)
                {
                    SwitchUserName(id, Tables, i, j,  AdminFristName,  AdminLastName,  FriendFristName,  FriendLastName, MessageList);

                }
            }
        }
        private static void SwitchUserName(long id, Word.Tables Tables, int i, int j,string AdminFristName,string AdminLastName,string FriendFristName,string FriendLastName, List<Message> MessageList)
        {
            switch (i)
            {
                case 1:
                    Tables[1].Cell(j, i).Range.Text =
                        MessageList[j-1].DateTime.ToString();
                    break;
                case 2:
                    Tables[1].Cell(j, i).Range.Text =
                        MessageList[j-1].Body;
                    break;
                default:
                    Tables[1].Cell(j, i).Range.Text =
                        MessageList[j-1].TypeMessage != MessageType.Received
                            ? AdminFristName + "\n" +
                              AdminLastName
                            : FriendFristName + "\n" +
                              FriendLastName;
                    break;
            }
        }
    }
    class ChatHistoryOnCommand : ICommandSaveToWord
    {
        ChatHistorySaver chatSaver;
        public ChatHistoryOnCommand(ChatHistorySaver tvSet)
        {
            chatSaver = tvSet;
        }
        public void Execute(long id, string AdminFristName, string AdminLastName, string FriendFristName, string FriendLastName,int count, List<Message> MessageList)
        {
            chatSaver.Save( id,  AdminFristName,  AdminLastName,  FriendFristName,  FriendLastName,count, MessageList);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
    // Invoker 
    class Saver
    {
        ICommandSaveToWord command;

        public Saver() { }

        public void SetCommand(ICommandSaveToWord com)
        {
            command = com;
        }

        public void PressSave(long id, string AdminFristName, string AdminLastName, string FriendFristName, string FriendLastName,int count, List<Message> MessageList)
        {
            if (command != null) command.Execute( id,  AdminFristName,  AdminLastName,  FriendFristName,  FriendLastName, count, MessageList);
        }

        public void PressUndo()
        {
            if (command != null) command.Undo();
        }
    }
}