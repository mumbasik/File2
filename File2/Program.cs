namespace File2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //N1
            Random rand = new Random();
            List<int> primes = new List<int>();
            List<int> fibs = new List<int>();
            int[] numbers = new int[100];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 1000);
                if (IsPrime(numbers[i]))
                    primes.Add(numbers[i]);
                if (IsFibonacci(numbers[i]))
                    fibs.Add(numbers[i]);
            }

            File.WriteAllLines("primes.txt", primes.ConvertAll(x => x.ToString()));
            File.WriteAllLines("fibonacci.txt", fibs.ConvertAll(x => x.ToString()));

            Console.WriteLine($"Generated numbers: {numbers.Length}");
            Console.WriteLine($"Prime numbers: {primes.Count}");
            Console.WriteLine($"Fibonacci numbers: {fibs.Count}");


            //N2
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();

            Console.WriteLine("Enter the word to search for:");
            string searchWord = Console.ReadLine();

            Console.WriteLine("Enter the word to replace with:");
            string replaceWord = Console.ReadLine();

            string content = File.ReadAllText(path);
            int count = (content.Length - content.Replace(searchWord, "").Length) / searchWord.Length;

            content = content.Replace(searchWord, replaceWord);
            File.WriteAllText(path, content);

            Console.WriteLine($"Replaced {count} occurrences of '{searchWord}' with '{replaceWord}'");
            //N3
            Console.WriteLine("Enter text file path:");
            string textPath = Console.ReadLine();

            Console.WriteLine("Enter moderation words file path:");
            string moderationWordsPath = Console.ReadLine();

            string textContent = File.ReadAllText(textPath);
            string[] moderationWords = File.ReadAllLines(moderationWordsPath);

            foreach (string word in moderationWords)
            {
                string stars = new string('*', word.Length);
                textContent = textContent.Replace(word, stars);
            }

            File.WriteAllText(textPath, textContent);
            Console.WriteLine("Moderation completed.");
            //N4

            Console.WriteLine("Enter folder path:");
            string folderPath = Console.ReadLine();

            Console.WriteLine("Enter file mask (e.g. *.txt):");
            string mask = Console.ReadLine();

            string[] files = Directory.GetFiles(folderPath, mask, SearchOption.AllDirectories);

            Console.WriteLine("Found files:");
            foreach (var file in files)
                Console.WriteLine(file);

            Console.WriteLine("Do you want to delete them? (yes/no)");
            if (Console.ReadLine() == "yes")
            {
                foreach (var file in files)
                    File.Delete(file);
                Console.WriteLine("Files deleted.");
            }
            //N5
            string[] lines = File.ReadAllLines("numbers.txt");
            int[] numberss = lines.Select(int.Parse).ToArray();

            var positive = numberss.Where(x => x > 0).ToArray();
            var negative = numberss.Where(x => x < 0).ToArray();
            var twoDigits = numberss.Where(x => x >= 10 && x <= 99 || x <= -10 && x >= -99).ToArray();
            var fiveDigits = numberss.Where(x => x >= 10000 && x <= 99999 || x <= -10000 && x >= -99999).ToArray();

            File.WriteAllLines("positive.txt", positive.Select(x => x.ToString()));
            File.WriteAllLines("negative.txt", negative.Select(x => x.ToString()));
            File.WriteAllLines("twoDigits.txt", twoDigits.Select(x => x.ToString()));
            File.WriteAllLines("fiveDigits.txt", fiveDigits.Select(x => x.ToString()));

            Console.WriteLine($"Positive numbers: {positive.Length}");
            Console.WriteLine($"Negative numbers: {negative.Length}");
            Console.WriteLine($"Two-digit numbers: {twoDigits.Length}");
            Console.WriteLine($"Five-digit numbers: {fiveDigits.Length}");

        }
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }

        static bool IsFibonacci(int number)
        {
            int a = 0, b = 1;
            while (b < number)
            {
                int temp = b;
                b = a + b;
                a = temp;
            }
            return b == number || number == 0;
        }
    }
}
