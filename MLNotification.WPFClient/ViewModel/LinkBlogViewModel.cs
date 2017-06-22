using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotification.WPFClient.ViewModel
{
    public class LinkBlogViewModel : ViewModelBase
    {


        public RelayCommand NavegateToBlogCommand
        {
            get => new RelayCommand(OnNavegateToMyBlog);
        }

        private void OnNavegateToMyBlog()
        {
            System.Diagnostics.Process.Start("http://puntonetalpunto.blogspot.com.es/");
        }
    }
}
