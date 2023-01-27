using MinhaDistribuidora.Data.Converter.Implementations;
using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Models;
using MinhaDistribuidora.Repository;

namespace MinhaDistribuidora.Business.Implementations
{
    public class ProdutoBusinessImplementation : IProdutoBusiness
    {
        private readonly IRepository<ProdutoModel> _repository;

        private readonly ProdutoConverter _converter;

        public ProdutoBusinessImplementation(IRepository<ProdutoModel> repository)
        {
            _repository = repository;
            _converter = new ProdutoConverter();
        }

        public List<ProdutoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        public ProdutoVO FindByID(int produto)
        {
            return _converter.Parse(_repository.FindByID(produto));
        }

        public ProdutoVO Create(ProdutoVO produto)
        {
            var produtoEntity = _converter.Parse(produto);
            produtoEntity = _repository.Create(produtoEntity);
            return _converter.Parse(produtoEntity);
        }

        public ProdutoVO Update(ProdutoVO produto)
        {
            var produtoEntity = _converter.Parse(produto);
            produtoEntity = _repository.Update(produtoEntity);
            return _converter.Parse(produtoEntity);
        }

        public void Delete(int produto)
        {
             _repository.Delete(produto);

        }
    }
}
