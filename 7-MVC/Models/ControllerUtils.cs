using Newtonsoft.Json;

namespace _7_MVC.Models {
    public class ControllerUtils {
        private HttpContext HttpContext;

        public bool TryGetSessionData<T>(string key, out T? data) where T : class? {
            string? str = HttpContext.Session.GetString(key);
            data = str == null ? null : JsonConvert.DeserializeObject<T>(str);
            return (data != null);
        }

        public void SetSessionData<T>(string key, T data) {
            var str = JsonConvert.SerializeObject(data);
            HttpContext.Session.SetString(key, str);
        }

        public T? GetSessionData<T>(string key) where T : class? {
            string? str = HttpContext.Session.GetString(key);
            return str == null ? null : JsonConvert.DeserializeObject<T>(str);
        }


        public ControllerUtils(HttpContext HttpContext) {
            this.HttpContext = HttpContext;
        }

        public bool TryGetSessionInt(string key, out int value) {
            int? storedValue = HttpContext.Session.GetInt32(key);
            return TryParseStoredNumber(storedValue, out value);
        }

        static public bool TryParseStoredNumber(int? storedValue, out int value) {
            value = 0;

            if (storedValue == null || !storedValue.HasValue) {
                return false;
            }
            value = storedValue.Value;
            return true;
        }


        static public int ParseInputNumber(string inputValue) {
            if (!int.TryParse(inputValue, out int ret)) {
                throw new Exception("Input is not a number");
            }
            return ret;
        }
    }
}
