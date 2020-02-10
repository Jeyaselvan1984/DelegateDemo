using System;

namespace EmployeeHRDelegate
{
    public delegate void NewEmployeeEventHandler(object sender, NewEmployeeEventArgs e);

    public class NewEmployeeEventArgs : EventArgs
    {
        public string Name;
        public int Age;
        public NewEmployeeEventArgs(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class HR
    {
        public event NewEmployeeEventHandler NewEmployee;

        public void OnNewEmployee(NewEmployeeEventArgs e)
        {
            if (NewEmployee != null)
                NewEmployee(this, e);
        }

        public void RegisterEmployee(string name, int age)
        {
            NewEmployeeEventArgs e = new NewEmployeeEventArgs(name, age);
            OnNewEmployee(e);
        }
    }

    class EmployeeCare
    {
        public EmployeeCare(HR hr)
        {
            hr.NewEmployee += CallEmployee;
        }

        private void CallEmployee(object sender, NewEmployeeEventArgs e)
        {
            Console.WriteLine("Sender of event: " + sender.ToString());
            Console.WriteLine("Cusomer Info: " + e.Name + e.Age.ToString());
            //do call Employee stuff
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HR hr = new HR(); //line1
            EmployeeCare cc = new EmployeeCare(hr); //line2
            hr.RegisterEmployee("mohamad", 26); //line3
            Console.ReadLine(); //line4
        }
    }
}
