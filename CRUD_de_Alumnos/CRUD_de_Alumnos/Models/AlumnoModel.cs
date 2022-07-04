using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUD_de_Alumnos.Models
{
    public class AlumnoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PAlumnoId { get; set; }
        public string AlumnoNombre { get; set; }
        public double AlumnoPromedio { get; set; }
        public bool AlumnoSexo { get; set; }
        public DateTime AlumnoFecha { get; set; }
    }
}
