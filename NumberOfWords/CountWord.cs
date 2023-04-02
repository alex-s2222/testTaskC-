namespace MyApp
{
    class ReadFile{
        private string fileName;
        private Dictionary<string, UInt64> countWord;

        public ReadFile(string fileName)
        {
            this.fileName = fileName + ".txt";
            this.countWord = new Dictionary<string, UInt64>();
        }

        public void writeToFile(string fileName){
            if (this.countWord.Count < 1){
                readFile();
            }

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (KeyValuePair<string, UInt64> kvp in this.countWord.OrderByDescending(key => key.Value))
                    {
                        writer.WriteLine($"{kvp.Key}\t {kvp.Value}");
                    }
                }
            Console.WriteLine("File is on the desktop");
        }

        public void printToConsole(){
            if (this.countWord.Count < 1){
                readFile();
            }

            foreach (KeyValuePair<string, UInt64> kvp in this.countWord.OrderByDescending(key => key.Value)){
                Console.WriteLine($"{kvp.Key}\t {kvp.Value}");
            }   
        }

        private void readFile(){
            using(StreamReader file = new StreamReader(new FileStream(this.fileName, FileMode.Open))) {
                int counter = 0;
                string? ln = "";

                while ((ln = file.ReadLine())!= null)
                {
                    splitingLineToWords(ln);
                    counter++;
                }

                file.Close();
            }
        }


        private void addWordInDict(string word){
            UInt64 count = 0;
            word = word.ToLower();
            if (!this.countWord.TryGetValue(word, out count)) {
                this.countWord.Add(word, 1);
            }else{
                this.countWord[word] += 1;
            }
        }

        private void splitingLineToWords(string line){
            char[] separators = new char[] { ' ', '.', '?', '!', '"', ':', ';', '-', ',' ,'«','»', '(', ')', '…', '–'};
            string[] subs = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var word in subs)
            {
                addWordInDict(word);
            }
        }


    }
}