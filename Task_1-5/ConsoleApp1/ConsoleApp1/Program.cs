using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		// 1
		static void Zarplata(double[,] a)
		{
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					Console.Write($"{a[i, j]}\t");
				}
				Console.WriteLine();
			}
		}
		static void DenRojdenia(DateTime[] date, int n)
		{
			for (int i = 0; i < n; i++)
				Console.WriteLine($"День рождения {i + 1} работника: {date[i]:dd.MM.yyyy}");
		}

		// 2
		static double MaxZp(double[,] a, int index)
		{
			double max = double.MinValue;
			for (int j = 0; j < a.GetLength(1); j++)
			{
				if (a[index - 1, j] > max)
					max = a[index - 1, j];
			}
			return max;
		}
		// 4
		static void Tabel(DateTime dt1, DateTime dt2)
		{
			int days = (int)(dt2 - dt1).TotalDays;
			int holidays = 0;
			DateTime checkDateTime = dt1;
			do
			{
				string mm = checkDateTime.ToString("MM");
				if (checkDateTime.DayOfWeek == DayOfWeek.Saturday || checkDateTime.DayOfWeek == DayOfWeek.Sunday)
				{
					Console.Write($"{checkDateTime.ToString("dd.MM.yyyy (dddd)")} - выходной день. ");
					if (mm == "12" || mm == "01" || mm == "02") Console.WriteLine("Время года - зима;");
					else if (mm == "03" || mm == "04" || mm == "05") Console.WriteLine("Время года - весна;");
					else if (mm == "06" || mm == "07" || mm == "08") Console.WriteLine("Время года - лето;");
					else Console.WriteLine("Время года - осень;");
					holidays++;
				}
				else
				{
					Console.Write($"{checkDateTime.ToString("dd.MM.yyyy (dddd)")} - рабочий день. ");
					if (mm == "12" || mm == "01" || mm == "02") Console.WriteLine("Время года - зима;");
					else if (mm == "03" || mm == "04" || mm == "05") Console.WriteLine("Время года - весна;");
					else if (mm == "06" || mm == "07" || mm == "08") Console.WriteLine("Время года - лето;");
					else Console.WriteLine("Время года - осень;");
				}

				checkDateTime = checkDateTime.AddDays(1.0);
			} while (checkDateTime <= dt2);

			Console.WriteLine($"Количество выходных дней = {holidays}");
			Console.WriteLine($"Количество рабочих дней = {days - holidays}");
		}

		// 5.1
		static void Goda(int k)
		{
			if (k >= 5 && k <= 20) Console.WriteLine($"{k} лет");
			else
			{
				int index = k % 10;
				switch (index)
				{
					case 1:
						Console.WriteLine($"{k} год");
						break;
					case 2:
					case 3:
					case 4:
						Console.WriteLine($"{k} года");
						break;
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
						Console.WriteLine($"{k} лет");
						break;
				}
			}
		}

		// 5.2
		static void Date(int day, int mounth)
		{
			switch (mounth)
			{
				case 1:
					Console.WriteLine($"{day} января");
					break;
				case 2:
					if (day <= 29)
						Console.WriteLine($"{day} февраля");
					else Console.WriteLine("В феврале  может быть не больше 29 дней.");
					break;
				case 3:
					if (day <= 31)
						Console.WriteLine($"{day} марта");
					else Console.WriteLine("В марте не больше 31 дня.");
					break;
				case 4:
					if (day <= 30)
						Console.WriteLine($"{day} апреля");
					else Console.WriteLine("В апреле не больше 30 дней.");
					break;
				case 5:
					Console.WriteLine($"{day} мая");
					break;
				case 6:
					if (day <= 30)
						Console.WriteLine($"{day} июня");
					else Console.WriteLine("В июне не больше 30 дней.");
					break;
				case 7:
					Console.WriteLine($"{day} июля");
					break;
				case 8:
					Console.WriteLine($"{day} августа");
					break;
				case 9:
					if (day <= 30)
						Console.WriteLine($"{day} сентября");
					else Console.WriteLine("В сентябре не больше 30 дней.");
					break;
				case 10:
					Console.WriteLine($"{day} октября");
					break;
				case 11:
					if (day <= 30)
						Console.WriteLine($"{day} ноября");
					else Console.WriteLine("В ноябре не больше 30 дней.");
					break;
				case 12:
					Console.WriteLine($"{day} декабря");
					break;
			}
		}

		static void Main(string[] args)
		{
			try
			{
				// 1
				/*Console.Write("Количество месяцев: ");
				int m = Convert.ToInt32(Console.ReadLine());
				if (m > 12) throw new Exception("Количество месяцев не должно превышать 12.");

				Console.Write("Количество работников: ");
				int n = Convert.ToInt32(Console.ReadLine());

				double[,] a = new double[n, m];
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						Console.Write($"Введите з/п для {i + 1} работника, {j + 1} месяца: ");
						a[i, j] = Convert.ToDouble(Console.ReadLine());
					}
				}
				var islDate = new DateTime(2005, 1, 1);
				DateTime[] date = new DateTime[n];
				for (int i = 0; i < n; i++)
				{
					Console.Write($"Введите день рождения {i + 1} работника: ");
					date[i] = DateTime.Parse(Console.ReadLine());
					if (date[i] > DateTime.Now) throw new Exception("Ошибка вводе даты.");
					else if (date[i] > islDate) throw new Exception("Ошибка вводе даты..");
				}
				Zarplata(a);
				DenRojdenia(date, n);
				// 2
				Console.Write("Для какого работника найти наибольшую з/п: ");
				int index = Convert.ToInt32(Console.ReadLine());
				double max = MaxZp(a, index);
				Console.WriteLine($"Максимальная з/п у {index} работника: {max}");
			  
				// 4
				for (int i = 0; i < n; i++) 
				{
					Console.WriteLine($"Введите дату, с которой соcтавить график для {i + 1} сотрудника: ");
					DateTime dt1 = DateTime.Parse(Console.ReadLine());
					DateTime dt2 = dt1.AddYears(1);
					Tabel(dt1, dt2);
				}*/

				// 5.1
				/*Console.Write("Введите возраст: ");
				int k = Convert.ToInt32(Console.ReadLine());
				if (k <= 0 || k > 99) throw new Exception("Ошибка");
				Goda(k);*/

				// 5.2
				/*Console.Write("Введите день: ");
				int day = Convert.ToInt32(Console.ReadLine());
				if (day <= 0 || day > 31) throw new Exception("Ошибка ввода дня.");

				Console.Write("Введите месяц: ");
				int mounth = Convert.ToInt32(Console.ReadLine());
				if (mounth <= 0 || mounth > 12) throw new Exception("Ошибка ввода месяца.");

				Date(day, mounth);*/
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.ReadKey();
				Environment.Exit(0);
			}

			Console.ReadKey();
		}
	}
}