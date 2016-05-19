using System.AddIn.Pipeline;
using Demo.Contracts;

namespace Demo.HostSideAdapters
{
    [HostAdapter]
    public class ContractToHostViewAdapter : HostView.HostView
    {
        private IContracts _calcContract;
        private ContractHandle _handle;

        public ContractToHostViewAdapter(IContracts contract)
        {
            _calcContract = contract;
            _handle = new ContractHandle(_calcContract);
        }

        public override int ComputeSum(int a, int b)
        {
            return this._calcContract.ComputeSum(a,b);
        }

    }
}
