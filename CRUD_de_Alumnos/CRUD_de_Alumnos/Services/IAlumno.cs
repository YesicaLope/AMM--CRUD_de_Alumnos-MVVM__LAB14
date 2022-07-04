using CRUD_de_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_de_Alumnos.Services
{
    public interface IAlumno
    {
        Task<List<AlumnoModel>> GetListAlumno();
        Task<AlumnoModel> GetProducto(int AlumnoId);
        Task<bool> InsertAlumno(AlumnoModel alumnoModel);
        Task<bool> UpdateAlumno(AlumnoModel alumnoModel);
        Task<bool> DeleteAlumno(AlumnoModel alumnooModel);
        Task<bool> DeleteAllAlumno();
    }
}
