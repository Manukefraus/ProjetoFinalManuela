using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoFinalManuela.Models
{
    [Table("ProcedimentoRealizado")]
    public class ProcedimentoRealizado
    {
        [Column("ProcedimentoRealizadoId")]
        [Display(Name = "Código do Procedimento Realizado")]
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public int? ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [ForeignKey("ProcedimentoId")]
        public int? ProcedimentoId { get; set; }

        public Procedimento? Procedimento { get; set; }

        [ForeignKey("ColaboradorId")]
        public int? ColaboradorId { get; set; }

        public Colaborador? Colaborador { get; set; }

        [ForeignKey("LocalRealizacaoId")]       
        public int? LocalRealizacaoId { get; set; }

        [Display(Name = "Nome do Local de Realização")]
        public LocalRealizacao? LocalRealizacao { get; set; }

        [Column("DataRealizacao")]
        [Display(Name = "Data de Realização")]
        public DateTime DataRealizacao { get; set; }

        [Column("ObservacaoRealizacao")]
        [Display(Name = "Observação da Realização")]
        public string ObservacaoRealizacao { get; set; } = string.Empty;
    }
}
