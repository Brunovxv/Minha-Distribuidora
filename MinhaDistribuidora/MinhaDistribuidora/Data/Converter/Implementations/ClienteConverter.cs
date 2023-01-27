using MinhaDistribuidora.Data.Converter.Contract;
using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Models;

namespace MinhaDistribuidora.Data.Converter.Implementations
{
    public class ClienteConverter : IParser<ClienteVO, ClienteModel>,
                                    IParser<ClienteModel, ClienteVO>
    {

        public ClienteModel Parse(ClienteVO origin)
        {
            if (origin == null) return null;
            return new ClienteModel
            {
                Id = origin.Id,
                Nome= origin.Nome,
                Telefone= origin.Telefone,
            };
        }

        public ClienteVO Parse(ClienteModel origin)
        {
            if (origin == null) return null;
            return new ClienteVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Telefone = origin.Telefone,
            };
        }
        public List<ClienteModel> Parse(List<ClienteVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }


        public List<ClienteVO> Parse(List<ClienteModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); ;
        }
    }
}
