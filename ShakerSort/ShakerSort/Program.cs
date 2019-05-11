using System;

namespace ShakerSort
{
    class Program
    {
        static void Main(string[] args) => Process();

        static string answer;
        static void Process(){
            Console.WriteLine("ShakerSort");
            Console.Write("Enter array elements: ");
            var parts = Console.ReadLine().Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var array = new int[parts.Length];
            for (var i = 0; i < parts.Length; i++)
                array[i] = Convert.ToInt32(parts[i]);
            Console.WriteLine($"Sorted array: {string.Join(", ", ShakerSort(array))}");
            Repeat();
        }

        static void Repeat(){
            Console.Write("\nWhat to sort another array? (yes/no) - ");
            answer = Console.ReadLine().ToLower().ToString();
            if (answer == "yes"){
                Console.Clear();
                Process();
                return;
            }
            else if (answer == "no"){
                Console.Clear();
                Console.WriteLine("Shuting Down...");
                return;
            }
            else
            {
                Console.WriteLine("Try again...");
                Repeat();
                return;
            }
        }

        static void Swap(ref int el1, ref int el2){
            var temp = el1;
            el1 = el2;
            el2 = el1;
        }

        static int[] ShakerSort(int[] array){
            for (var i = 0; i < array.Length / 2; i++){

                bool swapFlag = false; //exchange check

                //left to right pass
                for (var j = 0; j < array.Length - i - 1; j++){
                    if (array[j] > array[j + 1]){
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                }   }

                //rigth to left pass
                for (var j = array.Length - 2 - i; j > i; j--) {
                    if (array[j - 1] > array[j]) {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                }   }

                if (!swapFlag)
                    break;
            }

            return array;
        }
    }
}
