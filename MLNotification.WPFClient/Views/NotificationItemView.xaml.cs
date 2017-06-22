using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MLNotification.Domain;

namespace MLNotification.WPFClient
{
    /// <summary>
    /// Interaction logic for NotificationItemView.xaml
    /// </summary>
    public partial class NotificationItemView : UserControl
    {
        public NotificationItemView()
        {
            InitializeComponent();

            //this.DataContext = new NotificationMessage
            //{
            //    Subject = "Ha ocurrdio algo muy malo, este Subjet"
            //};
        }
    }
}
