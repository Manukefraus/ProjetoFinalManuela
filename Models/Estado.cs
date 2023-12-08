using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinalManuela.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Column("EstadoId")]
        [Display(Name = "Código do Estado")]
        public int EstadoId { get; set; }

        [Column("EstadoNome")]
        [Display(Name = "Nome do Estado")]
        public string EstadoName { get; set; } = string.Empty;
    }
}
