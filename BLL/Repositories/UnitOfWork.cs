using Pioneers.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.BLL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IMarketRepository MarketRepository { get; set; }
        public IFeatureRepository FeatureRepository { get; set; }
        public IChildDepartmentRepository ChildDepartmentRepository { get; set; }

        public UnitOfWork(IDepartmentRepository departmentRepository,IMarketRepository marketRepository ,IFeatureRepository featureRepository,IChildDepartmentRepository childDepartmentRepository)
        {
            DepartmentRepository = departmentRepository;
            MarketRepository = marketRepository;
            FeatureRepository = featureRepository;
            ChildDepartmentRepository = childDepartmentRepository;
        }

       
    }
}
