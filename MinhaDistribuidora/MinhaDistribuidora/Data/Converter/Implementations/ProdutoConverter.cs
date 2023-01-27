using MinhaDistribuidora.Data.Converter.Contract;
using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Models;

namespace MinhaDistribuidora.Data.Converter.Implementations
{
    public class ProdutoConverter : IParser<ProdutoVO, ProdutoModel>,
                                    IParser<ProdutoModel, ProdutoVO>
    {

        public ProdutoModel Parse(ProdutoVO origin)
        {
            if (origin == null) return null;
            return new ProdutoModel
            {
                Id = origin.Id,
                Nome_produto = origin.Nome_produto,
                Tipo_produto = origin.Tipo_produto,
                Valor_produto = origin.Valor_produto,
            };
        }

        public ProdutoVO Parse(ProdutoModel origin)
        {
            if (origin == null) return null;
            return new ProdutoVO
            {
                Id = origin.Id,
                Nome_produto = origin.Nome_produto,
                Tipo_produto = origin.Tipo_produto,
                Valor_produto = origin.Valor_produto,
            };
        }
        public List<ProdutoModel> Parse(List<ProdutoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }


        public List<ProdutoVO> Parse(List<ProdutoModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList(); ;
        }
    }
}