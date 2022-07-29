using Couchbase.Lite;
using Couchbase.Lite.Sync;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinCouchbaseTest
{
    public static class global
    {
        

        public static string bucketstring;
        public static string api { get; set; }
        public static Database _database { get; set; }
        public static Replicator _replicator { get; set; }
    }
}
