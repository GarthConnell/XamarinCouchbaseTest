using Couchbase.Lite;
using Couchbase.Lite.Logging;
using Couchbase.Lite.Sync;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCouchbaseTest
{
    public partial class App : Application
    {
        public static event EventHandler<string> SyncStatus;
        public static event EventHandler<DocumentReplicationEventArgs> SyncDocument;

        public App()
        {
            InitializeComponent();
            global.bucketstring = "anything";
            
            try
            {
                global._database = new Database(global.bucketstring);
            }
            catch (Exception e)
            {
                throw;
            }
            Database.Log.Console.Domains = LogDomain.All;
            Database.Log.Console.Level = LogLevel.Warning;

            var targetEndpoint = new URLEndpoint(new Uri("ws://couchbase:4984/" + global.bucketstring));
            var replConfig = new ReplicatorConfiguration(global._database, targetEndpoint);
            replConfig.ReplicatorType = ReplicatorType.PushAndPull;
            replConfig.Continuous = true;
            replConfig.Authenticator = new BasicAuthenticator("user", "password");
            
            
            global._replicator = new Replicator(replConfig);


            global._replicator.AddChangeListener((sender, args) =>
            {
                SyncStatus?.Invoke(null, args.Status.Activity.ToString());

                if (args.Status.Error != null)
                {
                    Debug.Print($"Error :: {args.Status.Error}");

                }
            });

            var token = global._replicator.AddDocumentReplicationListener((sender, args) =>
            {
                SyncStatus?.Invoke(null, global._replicator.Status.Activity.ToString() + " " + args.Documents.Count);
                SyncDocument?.Invoke(null, args);
            });

            global._replicator.Start();
            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
