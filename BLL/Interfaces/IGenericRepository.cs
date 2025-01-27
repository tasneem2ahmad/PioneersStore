﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(int? id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T department);
        Task<int> Update(T department);
        Task<int> Delete(T department);
    }
}
