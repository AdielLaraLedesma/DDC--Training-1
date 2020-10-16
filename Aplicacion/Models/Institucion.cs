using Aplicacion.Models.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aplicacion.Models
{
    [Table("INSTITUCION")]
    public class Institucion 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        public String Nombre { set; get; }
        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        //[ValidarIdentificador]
        public String Identificador { set; get; }
        public int EsActivo { set; get; }
        [StringLength(50)]
        public String Usuario { set; get; }
        public DateTime Fecha { set; get; }
        public List<Tarjeta> Tarjetas;

    }
}