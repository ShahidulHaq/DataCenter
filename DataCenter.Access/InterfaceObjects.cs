using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Access
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        IEnumerable<Trade> GetData(int value);
    }
    public interface IRepository<T>
    {
        IEnumerable<T> GetModel(int id);
    }
}
