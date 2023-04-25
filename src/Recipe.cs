using System.Collections.Generic;

namespace POE {
	internal class Recipe {
		private readonly List<Ingredient> ingredients;
		private readonly List<Step> steps;

		internal Recipe() {
			this.ingredients = new List<Ingredient>();
			this.steps = new List<Step>();
		}

		private static string CreateTitle(string title) {
			string output = "--- " + title + " ";

			while (output.Length < 45) {
				output += "-";
			}

			return output;
		}

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
				//ingredient.Quantity *= scale;
				ingredient.Scale(scale);
			}
		}

		public override string ToString() {
			string seperator = "=============================================";
			string output = seperator + "\n";

			output += CreateTitle(
				"Ingredients (" + this.ingredients.Count + ")"
			) + "\n";

			foreach (Ingredient ingredient in this.ingredients) {
				output += ingredient.ToString() + "\n";
			}

			output += CreateTitle("Steps (" + this.steps.Count + ")") + "\n";

			foreach (Step step in this.steps) {
				output += step.ToString() + "\n";
			}

			output += seperator;

			return output;
		}
	}
}
