using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDistribuidora.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    
    }
}
