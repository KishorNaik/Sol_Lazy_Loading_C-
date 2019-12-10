using System;
using System.Collections.Generic;

namespace Sol_Lazy_Loading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LazySingleton lazySingleton = LazySingleton.CreateInsatnce.Value;
            lazySingleton.TestMethod();

            LazyOnDemand lazyOnDemand = new LazyOnDemand();
            
            foreach(var names in lazyOnDemand.ListNames.Value)
            {
                Console.WriteLine(names);
            }

        }
    }

    // Example 1
    public class LazySingleton
    {
        #region Declaration
        private static Lazy<LazySingleton> lazySingleton = null;
        #endregion 

        #region Constructor
        private LazySingleton()
        {

        }
        #endregion

        #region Property
        public static Lazy<LazySingleton> CreateInsatnce
        {
            get
            {
                return
                    lazySingleton
                        ??
                            (lazySingleton = new Lazy<LazySingleton>(()=>new LazySingleton()));
            }
        }
        #endregion

        #region Method
        public void TestMethod()
        {
            Console.WriteLine("Test Method");
        }
        #endregion 
    }

    // Example 2
    public class LazyOnDemand
    {
        #region Constructor
        public LazyOnDemand()
        {
            ListNames = new Lazy<List<string>>(() => this.GetListOfNames());
        }
        #endregion

        #region Property
        public Lazy<List<String>> ListNames { get; set; }
        #endregion

        #region Private Method
        private List<String> GetListOfNames()
        {
            var listNames = new List<String>();
            listNames.Add("Sharmila");
            listNames.Add("Mahesh");
            listNames.Add("Kishor");

            return listNames;
        }
        #endregion 
    }

}
