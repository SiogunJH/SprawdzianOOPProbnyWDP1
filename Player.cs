using System;

namespace Sprawdzian
{
    class Player
    {
        //FIELD I PROPERTY
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value == null) throw new ArgumentException("Wrong name!");
                value = value.Trim().ToLower();
                value = String.Join("", value.Split(' ', StringSplitOptions.RemoveEmptyEntries));

                if (value.Length < 3 || !Char.IsLetter(value[0])) throw new ArgumentException("Wrong name!");

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(value[i])) throw new ArgumentException("Wrong name!");
                }
                _Name = value;
            }
        }
        private string _Password;
        private string Password
        {
            get { return _Password; }
            set
            {
                if (value == null) throw new ArgumentException("Wrong password!");
                if (value.Length < 8 || value.Length > 16) throw new ArgumentException("Wrong password!");

                bool hasLetterSmall = false;
                bool hasLetterBig = false;
                bool hasDigit = false;
                bool hasOther = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (Char.IsDigit(value[i])) hasDigit = true;
                    if (Char.IsUpper(value[i])) hasLetterBig = true;
                    if (Char.IsLower(value[i])) hasLetterSmall = true;
                    if (!Char.IsLetterOrDigit(value[i])) hasOther = true;
                }
                if ((hasDigit && hasLetterBig && hasLetterSmall && hasOther) == false) throw new ArgumentException("Wrong password!");

                if (value != value.Trim()) throw new ArgumentException("Wrong password!");
                _Password = value;
            }
        }
        public int _BestScore = 0;
        public int BestScore
        {
            get { return _BestScore; }
            set { _BestScore = value; }
        }
        public int _LastScore = 0;
        public int LastScore
        {
            get { return _LastScore; }
            set { _LastScore = value; }
        }
        public double _AvgScore = 0;
        public double AvgScore
        {
            get { return _AvgScore; }
            set { _AvgScore = value; }
        }
        public int _TotalGames = 0;
        public int TotalGames
        {
            get { return _TotalGames; }
            set { _TotalGames = value; }
        }

        //FUNKCJE
        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        public void AddScore(int currentScore)
        {
            if (currentScore < 0 || currentScore > 100)
            {
                throw new ArgumentOutOfRangeException("Wrong value!");
            }

            if (currentScore > BestScore) BestScore = currentScore;

            LastScore = currentScore;

            AvgScore = (AvgScore * TotalGames + currentScore) / (TotalGames + 1);
            TotalGames++;
        }

        public bool TryAddScore(int currentScore)
        {
            if (currentScore < 0 || currentScore > 100) return false;

            if (currentScore > BestScore) BestScore = currentScore;

            LastScore = currentScore;

            AvgScore = Math.Round((AvgScore * TotalGames + currentScore) / (TotalGames + 1), 1);
            TotalGames++;

            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!VerifyPassword(oldPassword)) return false;
            try
            {
                Password = newPassword;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //KONSTRUKTOR
        public Player(string name, string password)
        {
            Name = name;
            Password = password;
        }

        //OVERRIDE
        public override string ToString()
        {
            if (AvgScore * 10 % 10 == 0)
                return String.Format("Name: {0}, Score: last={1}, best={2}, avg={3:F0}", Name, LastScore, BestScore, AvgScore);
            return String.Format("Name: {0}, Score: last={1}, best={2}, avg={3:F1}", Name, LastScore, BestScore, AvgScore);
        }
    }
}