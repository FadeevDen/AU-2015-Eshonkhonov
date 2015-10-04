using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MessengerVK
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
       static public void MessengeManagerApplicationStartup()
        {
            MessageManager messageManager = new MessageManager();
            messageManager.InitializeComponent();
            messageManager.ShowDialog();
        }
    }
}
