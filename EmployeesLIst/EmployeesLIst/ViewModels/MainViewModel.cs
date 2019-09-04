using EmployeesLIst.Models;
using EmployeesLIst.Repositoires;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeesLIst.ViewModels
{
    public class MainViewModel :BaseViewModel
    {

        public MainViewModel()
        {
            GetPeople();
            //People = new ObservableCollection<PersonModel>()
            //    {
            //        new PersonModel
            //        {
            //            Name = "Cristian",
            //            LastName = "Aristizabal",
            //            Ocupation = "Developer",
            //            Salary = 200,
            //        },
            //        new PersonModel
            //        {
            //            Name = "Camilo",
            //            LastName = "Tobon",
            //            Ocupation = "Developer",
            //            Salary = 400,
            //        },
            //        new PersonModel
            //        {
            //            Name = "David",
            //            LastName = "Guzman",
            //            Ocupation = "Tester",
            //            Salary = 100,
            //        },
            //    };
        }

        private void GetPeople()
        {
            var employeesCurrent = EmployeeRepository.GetPeople();
            if (employeesCurrent != null && employeesCurrent.Count >= 1)
                People = employeesCurrent;
        }

        private ObservableCollection<PersonModel> people;

        public ObservableCollection<PersonModel> People
        {
            get { return people; }
            set { Set(ref people, value); }
        }

        public ICommand DeleteEmployeeCommand { get { return new RelayCommand<PersonModel>(DeleteEmployee); } }

        private void DeleteEmployee(PersonModel obj)
        {

            var result = EmployeeRepository.DeleteEmployee(obj.Id);
            if (result == "ok")
            {
                People.Remove(obj);
            }
        }

    }
}
