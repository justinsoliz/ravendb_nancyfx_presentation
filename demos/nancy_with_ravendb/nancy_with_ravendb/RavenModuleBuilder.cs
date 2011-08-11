using Nancy;
using Nancy.ModelBinding;
using Nancy.Routing;
using Nancy.ViewEngines;
using Raven.Client;

namespace nancy_with_ravendb
{
    public class RavenModuleBuilder : INancyModuleBuilder
    {
        private readonly IViewFactory _viewFactory;
        private readonly IResponseFormatter _responseFormatter;
        private readonly IModelBinderLocator _modelBinderLocator;
        private readonly ISessionManager _sessionManager;

        public RavenModuleBuilder(
            IViewFactory viewFactory,
            IResponseFormatter responseFormatter,
            IModelBinderLocator modelBinderLocator,
            ISessionManager sessionManager)
        {
            _viewFactory = viewFactory;
            _responseFormatter = responseFormatter;
            _modelBinderLocator = modelBinderLocator;
            _sessionManager = sessionManager;
        }

        public NancyModule BuildModule(NancyModule module, NancyContext context)
        {
            module.Context = context;
            module.Response = _responseFormatter;
            module.ViewFactory = _viewFactory;
            module.ModelBinderLocator = _modelBinderLocator;

            context.Items.Add("RavenSession", _sessionManager.GetSession());

            module.After.AddItemToStartOfPipeline(ctx => {
                var session =
                    ctx.Items["RavenSession"] as IDocumentSession;
                session.SaveChanges();
                session.Dispose();
            });

            return module;
        }
    }
}