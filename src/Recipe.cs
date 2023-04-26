using System.Collections.Generic;

namespace POE;

public class Recipe {
	// fields --------------------------------------------------------------- //
	private readonly List<Ingredient> _ingredients;
	private readonly List<Step> _steps;
	
	// constructors --------------------------------------------------------- //
	internal Recipe() {
		this._ingredients = new List<Ingredient>();
		this._steps = new List<Step>();
	}
	
	// methods -------------------------------------------------------------- //
	private static string CreateTitle(string text) {
		string output = $"--- {text} ";
		
		return $"{output} {new string('-', 80 - (output.Length + 1))}\n";
	}
	
	internal void AddIngredient(Ingredient ingredient) {
		this._ingredients.Add(ingredient);
	}

	internal void AddStep(Step step) {
		this._steps.Add(step);
	}
	
	internal void Clear() {
		this._ingredients.Clear();
		this._steps.Clear();
	}
	
	internal void Reset() {
		foreach (Ingredient ingredient in this._ingredients) {
			ingredient.Reset();
		}
	}
	
	internal void Scale(double factor) {
		foreach (Ingredient ingredient in this._ingredients) {
			ingredient.Scale(factor);
		}
	}
	
	public override string ToString() {
		string border = $"{new string('=', 80)}\n";
		string output = border;
		
		output += CreateTitle($"Ingredients ({this._ingredients.Count})");
		
		foreach (Ingredient ingredient in this._ingredients) {
			output += $"{ingredient} \n";
		}

		output += CreateTitle($"Steps ({this._steps.Count})");
		
		foreach (Step step in this._steps) {
			output += $"{step} \n";
		}
		
		output += border;

		return output;
	}
}
