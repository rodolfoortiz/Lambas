using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lambdas
{
    public delegate int BizRulesDelegate(int x, int y);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Customer
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
        }

        public List<Customer> customers = new List<Customer>
            {
                new Customer { City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer { City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer { City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer { City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4},
            };
        
        private void button1_Click(object sender, EventArgs e)
        {
            var data = new ProcessData();
            BizRulesDelegate multiplyDelegate = delegate(int x, int y)
            {
                return x * y;
            };
            //BizRulesDelegate multiplyDelegate = (x, y) => x * y;
            //data.Process(2, 3, multiplyDelegate);

            Action<int, int> myMultiplyAction = (x, y) => MessageBox.Show((x * y).ToString());
            data.ProcessAction(2, 3, myMultiplyAction);

            Func<int, int, int> funcMultipleDel = (x, y) => x * y;
            data.ProcessFunc(3, 4, funcMultipleDel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = customers.Where(delegate (Customer x)
            {
                return x.FirstName == "John";
            });
            MessageBox.Show(string.Join(",", list.Select(x => x.FirstName)));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var customer = customers
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);

            foreach (var cust in customer)
            {
                MessageBox.Show(cust.FirstName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var data = new ProcessData();

            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            data.Process(2, 3, multiplyDel);

            Action<int, int> myAction = (x, y) => MessageBox.Show((x + y).ToString());
            Action<int, int> myMultiplyAction = (x, y) => MessageBox.Show((x * y).ToString());
            data.ProcessAction(2, 3, myMultiplyAction);

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultipleDel = (x, y) => x * y;
            data.ProcessFunc(3, 2, funcMultipleDel);

            //this.button2.Click += (s, e) => MessageBox.Show("Button Clicked");
        }
    }
}
