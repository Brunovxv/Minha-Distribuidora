using MinhaDistribuidora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDistribuidora.Models
{
    [Table("Produto")]
    public class ProdutoModel : BaseEntity
    {
        public string? Nome_produto { get;set; }

        public string? Tipo_produto { get; set; }

        public double? Valor_produto { get; set; }         


    }
}
