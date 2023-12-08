using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalManuela.Models
{
    [Table("TipoProcedimento")]
    public class TipoProcedimento
    {
        [Column("TipoProcedimentoId")]
        [Display(Name = "Código do Tipo de Procedimento")]
        public int TipoProcedimentoId { get; set; }
        
        [Column("TipoProcedimentoNome")]
        [Display(Name = "Tipo de Procedimento")]
        public string TipoProcedimentoNome { get; set; } = string.Empty;
    }
}
