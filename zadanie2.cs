class Player {
        private string _name = "";
        public string Name {
            get {
                return _name;
            }
            set {
                if(value == null || value.Length < 3 || char.IsDigit(value[0])) {
                    throw new ArgumentException("Wrong name!");
                }

                value = value.Replace(" ", "").ToLower();

                foreach(char c in value) {
                    if(!char.IsLetterOrDigit(c)) {
                        throw new ArgumentException("Wrong name!");
                    }
                }

                _name = value;
            }
        }

        private string password;

        
        public int BestScore { get; private set; }
        public int LastScore { get; private set; }

        private int n_scores = 0;
        private double _avg;
        public double AvgScore { 
            get {
                return Math.Round(_avg, 1);
            }  
            private set {
                _avg = value;
            }
        }

        public Player(string name, string password) {
            Name = name;

            if(!CheckPasswordValidity(password)) {
                throw new ArgumentException("Wrong password!");
            }
            this.password = password;

            BestScore = 0;
            LastScore = 0;
            AvgScore = 0;
        }

        public bool ChangePassword(string oldPassword, string newPassword) {
            if(!VerifyPassword(oldPassword))
                return false;

            if(!CheckPasswordValidity(newPassword)) {
                return false;

            }

            password = newPassword;
            return true;  
        }

        private static bool CheckPasswordValidity(string pass) {
            if(pass == null)
                return false;

            if(pass.Length > 16 || pass.Length < 8)
                return false;

            if(char.IsWhiteSpace(pass[0]) || char.IsWhiteSpace(pass[pass.Length - 1]))
                return false;
            
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            foreach(char c in pass) {
                if(char.IsUpper(c)) {
                    hasUpper = true;
                } else if(char.IsLower(c)) {
                    hasLower = true;
                } else if(char.IsDigit(c)) {
                    hasDigit = true;
                } else if(char.IsPunctuation(c) || char.IsSymbol(c)) {
                    hasSpecial = true;
                }
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        public bool VerifyPassword(string pass) {
            return password == pass;
        }

        public bool TryAddScore(int currentScore) {
            if(currentScore > 100 || currentScore < 0) {
                return false;
            }

            BestScore = Math.Max(BestScore, currentScore);
            LastScore = currentScore;

            n_scores++;
            _avg = (_avg * (n_scores - 1) + currentScore) / n_scores;
            return true;
        }

        public void AddScore(int currentScore) {
            if(!TryAddScore(currentScore)) {
                throw new ArgumentOutOfRangeException(null, "Wrong value!");
            }
        }

        public override string ToString() {
            return $"Name: {Name}, Score: last={LastScore}, best={BestScore}, avg={AvgScore}";
        }

    }