using EmployeesLIst.Models;
using EmployeesLIst.Models.Reponse;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesLIst.Repositoires
{
    public static class EmployeeRepository
    {
        private static RestClient _restClient;
        public static RestClient GetRestInstance()
        {
            if (_restClient == null)
            {
                _restClient = new RestClient("https://employeesappapi.azurewebsites.net/");
            }
            return _restClient;
        }

        public static ObservableCollection<PersonModel> GetPeople()
        {
            var listDetail = new ObservableCollection<PersonModel>();
            var client = GetRestInstance();
            var request = new RestRequest("api/Employees", Method.GET);
            var response = client.Execute<List<PersonResponse>>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                listDetail = MapModel(response.Data);
            }
            return listDetail;
        }

        public static string DeleteEmployee(string Id)
        {
            var result = string.Empty;
            var client = GetRestInstance();
            var request = new RestRequest("api/Employees", Method.DELETE);
            request.AddParameter("text/json", Id, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return result = "ok";
            }
            else
                return result = "bad";
        }

        private static ObservableCollection<PersonModel> MapModel(List<PersonResponse> data)
        {
            ObservableCollection<PersonModel> listEmployees = new ObservableCollection<PersonModel>();
            foreach (var item in data)
            {
                listEmployees.Add(new PersonModel()
                {
                    Name = item.Name,
                    LastName = item.LastName,
                    Ocupation = item.Position,
                    Salary = item.Salary,
                    Id = item.Id
                });
            }
            return listEmployees;
        }
    }
}
