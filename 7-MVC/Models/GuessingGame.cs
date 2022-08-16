using Microsoft.AspNetCore.Mvc;

namespace _7_MVC.Models {

    public class GuessingGame {
        static private readonly Random rnd = new();
        const int MaxNumber = 100;
        public SessionData Data { get; set; }

        public GuessingGame() : this(new SessionData()) { }

        public GuessingGame(SessionData data) {
            Data = data;
        }

        static public int NewNumber() {
            return rnd.Next(1, MaxNumber + 1);
        }

        public SessionData CheckNumber(int inputValue) {
            Data.NGuesses += 1;
            Data.LastGuess = inputValue;
            switch (Math.Sign(inputValue - Data.TargetNumber)) {
                case 0:
                    Data.MessageLine1 = $"SUCCESS!!! You found the secret number {Data.TargetNumber} in {Data.NGuesses} tries!";
                    Data.LowerBound = 1;
                    Data.UpperBound = MaxNumber;
                    Data.IsSuccess = true;
                    break;
                case 1:
                    Data.MessageLine1 = "The number you tried is too large, try a smaller number.";
                    Data.UpperBound = Math.Min(inputValue - 1, Data.UpperBound);
                    Data.IsSuccess = false;
                    break;
                case -1:
                    Data.MessageLine1 = "The number you tried is too small, try a larger number.";
                    Data.LowerBound = Math.Max(inputValue + 1, Data.LowerBound);
                    Data.IsSuccess = false;
                    break;
            }
            SetMessageLine2();
            return Data;
        }

        private void SetMessageLine2() {
            if (Data.IsSuccess) {
                Data.MessageLine2 = $"Try to find the next secret number in the range {Data.LowerBound} to {Data.UpperBound}";
            } else if (Data.LastGuess.HasValue) {
                Data.MessageLine2 = $"Your last guessed was {Data.LastGuess}. The secret number is in the range {Data.LowerBound} to {Data.UpperBound}. So far you have {Data.NGuesses} tries.";
            } else {
                Data.MessageLine2 = $"The secret number is in the range {Data.LowerBound} to {Data.UpperBound}, So far you have {Data.NGuesses} tries.";
            }
        }

        public class SessionData {
            public int? LastGuess { get; set; }
            public int TargetNumber { get; set; }
            public int LowerBound { get; set; }
            public int UpperBound { get; set; }
            public int NGuesses { get; set; } = 0;
            public string MessageLine1 { get; set; } = "";
            public string MessageLine2 { get; set; } = "";
            public bool IsSuccess { get; set; } = false;

            public SessionData() {
                LowerBound = 1;
                UpperBound = MaxNumber;
                TargetNumber = NewNumber();
            }
        }
    }
}
