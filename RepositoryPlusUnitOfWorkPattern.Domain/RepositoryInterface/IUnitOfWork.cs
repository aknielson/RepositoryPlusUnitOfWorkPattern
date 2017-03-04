﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPlusUnitOfWorkPattern.Domain.Models;

namespace RepositoryPlusUnitOfWorkPattern.Domain.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {

        //Must Add Repository for each Model
        IPersonRepository People { get; }
        IRepository<Address> Addresses { get; }
        IRepository<Phone> Phones { get; }
        IRepository<PhoneType> PhoneTypes { get; }

        int Complete();
    }
}
