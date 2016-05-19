using System;
using System.AddIn.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.HostView;

namespace Program
{
    class Program
    {
        static Collection<AddInToken> _addinTokens;
        static Collection<HostView> _addinList = new Collection<HostView>();
        static HostView calcAddin;

        static void Main(string[] args)
        {
            LoadAddins();
            Console.WriteLine(Sum(10,20));
            Console.ReadKey();

        }
        public static void LoadAddins()
        {
            // Set root directory for finding Add-ins
            string addinRoot = Environment.CurrentDirectory;

            // Rebuild the add-ins and pipeline components 
           var comp = AddInStore.Rebuild(addinRoot);

            // Find add-ins of type HostView
            _addinTokens = AddInStore.FindAddIns(typeof(HostView), addinRoot);

            foreach (AddInToken addinToken in _addinTokens)
            {
                // Activate the add-in
                _addinList.Add(addinToken.Activate<HostView>(AddInSecurityLevel.Internet));
                // Display Addin-Details
                Console.WriteLine(addinToken.Name);
            }
            calcAddin = _addinList[0];
        }

        private static int Sum(int a, int b)
        {
            return calcAddin.ComputeSum(a, b);
        }
    }

}
