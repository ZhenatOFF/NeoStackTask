using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoStackTask.Models
{
    public class FunctionModel
    {
        /// <summary>Имя Функции</summary>
        public string Name { get; set; }
        public Func<double,double,double> Function { get; set; }

        /// <summary>Коэффициент A</summary>
        public double A { get; set; }

        /// <summary>Коэффициент B</summary>
        public double B { get; set; }

        /// <summary>Коэффициент C</summary>
        public double C { get; set; }

        /// <summary>Возможные значения коэффициента C</summary>
        public List<double> Arguments { get; set; }

        /// <summary>Создаёт экземпляр <see cref="FunctionModel"/>.</summary>
        /// <param name="name">Имя Функции.</param>
        /// <param name="function">Делегат Функции.</param>
        public FunctionModel(string name, IEnumerable<double> arguments, Func<double, double, double, double, double, double> function)
        {
            Name = name;
            Arguments = arguments.ToList();
            _function = function ?? throw new ArgumentNullException(nameof(function));
            Function = Calculate;
        }

        private readonly Func<double, double, double, double, double, double> _function;
        private double Calculate(double x, double y)
        {
            return _function(A, B, C, x, y);
        }
    }
}
