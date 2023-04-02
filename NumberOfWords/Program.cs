namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = InputFileName();
            if (fileName == ""){
                Console.WriteLine("Error");
            }else{
                ReadFile file = new ReadFile(fileName);
                file.writeToFile("dict.txt");
                file.printToConsole();
            }
        }

        static private string InputFileName(){
            string? fileName;
            Console.WriteLine("Enter File name with extension txt:");
            fileName = Console.ReadLine();
        
            while ((fileName == "") || (!File.Exists(fileName+".txt"))){
                Console.WriteLine("file not found enter file Name");
                fileName = Console.ReadLine();
            }
            if (fileName == null){
                fileName = "";
                return fileName;
            }else{
                return fileName;
            }
        }
    }
}