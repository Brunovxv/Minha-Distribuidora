using MinhaDistribuidora.Data.Converter.Implementations;
using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Models;
using MinhaDistribuidora.Repository;

namespace MinhaDistribuidora.Business.Implementations
{
    public class ClienteBusinessImplementation : IClienteBusiness
    {
        private readonly IRepository<ClienteModel> _repository;

        private readonly ClienteConverter _converter;

        public ClienteBusinessImplementation(IRepository<ClienteModel> repository)
        {
            _repository = repository;
            _converter = new ClienteConverter();
        }
                
        public List<ClienteVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        public ClienteVO FindByID(int cliente)
        {
            return _converter.Parse(_repository.FindByID(cliente));
        }

        public ClienteVO Create(ClienteVO cliente)
        {
            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _repository.Create(clienteEntity);
            return _converter.Parse(clienteEntity);
        }

        public ClienteVO Update(ClienteVO cliente)
        {
            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _repository.Update(clienteEntity);
            return _converter.Parse(clienteEntity);
        }

        public void Delete(int cliente)
        {
             _repository.Delete(cliente);

        }
    }
}
