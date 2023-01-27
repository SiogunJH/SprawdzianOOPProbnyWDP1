public static void Analyze(string logs) {
            string[] linijki = logs.Split('\n');

            // tu będziemy przechowywali kiedy dana osoba ostatni raz sie zalogowała
            Dictionary<string, List<DateTime>> OsobyKiedy = new Dictionary<string, List<DateTime>>();

            DateTime data_poczatkowa = DateTime.MinValue;
            DateTime date_koncowa = new DateTime();

            foreach(string linijka in linijki) {
                string[] dane = linijka.Split(' ');

                DateTime data = Convert.ToDateTime(dane[0]);
                //string godzina = dane[1]; // ..
                string osoba = dane[2];
                //string ip = dane[3]; // w zasadzie nie bedziemy tego używać ...

                if(data_poczatkowa == DateTime.MinValue) {
                    data_poczatkowa = data;
                }

                if(!OsobyKiedy.ContainsKey(osoba)) {
                    OsobyKiedy[osoba] = new List<DateTime>(); 
                }

                // jeśli data była to nie dodajemy jej drugi raz
                if(!OsobyKiedy[osoba].Contains(data)) {
                    OsobyKiedy[osoba].Add(data);
                }

                date_koncowa = data; // ostatnie co zostanie tu zaousane to data ostatniego logowania
            }

            List<string> osoby = new List<string>();

            foreach(var osoba in OsobyKiedy) {
                bool czy_wszystkie_dni = true;
                DateTime ostatnia_data = data_poczatkowa;
                while(ostatnia_data <= date_koncowa) {
                    if(!osoba.Value.Contains(ostatnia_data)) {
                        czy_wszystkie_dni = false;
                        break;
                    }
                    ostatnia_data = ostatnia_data.AddDays(1);
                }

                if(czy_wszystkie_dni) {
                    osoby.Add(osoba.Key);
                }
            }

            osoby.Sort();

            if(osoby.Count == 0)
                Console.WriteLine("empty");
            else
                Console.WriteLine(string.Join(", ", osoby));

        }