using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Models;

namespace MinhaDistribuidora.Business
{
    public interface IProdutoBusiness
    {
        ProdutoVO Create(ProdutoVO produto);

        ProdutoVO FindByID(int ProdutoID);

        List<ProdutoVO> FindAll();

        ProdutoVO Update(ProdutoVO produto);

        void Delete(int ProdutoID);

    }

}
