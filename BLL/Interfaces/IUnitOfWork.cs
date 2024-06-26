using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IMarketRepository MarketRepository { get; set; }
        public IFeatureRepository FeatureRepository { get; set; }
        public IChildDepartmentRepository ChildDepartmentRepository { get; set; }
    }
}
