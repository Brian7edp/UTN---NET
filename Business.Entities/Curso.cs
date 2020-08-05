using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso:BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private string _Descripcion;
        private Comision _Comision;
        private Materia _Materia;

        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

        public string Descripcion
        {
            get
            {
                return Materia.Descripcion + " - Comisión " + Comision.Descripcion;
            }
        }

        public Comision Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        public Materia Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }
    }
}
