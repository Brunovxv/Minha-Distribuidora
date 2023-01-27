using MinhaDistribuidora.Hypermedia;
using MinhaDistribuidora.Hypermedia.Abstract;

namespace MinhaDistribuidora.Data.VO
{
    public class ClienteVO :ISupportHyperMedia
    {
        public long Id { get; set; }   
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
