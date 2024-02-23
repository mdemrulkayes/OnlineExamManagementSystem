using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
