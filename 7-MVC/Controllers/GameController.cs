using Microsoft.AspNetCore.Mvc;
using _7_MVC.Models;
using Newtonsoft.Json;

namespace _7_MVC.Controllers {

    public class GameController : Controller {
        ControllerUtils Utils { get { return new(HttpContext); } }
        const string SessionDataKey = "GuessingGameData";

        [HttpGet]
        public IActionResult GuessingGame() {
            GuessingGame.SessionData? sessionData = GetSessionData();
            if (sessionData == null) {
                sessionData = new GuessingGame().Data;
                SetSessionData(sessionData);
            }
            ViewBag.SessionData = sessionData;
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(string guess) {
            GuessingGame.SessionData? sessionData = GetSessionData();

            if (sessionData == null) {
                sessionData = new GuessingGame().Data;
                SetSessionData(sessionData);
                ViewBag.ErrorMessage = "The session has expired. The game is restarted with a new number to guess";

            } else if (!int.TryParse(guess, out int guessedNumber)) {
                ViewBag.ErrorMessage = "Input is not a valid number, please try again";

            } else {
                GuessingGame model = new (sessionData);
                sessionData = model.CheckNumber(guessedNumber);
                SetSessionData(sessionData.IsSuccess ? new GuessingGame().Data : sessionData);
            }

            ViewBag.SessionData = sessionData;
            return View();
        }

        private GuessingGame.SessionData? GetSessionData() {
            return Utils.GetSessionData<GuessingGame.SessionData>(SessionDataKey);
        }

        private void SetSessionData(GuessingGame.SessionData data) {
            Utils.SetSessionData(SessionDataKey, data);
        }
    }
}
