using System.Globalization;

namespace _7_MVC.Models {
    public class FeverCheck {
        public static string CheckTemperature(string input) {
            string str = (input ?? "").Trim();
            if (string.IsNullOrWhiteSpace(str)) {
                // If there's no input then no message should be returned
                return "";
            } else if (!TryParseDouble(str, out double temperature)) {
                return $"\"{str}\" is not a valid number, please try again!";
            } else {
                return CheckTemperature(temperature);
            }
        }

        public static string CheckTemperature(double temperature) {
            const double hypothermia = 35.0;  // 95.0 °F
            const double fever = 37.5; // 99.5 °F
            return temperature switch {
                < hypothermia => $"A body temperature of {temperature} °C indicates that you have hypothermia",
                > fever => $"A body temperature of {temperature} °C indicates that you have fever",
                _ => $"A body temperature of {temperature} °C is in the normal range",
            };
        }

        private static bool TryParseDouble(string str, out double value) {
            str = str.Replace(',', '.');
            NumberStyles numberstyle = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
            return double.TryParse(str, numberstyle, CultureInfo.InvariantCulture, out value);
        }
    }
}
