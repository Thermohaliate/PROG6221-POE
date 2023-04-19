using System.Collections.Generic;

namespace POE {
	internal class Recipe {
		// private variables ----------------------------------------------- //
		private readonly List<Ingredient> ingredients;
		private readonly List<Step> steps;

		// internal constructors ------------------------------------------- //
		internal Recipe() {
			this.ingredients = new List<Ingredient>();
			this.steps = new List<Step>();
		}

		// private methods ------------------------------------------------- //
		private string CreateTitle(string title) {
			string output = "--- " + title + " ";

			while (output.Length < 50) {
				output += "-";
			}

			return output;
		}

		// internal methods ------------------------------------------------ //
		internal void AddIngredient(Ingredient ingredient) {
			this.ingredients.Add(ingredient);
		}

		internal void AddStep(Step step) {
			this.steps.Add(step);
		}

		internal void Clear() {
			this.ingredients.Clear();
			this.steps.Clear();
		}

		internal void Reset() {
			foreach (Ingredient ingredient in this.ingredients) {
				ingredient.Reset();
			}
		}

		internal void Scale(double scale) {
			foreach (Ingredient ingredient in this.ingredients) {
				ingredient.Quantity *= scale;
			}
		}

		// public methods -------------------------------------------------- //
		public override string ToString() {
			string seperator = "=============================================";
			string output = seperator + "\n";

			output += this.CreateTitle(
				"Ingredients (" + this.ingredients.Count + ")"
			) + "\n";

			foreach (Ingredient ingredient in this.ingredients) {
				output += ingredient.ToString() + "\n";
			}

			output += this.CreateTitle(
				"Steps (" + this.steps.Count + ")"
			) + "\n";

			foreach (Step step in this.steps) {
				output += step.ToString() + "\n";
			}

			output += seperator;

			return output;
		}
	}
}
