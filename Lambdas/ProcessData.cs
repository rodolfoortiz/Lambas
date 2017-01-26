using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambdas
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            MessageBox.Show(result.ToString());
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> del)
        {
            var result = del(x, y);
            MessageBox.Show(result.ToString());
        }

    }
}
