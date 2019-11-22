using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;

namespace Tema_7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex1_File();
            //Ex2_WebFile();
            //Ex3_EnterNumbers();

            Console.ReadKey();
        }

        private static void Ex3_EnterNumbers()
        {
            int start = 0;
            int end = 100;
            const int count = 10;


            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            try
            {
                if (numbers.Any(x => x < start) || numbers.Any(x => x > end) || !IsIncreasing(numbers))
                {
                    throw new ArgumentException();
                }

                Console.WriteLine("1 < " + string.Join(" < ", numbers) + " < 100");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }


            static bool IsIncreasing(List<int> numbers)
            {
                for (int i = 1; i < numbers.Count; i++)
                {

                    if (numbers[i - 1].CompareTo(numbers[i]) >= 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private static void Ex2_WebFile()
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    Console.WriteLine("\n Start downloading...");
                    webClient.DownloadFile("https://image.shutterstock.com/image-vector/cute-happy-ninja-smiling-his-260nw-359792546.jpg", "../../ninja.jpg");
                    Console.WriteLine("\n Download successfully!");
                }

                catch (ArgumentException)
                {
                    Console.Error.WriteLine("\n Error: You have entered an empty URL!");
                }
                catch (WebException)
                {
                    Console.Error.WriteLine("\n Error: You have entered an invalid URL!");
                }
                catch (NotSupportedException)
                {
                    Console.Error.WriteLine("\n Error: This method does not support simultaneous downloads!");
                }
                finally
                {
                    Console.WriteLine("\nDone!\n");
                }
            }
        }

        private static void Ex1_File()
        {
            Console.Write("Enter the full path of the file you want to read: ");
            string filePath = Console.ReadLine();


            try
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine("The content of the file is: ");
                Console.WriteLine(fileContent);
            }

            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Error: Path is null.");
            }

            catch (ArgumentException)
            {
                Console.Error.WriteLine("Error: Path is a zero-length string, contains only white space, or contains one or more invalid characters.");
            }

            catch (PathTooLongException)
            {
                Console.Error.WriteLine("Error: The specified path, file name, or both exceed the system-defined maximum length.");
            }

            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Error: The specified path is invalid.");
            }

            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Error: The file specified in path was not found.");
            }

            catch (IOException)
            {
                Console.Error.WriteLine("Error: An I/O error occurred while opening the file.");
            }

            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine("Error: The caller does not have the required permission.");
            }

            catch (NotSupportedException)
            {
                Console.Error.WriteLine("Error: Path is in an invalid format.");
            }

            catch (SecurityException)
            {
                Console.Error.WriteLine("Error: The caller does not have the required permission.");
            }
        }
    }
}
