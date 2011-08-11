using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;

namespace nancy_with_ravendb
{
    public interface ISessionManager {
        IDocumentSession GetSession();
    }

    public class SessionManager : ISessionManager
    {
        private static IDocumentStore _documentStore;

        public static IDocumentStore DocumentStore
        {
            get { return (_documentStore ?? (_documentStore = CreateDocumentStore())); }
        }

        private static IDocumentStore CreateDocumentStore()
        {
            var documentStore = new DocumentStore() {
                ConnectionStringName = "RavenDB"
            }.Initialize();

            return documentStore;
        }

        public IDocumentSession GetSession()
        {
            return DocumentStore.OpenSession();
        }
    }
}