﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.ProjetoDDD.Infra.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
