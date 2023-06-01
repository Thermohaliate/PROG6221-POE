using System;
using System.Threading;
using System.Text.RegularExpressions;

namespace POE;

internal static class Program {
	// main method ---------------------------------------------------------- //
	private static void Main() {
		Recipe recipe = new();

		MainMenu(recipe);
	}

	// methods -------------------------------------------------------------- //
	/// <summary>
	/// Open the add ingredient menu.
	/// </summary>
	/// <param name="recipe"></param>
	private static void AddIngredientMenu(Recipe recipe) {
		string name = default;
		bool nameDone = false;
		double quantity = default;
		bool quantityDone = false;
		Measurement.UnitType unit;

		while (true) {
			string input;

			Console.Clear();

			if (!nameDone) {
				Console.Write("Ingredient: ");

				input = Console.ReadLine();

				if (!Regex.IsMatch(input!, @"[a-zA-z]")) {
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Invalid input");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					continue;
				}

				name = input;
				nameDone = true;
			} else {
				Console.WriteLine($"Ingredient: {name}");
			}

			if (!quantityDone) {
				Console.Write("Quantity: ");

				input = Console.ReadLine();

				if (!double.TryParse(input, out quantity)) {
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Invalid input");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					continue;
				}

				quantityDone = true;
			} else {
				Console.WriteLine($"Quantity: {quantity}");
			}

			Console.WriteLine("Measurement:");
			Console.WriteLine("1. Teaspoon");
			Console.WriteLine("2. Tablespoon");
			Console.WriteLine("3. Cup");
			Console.WriteLine("4. Custom");
			Console.Write("> ");

			ConsoleKeyInfo choice = Console.ReadKey();

			switch (choice.Key) {
				case ConsoleKey.D1 or ConsoleKey.NumPad1:
					unit = Measurement.UnitType.Teaspoon;

					break;
				case ConsoleKey.D2 or ConsoleKey.NumPad2:
					unit = Measurement.UnitType.Tablespoon;

					break;
				case ConsoleKey.D3 or ConsoleKey.NumPad3:
					unit = Measurement.UnitType.Cup;

					break;
				case ConsoleKey.D4 or ConsoleKey.NumPad4:
					unit = Measurement.UnitType.Custom;

					break;
				default:
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("\nInvalid option");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					continue;
			}

			break;
		}

		recipe.AddIngredient(new Ingredient(name, new Measurement(quantity, unit)));
	}

	/// <summary>
	/// Open the add step menu.
	/// </summary>
	/// <param name="recipe"></param>
	private static void AddStepMenu(Recipe recipe) {
		string title = default;
		bool titleDone = false;
		string description;

		while (true) {
			string input;

			Console.Clear();

			if (!titleDone) {
				Console.Write("Step title: ");

				input = Console.ReadLine();

				if (!Regex.IsMatch(input!, @"[a-zA-z]")) {
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Invalid input");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					continue;
				}

				title = input;
				titleDone = true;
			} else {
				Console.WriteLine("Step title: " + title);
			}

			Console.Write("Step description: ");

			input = Console.ReadLine();

			if (!Regex.IsMatch(input!, @"[a-zA-z]")) {
				Console.ForegroundColor = ConsoleColor.Red;

				Console.WriteLine("Invalid input");

				Console.ForegroundColor = ConsoleColor.White;

				Thread.Sleep(1000);

				continue;
			}

			description = input;

			break;
		}

		recipe.AddStep(new Step(title, description));
	}

	/// <summary>
	/// Open the clear menu.
	/// </summary>
	/// <param name="recipe"></param>
	private static void ClearMenu(Recipe recipe) {
		while (true) {
			Console.Clear();
			Console.Write(
				"Are you sure you want to clear the recipe? (Y/N)\n> "
			);

			ConsoleKeyInfo key = Console.ReadKey();

			switch (key.Key) {
				case ConsoleKey.Y:
					recipe.Clear();

					Console.ForegroundColor = ConsoleColor.Green;

					Console.WriteLine("\nRecipe cleared");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					return;
				case ConsoleKey.N:
					return;
				default:
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("\nInvalid input");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					continue;
			}
		}
	}

	/// <summary>
	/// Open the main menu.
	/// </summary>
	/// <param name="recipe"></param>
	private static void MainMenu(Recipe recipe) {
		while (true) {
			Console.Clear();
			Console.WriteLine("Enter the number of the selected option:");
			Console.WriteLine("1. Add ingredient");
			Console.WriteLine("2. Add step");
			Console.WriteLine("3. Scale recipe");
			Console.WriteLine("4. Show recipe");
			Console.WriteLine("5. Reset recipe");
			Console.WriteLine("6. Clear recipe");
			Console.WriteLine("7. Exit");
			Console.Write("> ");

			ConsoleKeyInfo input = Console.ReadKey();

			switch (input.Key) {
				case ConsoleKey.D1 or ConsoleKey.NumPad1:
					AddIngredientMenu(recipe);

					break;
				case ConsoleKey.D2 or ConsoleKey.NumPad2:
					AddStepMenu(recipe);

					break;
				case ConsoleKey.D3 or ConsoleKey.NumPad3:
					ScaleMenu(recipe);

					break;
				case ConsoleKey.D4 or ConsoleKey.NumPad4:
					Console.Clear();
					Console.WriteLine(recipe.ToString());
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();

					break;
				case ConsoleKey.D5 or ConsoleKey.NumPad5:
					recipe.Reset();

					Console.ForegroundColor = ConsoleColor.Green;

					Console.WriteLine("\nRecipe reset");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					break;
				case ConsoleKey.D6 or ConsoleKey.NumPad6:
					ClearMenu(recipe);

					break;
				case ConsoleKey.D7 or ConsoleKey.NumPad7:
					return;
				default:
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("\nInvalid option");

					Console.ForegroundColor = ConsoleColor.White;

					Thread.Sleep(1000);

					break;
			}
		}
	}

	/// <summary>
	/// Open the scale menu.
	/// </summary>
	/// <param name="recipe"></param>
	private static void ScaleMenu(Recipe recipe) {
		while (true) {
			Console.Clear();
			Console.Write("Scale factor: ");

			string input = Console.ReadLine();

			if (!double.TryParse(input, out double scale)) {
				Console.ForegroundColor = ConsoleColor.Red;

				Console.WriteLine("Invalid input");

				Console.ForegroundColor = ConsoleColor.White;

				Thread.Sleep(1000);

				continue;
			}

			recipe.Scale(scale);

			break;
		}
	}
}
