using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportingFramework
{    
        [TestClass]
        public static class NamespaceSetup
        {
            [AssemblyInitialize]
            public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
            {
                Reporter.StartReporter();
            }
        }    
}
