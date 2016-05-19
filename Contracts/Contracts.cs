using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Demo.Contracts
{
    [AddInContract]
    public interface IContracts:IContract
    {
        int ComputeSum(int a, int b);
    }
}
