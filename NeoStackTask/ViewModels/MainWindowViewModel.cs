using NeoStackTask.Common;
using NeoStackTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NeoStackTask.ViewModels
{
    public class MainWindowViewModel: BaseViewModel
    {
        private FunctionModel _selectedFunction = new FunctionModel("Линейная",
                new List<double> { 1, 2, 3, 4, 5 },
                (a, b, c, x, y) => a* x + b* 1 + c)
            { C = 1 }; 
        private bool _isNewFunction;
        private RelayCommand _inputFunctionCommand;
        private RelayCommand _inputXyCommand;
        private string _selectedFunctionName;

        public MainWindowViewModel()
        {
            Functions.Add(new FunctionModel("Линейная",
                new List<double> { 1, 2, 3, 4, 5 },
                (a, b, c, x, y) => a * x + b * 1 + c)
            { C = 1 });
            Functions.Add(new FunctionModel("Квадратичная",
                new List<double> { 10, 20, 30, 40, 50 },
                (a, b, c, x, y) => a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c)
            { C = 10 });
            Functions.Add(new FunctionModel("Кубическая",
                new List<double> { 100, 200, 300, 400, 500 },
                (a, b, c, x, y) => a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c)
            { C = 100 });
            Functions.Add(new FunctionModel("4-ой степени",
                new List<double> { 1000, 2000, 3000, 4000, 5000 },
                (a, b, c, x, y) => a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c)
            { C = 1000 });
            Functions.Add(new FunctionModel("5-ой степени",
                new List<double> { 10000, 20000, 30000, 40000, 50000 },
                (a, b, c, x, y) => a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c)
            { C = 10000 });

            CalculatedFunctions.CollectionChanged += OnRowsChanged;
            IsNewFunction = true;
        }

        private void OnRowsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Добавление выбранной Функции в новую строку.
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (FunctionTableRow row in e.NewItems)
                {
                    row.SetFunction(SelectedFunction);
                }
        }

        /// <summary>Обновление таблицы значений</summary>
        private void UpdateCalculatedFunctions()
        {
            foreach (FunctionTableRow row in CalculatedFunctions)
            {
                row.SetFunction(SelectedFunction);
            }
        }

        /// <summary>Обработчик изменения TextBox-ов с коэффициентами</summary>
        public void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCalculatedFunctions();
        }

        /// <summary>Обработчик нажатия по элементу списка функций</summary>
        public void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsNewFunction = false;
            UpdateCalculatedFunctions();
        }


        /// <summary>Выбранная Функция</summary>
        public FunctionModel SelectedFunction { get => _selectedFunction; set => Set(ref _selectedFunction, value); }

        /// <summary>Список Функций</summary>
        public ObservableCollection<FunctionModel> Functions { get; set; } = new ObservableCollection<FunctionModel>();

        /// <summary>Режим изменения Функции.</summary>
        public bool IsNewFunction { get => _isNewFunction; set => Set(ref _isNewFunction, value); }

        /// <summary>Строки вычисленных значений</summary>
        public ObservableCollection<FunctionTableRow> CalculatedFunctions { get; }
            = new ObservableCollection<FunctionTableRow>();

        /// <summary>Команда перехода в режим изменения Функции.</summary>
        public RelayCommand InputFunctionCommand => _inputFunctionCommand
         ?? (_inputFunctionCommand = new RelayCommand
        (
             execute: obj => { IsNewFunction = true; CalculatedFunctions.Clear(); SelectedFunctionName = string.Empty; },
             canExecute: obj => !IsNewFunction
        ));

        /// <summary>Команда перехода в режим ввода X и Y.</summary>
        public RelayCommand InputXyCommand => _inputXyCommand
         ?? (_inputXyCommand = new RelayCommand
        (
             execute: obj => { IsNewFunction = false; CalculatedFunctions.Clear(); SelectedFunctionName = SelectedFunction?.Name; },
             canExecute: obj => IsNewFunction
        ));

        /// <summary>Имя Функции для которой вводятся X и Y.</summary>
        public string SelectedFunctionName { get => _selectedFunctionName; private set => Set(ref _selectedFunctionName, value); }
    }
}
