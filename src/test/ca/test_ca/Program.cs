using System;
using System.Collections.Generic;
using System.Data;
using library.AppLogic;

namespace test_ca {
    internal class Program {
        static void Main(string[] args) {

            AppLogic l = new AppLogic();
            l.registerClient("test_ca", "test", "test");
            Console.WriteLine("REGISTER");
            l.restorePreviousState();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
