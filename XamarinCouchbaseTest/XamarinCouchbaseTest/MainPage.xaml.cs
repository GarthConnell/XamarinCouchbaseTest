using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCouchbaseTest
{
    public partial class MainPage : ContentPage
    {
        List<string> loglist = new List<string>();
        public MainPage()
        {
            InitializeComponent();
            lvlog.ItemsSource = loglist;

            //App.SyncDocument += (s, e) =>
            //{
            //    loglist.Insert(0,e.Documents.Count.ToString());
            //    lvlog.ItemsSource = loglist;
            //};
            //App.SyncStatus += (s, e) =>
            //  {
            //      loglist.Insert(0,e);
            //      lvlog.ItemsSource = loglist;
            //  };
        }
    }
}
