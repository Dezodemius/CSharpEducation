namespace Practice
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Task1();
            // Задание2
            // Задание3
        }

        internal static void Task1()
        {
            Console.Write("Введите длину массива: ");
            string userInput = Console.ReadLine();
            int length = int.Parse(userInput);
            int[] array = new int[length];

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите элемент под индексом {0}: ", i);
                string input = Console.ReadLine();
                array[i] = int.Parse(input);
                sum += array[i];
            }

            Console.WriteLine("Сумма чисел массива: {0}", sum);
        }
    }
}