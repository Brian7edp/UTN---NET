using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Descripcion;
        public string Descripcion
        { get { return _Descripcion; } set { _Descripcion = value; } }

        private int _HSSemanales;
        public int HSSemanales
        { get { return _HSSemanales; } set { _HSSemanales = value; } }

        private int _HSTotales;
        public int HSTotales
        { get { return _HSTotales; } set { _HSTotales = value; } }

        private Plan _Plan;
        public Plan Plan
        { get { return _Plan; } set { _Plan = value; } }
    }

}
