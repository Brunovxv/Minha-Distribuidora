using MinhaDistribuidora.Data.VO;

namespace MinhaDistribuidora.Business
{
    public interface IClienteBusiness
    {
        ClienteVO Create(ClienteVO cliente);

        ClienteVO FindByID(int Id);

        List<ClienteVO> FindAll();

        ClienteVO Update(ClienteVO cliente);

        void Delete(int Id);

    }

}
