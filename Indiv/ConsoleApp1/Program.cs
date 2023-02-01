using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
		// 7 задание
		static int[,] Task7(int[,] arr)
		{
			Random random = new Random();
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					arr[i, j] = random.Next(0, 20);
					Console.Write($"{arr[i, j]}\t");
				}
				Console.WriteLine();
			}
			return arr;
		}
		static int count15_1(int[,] arr)
		{
			int countOf15 = 0;
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				if (arr[i, 1] > 15)
					countOf15++;
			}
			return countOf15;
		}
		static double count15_2(int[,] arr)
		{
			double summOfNechet = 0;
			int countOfNechet = 0;
			for (int i = 0; i < arr.GetLength(1); i++)
			{
				if (arr[4, i] % 2 == 1)
				{
					summOfNechet += arr[4, i];
					countOfNechet++;
				}
			}
			return summOfNechet / countOfNechet;
		}
		static double count15_3(int[,] arr)
		{
			int summOf4 = 0;
			double countOf4 = 0;

			for (int i = 0; i < arr.GetLength(0); i++)
			{
				
				if (arr[i, 3] % 4 == 0 && arr[i, 3] != 0)
				{
					summOf4 += arr[i, 3];
					countOf4++;
				}
			}
			return summOf4 / countOf4;
		}
		// 14 задание
		static int[,] Task14(int[,] arr)
		{
			Random random = new Random();
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				Console.Write($"Вагон №{i + 1}:\t");
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					arr[i, j] = random.Next(0, 2);
					Console.Write($"{arr[i, j]} ");
					
				}
				Console.WriteLine();
			}
			return arr;
		}
		static void Main(string[] args)
        {
			// задание 3 (7 вариант)
			int[,] arr = new int[8, 5];
			arr = Task7(arr);
			int countOf15 = count15_1(arr);
			double countOfNechet = count15_2(arr);
			double countOf4 = count15_3(arr);

			Console.WriteLine($"Количество чисел 2 столбца, больших 15: {countOf15}");
			Console.WriteLine($"Среднее арифметическое нечетных чисел 5 строки: {countOfNechet}");
			Console.WriteLine($"Среднее арифметическое элементов 4-го столбца, кратных 4: {countOf4}");

			// задание 3 (14 вариант)
			/*int[,] arr = new int[10, 36];
			Console.WriteLine("Вагоны (1 - занято, 0 - свободно):");

			arr = Task14(arr);

			Console.Write("У какого вагона узнать число свободных мест: ");
			int vagon = Convert.ToInt32(Console.ReadLine());
			if (vagon > 10 || vagon <= 0) throw new Exception("Введен неправильный номер вагона.");

			int count = 0;
			for (int j = 0; j < arr.GetLength(1); j++)
			{
				if (arr[vagon - 1, j] == 0)
					count++;
			}
			Console.WriteLine($"Количество свободных мест {vagon} вагона = {count}");*/

			Console.ReadKey();
		}
    }
}
