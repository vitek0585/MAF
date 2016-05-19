
namespace Demo.CalcAddIn
{
    [System.AddIn.AddIn("Demo Add-In", 
     Version = "1.0.0.0",
     Description = "Description of Demo AddIn", 
     Publisher = "XYZ Company")]
    public class CalcAddIn : Demo.AddinView.AddInView
    {
        public override int ComputeSum(int a, int b)
        {
            return a+b;
        }
    }
}
