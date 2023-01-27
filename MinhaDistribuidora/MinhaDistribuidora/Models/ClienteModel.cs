using Microsoft.EntityFrameworkCore;
using MinhaDistribuidora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDistribuidora.Models
{
    [Table("Cliente")]
    public class ClienteModel : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }

    }
}
