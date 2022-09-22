using NeoStackTask.Common;
using NeoStackTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NeoStackTask.ViewModels
{
    public class FunctionTableRow:BaseViewModel
    {
        private double _x;
        private double _y;
        private double? _f;
        private FunctionModel _function;

        /// <summary>Значение X</summary>
        public double X { get => _x; set => Set(ref _x, value); }

        /// <summary>Значение Y</summary>
        public double Y { get => _y; set => Set(ref _y, value); }

        /// <summary>Значение функции для текущих значений <see cref="X"/> и <see cref="Y"/></summary>
        public double? F { get => _f; private set => Set(ref _f, value); }


        /// <summary>Задаёт функцию от двух аргументов.</summary>
        /// <param name="function">Функция от двух аргументов.</param>
        public void SetFunction(FunctionModel function)
        {
            this._function = function ?? throw new ArgumentNullException(nameof(function));
            F = function?.Function(X, Y);
        }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);

            // Пересчёт значения Функции если изменилось значение X или Y.
            if (propertyName == nameof(X) || propertyName == nameof(Y))
                F = _function?.Function(X, Y);
        }
    }
}
