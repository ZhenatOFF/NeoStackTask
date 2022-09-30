using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NeoStackTask.Validation
{
    /// <summary>
    /// Класс, реализующий ValidationRule, для конвертации string в double
    /// </summary>
    public class StringToDoubleValidationRule : ValidationRule
    {
        /// <summary>
        /// Проверяет на возможность конвертирования 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>Возвращает </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double i;
            if (double.TryParse(value.ToString(), out i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Please enter a valid value");
        }
    }
}
