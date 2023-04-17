﻿using System;
using System.Text.RegularExpressions;

namespace POE {
	internal class Program {
		// main method --------------------------------------------------------------------------------------------- //
		static void Main() {
			MainMenu();
		}

		// private methods ----------------------------------------------------------------------------------------- //
		private static void MainMenu() {
			Recipe recipe = new Recipe();

			Console.ForegroundColor = ConsoleColor.White;

			while (true) {
				Console.Clear();
				Console.WriteLine("Enter the number of the selected option:");
				Console.WriteLine("1. Add ingredient");
				Console.WriteLine("2. Add step");
				Console.WriteLine("3. Scale recipe");
				Console.WriteLine("4. Reset recipe");
				Console.WriteLine("5. Show recipe");
				Console.WriteLine("6. Exit");
				Console.Write("> ");


				string input = Console.ReadLine();

				if (!int.TryParse(input, out int choice)) {
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Invalid option");

					Console.ForegroundColor = ConsoleColor.White;

					System.Threading.Thread.Sleep(1000);

					continue;
				}

				switch (choice) {
					case 1:
						AddIngredientMenu(recipe);

						break;
					case 2:
						AddStepMenu(recipe);

						break;
					case 3:
						ScaleMenu(recipe);

						break;
					case 4:
						recipe.Reset();

						Console.ForegroundColor = ConsoleColor.Green;

						Console.WriteLine("Recipe reset");

						Console.ForegroundColor = ConsoleColor.White;

						System.Threading.Thread.Sleep(1000);

						break;
					case 5:
						Console.Clear();
						Console.WriteLine(recipe.ToString());
						Console.WriteLine("Press any key to continue...");
						Console.ReadLine();

						break;
					case 6:
						Environment.Exit(0);

						break;
					default:
						Console.ForegroundColor = ConsoleColor.Red;

						Console.WriteLine("Invalid option");

						Console.ForegroundColor = ConsoleColor.White;

						System.Threading.Thread.Sleep(1000);

						break;
				}
			}
		}

		private static void AddIngredientMenu(Recipe recipe) {
			string name = default;
			double quantity = default;
			string measurement;

			while (true) {
				string input;

				Console.Clear();

				if (name == default) {
					Console.Write("Ingredient name: ");

					input = Console.ReadLine();

					if (!Regex.IsMatch(input, @"[a-zA-z]")) {
						Console.ForegroundColor = ConsoleColor.Red;

						Console.WriteLine("Invalid input");

						Console.ForegroundColor = ConsoleColor.White;

						System.Threading.Thread.Sleep(1000);

						continue;
					}

					name = input;
				} else {
					Console.WriteLine("Ingredient name: " + name);
				}

				if (quantity == default) {
					Console.Write("Quantity: ");

					input = Console.ReadLine();

					if (!double.TryParse(input, out quantity)) {
						Console.ForegroundColor = ConsoleColor.Red;

						Console.WriteLine("Invalid input");

						Console.ForegroundColor = ConsoleColor.White;

						System.Threading.Thread.Sleep(1000);

						continue;
					}
				} else {
					Console.WriteLine("Quantity: " + quantity);
				}

				Console.Write("Measurement: ");

				input = Console.ReadLine();

				if (!Regex.IsMatch(input, @"[a-zA-z]")) {
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Invalid input");

					Console.ForegroundColor = ConsoleColor.White;

					System.Threading.Thread.Sleep(1000);

					continue;
				}

				measurement = input;

				break;
			}

			recipe.AddIngredient(new Ingredient(name, quantity, measurement));
		}

		private static void AddStepMenu(Recipe recipe) {
			string title = default;
			string description;

			while (true) {
				string input;

				Console.Clear();

				if (title == default) {
					Console.Write("Step title: ");

					input = Console.ReadLine();

					if (!Regex.IsMatch(input, @"[a-zA-z]")) {
						Console.ForegroundColor = ConsoleColor.Red;

						Console.WriteLine("Invalid input");

						Console.ForegroundColor = ConsoleColor.White;

						System.Threading.Thread.Sleep(1000);

						continue;
					}

					title = input;
				} else {
					Console.WriteLine("Step title: " + title);
				}

				Console.Write("Step description: ");

				input = Console.ReadLine();

				if (!Regex.IsMatch(input, @"[a-zA-z]")) {
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Invalid input");

					Console.ForegroundColor = ConsoleColor.White;

					System.Threading.Thread.Sleep(1000);

					continue;
				}

				description = input;

				break;
			}

			recipe.AddStep(new Step(title, description));
		}

		private static void ScaleMenu(Recipe recipe) {
			while (true) {
				Console.Clear();
				Console.Write("Scale factor: ");

				string input = Console.ReadLine();

				if (!double.TryParse(input, out double scale)) {
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Invalid input");

					Console.ForegroundColor = ConsoleColor.White;

					System.Threading.Thread.Sleep(1000);

					continue;
				}

				recipe.Scale(scale);

				break;
			}
		}
	}
}
