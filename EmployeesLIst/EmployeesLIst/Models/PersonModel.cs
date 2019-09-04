using EmployeesLIst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesLIst.Models
{
    public class PersonModel :BaseViewModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set {Set(ref name, value); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { Set(ref lastName, value); }
        }

        private string ocupation;

        public string Ocupation
        {
            get { return ocupation; }
            set { Set(ref ocupation, value); }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set { Set(ref salary, value); }
        }



    }
}
