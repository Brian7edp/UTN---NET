﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso:BusinessEntity
    {
        private int _IDCurso;
        private int _IDDocente;
        private TipoCargos _Cargo;

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }

        public TipoCargos Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }


        public enum TipoCargos
        {
            Profesor,
            Auxiliar            
        }
    }
}