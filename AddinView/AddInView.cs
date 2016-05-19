using System.AddIn.Pipeline;

namespace Demo.AddinView
{
    [AddInBase]
    public abstract class AddInView
    {
        public abstract int ComputeSum(int a, int b);
    }
}
