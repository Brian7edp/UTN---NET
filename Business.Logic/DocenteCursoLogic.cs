using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        DocenteCursoAdapter dcDatos;
        public DocenteCursoLogic()
        {
            dcDatos = new DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll(Curso cur)
        {
            try
            {
                return dcDatos.GetAll(cur);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                dcDatos.Delete(ID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Save(DocenteCurso dc)
        {
            try
            {
                dcDatos.Save(dc);
            }
            catch (Exception ExcepcionManejada)
            {
                throw ExcepcionManejada;
            }
        }
    }
}
