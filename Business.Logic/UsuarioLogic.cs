using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
    {

        private  UsuarioAdapter m_UsuarioData;
        /// <summary>
        /// Esta propiedad permite definir un tipo UsuarioAdaptaer
        /// </summary>
        public UsuarioAdapter UsuarioData
        {   get { return m_UsuarioData; }
            set { m_UsuarioData = value; }
        }

        
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }


        public List<Usuario> GetAll() 
        {
            return UsuarioData.GetAll();
        }

        public Business.Entities.Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }











    }
}
