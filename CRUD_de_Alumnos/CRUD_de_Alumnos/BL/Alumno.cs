using System;
using System.Collections.Generic;
using System.Text;
using CRUD_de_Alumnos.Data;
using CRUD_de_Alumnos.Models;
using CRUD_de_Alumnos.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_de_Alumnos.BL
{
    public class Alumno : IAlumno
    {
        public async Task<List<AlumnoModel>> GetListProducto()
        {
            using (var alumnoContext = new AlumnoContext())
            {
                return await alumnoContext.TbAlumno.ToListAsync();
            }
        }

        public async Task<AlumnoModel> GetAlumno(int AlumnoId)
        {
            using (var alumnoContext = new AlumnoContext())
            {
                return await alumnoContext.TbAlumno
                    .Where(p => p.AlumnoId == AlumnoId).FirstOrDefaultAsync();
            }

        }


        public async Task<bool> InsertAlumno(AlumnoModel alumnoModel)
        {
            using (var alumnoContext = new AlumnoContext())
            {
                alumnoContext.Add(alumnoModel);

                await alumnoContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateAlumno(AlumnoModel productoModel)
        {
            using (var alumnoContext = new AlumnoContext())
            {
                var tracking = alumnoContext.Update(alumnoModel);

                await productoContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
        }

        public async Task<bool> DeleteAlumno(AlumnoModel alumnoModel)
        {
            using (var alumnoContext = new AlumnoContext())
            {
                var tracking = alumnoContext.Remove(alumnoModel);

                await alumnoContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }

        }


        public async Task<bool> DeleteAllAlumno()
        {
            using (var alumnoContext = new AlumnoContext())
            {
                alumnoContext.RemoveRange(alumnoContext.TbProducto);

                await alumnoContext.SaveChangesAsync();
            }
            return true;
        }

        public Task<List<AlumnoModel>> GetListAlumno()
        {
            throw new NotImplementedException();
        }

        public Task<AlumnoModel> GetProducto(int AlumnoId)
        {
            throw new NotImplementedException();
        }
    }
}
