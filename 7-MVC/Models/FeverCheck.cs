using System.Globalization;

namespace _7_MVC.Models {
    public class FeverCheck {
        public static string CheckTemperature(string input) {
            input = input?.Trim();
            if (string.IsNullOrWhiteSpace(input)) {
                // If there's no input then no message should be returned
                return "";
            } else if (!TryParseDouble(input, out double temp)) {
                return $"\"{input}\" is not a valid number, please try again!";
            } else {
                return CheckTemperature(temp);
            }
        }

        private static string CheckTemperature(double temperature) {
            double hypothermia = 35.0;  // 95.0 °F
            double fever = 37.5; // 99.5 °F
            if (temperature < hypothermia) {
                return $"A body temperature of {temperature} °C indicates that you have hypothermia";
            } else if (temperature > fever) {
                return $"A body temperature of {temperature} °C indicates that you have fever";
            } else {
                return $"A body temperature of {temperature} °C is in the normal range";
            }
        }

        private static bool TryParseDouble(string str, out double value) {
            string text = str.Replace(',', '.');
            NumberStyles numberstyle = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
            return double.TryParse(str, numberstyle, CultureInfo.InvariantCulture, out value);
        }
    }
}
