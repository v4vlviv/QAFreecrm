using NUnit.Framework;
using QAFreecrm.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAFreecrm.Tools
{
    class TestUtil : TestBase
    {
        public void SwichToFrame()
        {
            driver.SwitchTo().Frame("mainpanel");

        }

    }
}
