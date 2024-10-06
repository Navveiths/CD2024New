using System.Text.RegularExpressions;

public class NummerMarkerare
{
	public static void HittaOchMarkeraNummer()
	{
		long helsum = 0;

		Console.WriteLine("Mata in nummer");
		string input = Console.ReadLine();


		var nummersresultat = new List<string>();


		var regex = new Regex(@"\d+");
		var matches = regex.Matches(input);


		foreach (Match match in matches)
		{
			string strengsnummer = match.Value;

			for (int start = 0; start < strengsnummer.Length - 1; start++)
			{
				for (int end = start + 1; end < strengsnummer.Length; end++)
				{
					var substring = strengsnummer.Substring(start, end - start + 1);

					if (IsValidNumber(substring))
					{
						nummersresultat.Add(substring);
						if (long.TryParse(substring, out long number))
						{
							helsum += number;
						}
					}
				}
			}
		}


		foreach (var number in nummersresultat)
		{
			PrintHighlightedNumber(input, number);
		}


		Console.WriteLine("\nTotal = " + helsum);
	}

	private static bool IsValidNumber(string numberString)
	{

		if (numberString.Length < 2 || numberString[0] != numberString[^1])
			return false;

		char liknandenummer = numberString[0];


		for (int i = 1; i < numberString.Length - 1; i++)
		{
			if (numberString[i] == liknandenummer)
			{
				return false;
			}
		}

		return true;
	}

	private static void PrintHighlightedNumber(string input, string numberString)
	{
		int placeradnummer = input.IndexOf(numberString);
		while (placeradnummer >= 0)
		{
			Console.Write(input[..placeradnummer]);
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Write(numberString);
			Console.ResetColor();
			Console.WriteLine(input[(placeradnummer + numberString.Length)..]);


			placeradnummer = input.IndexOf(numberString, placeradnummer + numberString.Length);
		}
	}
}

class Program
{
	static void Main()
	{
		NummerMarkerare.HittaOchMarkeraNummer();
	}
}
