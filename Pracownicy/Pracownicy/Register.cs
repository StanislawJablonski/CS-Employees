using System.Collections.Generic;
using System.Linq;

namespace Pracownicy
{
    public class Register
    {
        private static readonly object Padlock = new();
        private Dictionary<int, Employee> _employeeRegisterList = new();
        private static Register _instance;

        private Register()
        {
        }

        public void Add(Employee employee)
        {
            _employeeRegisterList.Add(employee.Id, employee);
        }

        public void Add(List<Employee> employeeAddList)
        {
            foreach (var employee in employeeAddList)
                _employeeRegisterList.Add(employee.Id, employee);
        }

        public bool Remove(int id)
        {
            return _employeeRegisterList.Remove(id);
        }

        public string PrintSortedList()
        {
            var result = "";
            var sorted = _employeeRegisterList.Values.OrderByDescending(o => o.Experience).ThenBy(o => o.Age)
                .ThenBy(o => o.Surname);

            foreach (var value in sorted) result = result + value + "\n";
            return result;
        }

        public string PrintByCity(string city)
        {
            var result = "";
            foreach (var value in _employeeRegisterList.Values)
                if (value.Address.City == city)
                    result = result + value + "\n";
            return result;
        }

        public string PrintWithValueForCompany()
        {
            var result = "";
            foreach (var value in _employeeRegisterList.Values)
                result = result + value + " Value for company: " + value.CalculateValue() + "\n";
            return result;
        }

        public int GetListCount()
        {
            return _employeeRegisterList.Count;
        }

        public void ClearList()
        {
            _employeeRegisterList = new Dictionary<int, Employee>();
        }

        public static Register Instance
        {
            get
            {
                if (_instance == null)
                    lock (Padlock)
                    {
                        if (_instance == null) _instance = new Register();
                    }

                return _instance;
            }
        }
    }
}