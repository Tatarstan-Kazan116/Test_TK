using System;

namespace TK.Logic
{
    /// <summary>
    /// Статический класс, содержащий всю бизнес-логику конвертации.
    /// </summary>
    public static class ConverterLogic
    {
        public static double ConvertMetersToKilometers(double meters)
        {
            ValidateDistance(meters);
            return meters / 1000.0;
        }

        public static double ConvertKilometersToMeters(double kilometers)
        {
            ValidateDistance(kilometers);
            return kilometers * 1000.0;
        }

        public static double ConvertCelsiusToFahrenheit(double celsius)
        {
            ValidateNumber(celsius);
            return (celsius * 9.0 / 5.0) + 32.0;
        }

        public static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            ValidateNumber(fahrenheit);
            return (fahrenheit - 32.0) * 5.0 / 9.0;
        }

        // Валидация для расстояний (не может быть отрицательным)
        private static void ValidateDistance(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Значение должно быть конечным числом.");
            if (value < 0)
                throw new ArgumentException("Расстояние не может быть отрицательным.");
        }

        // Валидация для температуры (отрицательные значения допустимы)
        private static void ValidateNumber(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Значение должно быть конечным числом.");
        }
    }
}