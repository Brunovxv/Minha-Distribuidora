using Microsoft.AspNetCore.Mvc;
using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Hypermedia.Constants;
using System.Text;

namespace MinhaDistribuidora.Hypermedia.Enricher
{
    public class ClienteEnricher : ContentResponseEnricher<ClienteVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(ClienteVO content, IUrlHelper urlHelper)
        {
            var path = "api/cliente";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet,
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost,
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut,
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultDelete,
            });
            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefautAPI", url)).Replace("%2F", "/").ToString(); 
            };
        }
    }
}
