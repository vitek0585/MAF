using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using Demo.AddinView;
using Demo.Contracts;

namespace Demo.AddInSideAdapters
{
    [AddInAdapter]
    public class AddInViewToContractAdapter: ContractBase, IContracts
    {
        private AddInView _view;
        public AddInViewToContractAdapter(AddInView view)
        {
            this._view = view;
        }
        public int ComputeSum(int a, int b)
        {
            return this._view.ComputeSum(a,b);
        }
     }
}
