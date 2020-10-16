using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aplicacion.Models
{
    [Table("TARJETA")]
    public class Tarjeta
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(16)]
        [Index(IsUnique = true)]
        public String Numero { set; get; }
        [Required]
        public int Institucion_ID { set; get; }
        //public Institucion Institucion { set; get; }
        public int EsActivo { set; get; }
        [StringLength(50)]
        public String Usuario { set; get; }
        public DateTime Fecha { set; get; }

    }
}