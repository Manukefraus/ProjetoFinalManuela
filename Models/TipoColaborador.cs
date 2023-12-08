using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalManuela.Models
{
    [Table("TipoColaborador")]
    public class TipoColaborador
    {
        [Column("TipoColaboradorId")]
        [Display(Name = "Código do Tipo de Colaborador")]
        public int TipoColaboradorId { get; set; }

        [Column("TipoColaboradorNome")]
        [Display(Name = "Tipo de Colaborador")]
        public string TipoColaboradorNome { get; set; } = string.Empty;
    }
}
