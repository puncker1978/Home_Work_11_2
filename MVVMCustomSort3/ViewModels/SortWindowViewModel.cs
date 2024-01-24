using MVVMCustomSort3.Infrastructure.Commands.Base;
using MVVMCustomSort3.Models;
using MVVMCustomSort3.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCustomSort3.ViewModels
{
    internal class SortWindowViewModel : ViewModel
    {
        #region Поля
        private static readonly string[] sortParameter = { "Имя", "Возраст" };
        private static readonly string[] sortDirection = { "По возрастанию", "По убыванию" };

        private static readonly Dictionary<string, string> sortParameterDictionary = new Dictionary<string, string>
        {
            [sortParameter[0]] = "Name",
            [sortParameter[1]] = "Age",
        };
        private static readonly Dictionary<string, string> sortDirectionDictionary = new Dictionary<string, string>
        {
            [sortDirection[0]] = "asc",
            [sortDirection[1]] = "desc"
        };

        private static string firstSortParameter;
        private static string firstSortDirection;
        private static string argumentSort;

        private ObservableCollection<Person> people;

        #endregion Поля

        #region Свойства
        public static string[] SortParameter => sortParameter;

        public static string[] SortDirection => sortDirection;

        public static string FirstSortParameter
        {
            get => firstSortParameter;
            set
            {
                if (value == null)
                {
                    firstSortParameter = value;
                }
            }
        }
        public static string FirstSortDirection
        {
            get => firstSortDirection;
            set 
            {
                if (value == null)
                {
                    firstSortDirection = value;
                }
            } 
        }

        public static string ArgumentSort
        {
            get => argumentSort;
            set
            {
                if (value == null)
                {
                    argumentSort = value;
                }
            }
        }

        public ObservableCollection<Person> People
        {
            get => people;
            set
            {
                if (people == value)
                { 
                    return; 
                }
                else
                {
                    people = value;
                    NotifyPropertyChanged(nameof(People));
                }
                people = value;
            }
        }
        #endregion Свойства

        #region Методы
        static private IEnumerable<Person> SortClientMethod(ObservableCollection<Person> _people)
        {
            if (!string.IsNullOrEmpty(FirstSortParameter) && !string.IsNullOrEmpty(FirstSortDirection))
            {
                ArgumentSort = sortParameterDictionary[FirstSortParameter] + " " + sortDirectionDictionary[FirstSortDirection];
            }

            IEnumerable<Person> result;

            result = _people.AsQueryable().OrderBy(ArgumentSort);

            return result;
        }
        #endregion Методы

        #region Команды
        public Command SortPeopleCommand { get; set }

        private bool CanSortPeople(object obj) => true;

        #endregion Команды

        #region Конструкторы
        public SortWindowViewModel()
        {
        }


        #endregion Конструкторы

    }
}
