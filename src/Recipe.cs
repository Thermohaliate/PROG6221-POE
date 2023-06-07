using System.Collections.Generic;
using System.Linq;

namespace POE;

/// <summary>
/// Class to store and handle a recipe.
/// </summary>
public class Recipe {
	// fields --------------------------------------------------------------- //
	private readonly string _name;
	private readonly List<Ingredient> _ingredients;
	private readonly List<Step> _steps;

	// constructors --------------------------------------------------------- //
	internal Recipe(string name) {
		this._name = name;
		this._ingredients = new List<Ingredient>();
		this._steps = new List<Step>();
	}

	// properties ----------------------------------------------------------- //
	internal int Calories =>
		this._ingredients.Sum(ingredient => ingredient.Calories);

	internal List<Ingredient> Ingredients => this._ingredients;

	internal string Name => this._name;

	internal List<Step> Steps => this._steps;

	// methods -------------------------------------------------------------- //
	/// <summary>
	/// Creates a title with the text provided.
	/// </summary>
	/// <param name="text"></param>
	/// <returns>Title text</returns>
	private static string CreateTitle(string text) {
		string output = $"--- {text} ";

		return $"{output} {new string('-', 80 - (output.Length + 1))}\n";
	}

	/// <summary>
	/// Add an ingredient to the recipe.
	/// </summary>
	/// <param name="ingredient"></param>
	internal void AddIngredient(Ingredient ingredient) {
		this._ingredients.Add(ingredient);
	}

	/// <summary>
	/// Add a step to the recipe.
	/// </summary>
	/// <param name="step"></param>
	internal void AddStep(Step step) {
		this._steps.Add(step);
	}

	/// <summary>
	/// Clear the contents of the recipe.
	/// </summary>
	internal void Clear() {
		this._ingredients.Clear();
		this._steps.Clear();
	}

	/// <summary>
	/// Reset the ingredients to their original measurements.
	/// </summary>
	internal void Reset() {
		foreach (Ingredient ingredient in this._ingredients) {
			ingredient.Reset();
		}
	}

	/// <summary>
	/// Scale the recipe ingredients by the given factor.
	/// </summary>
	/// <param name="factor"></param>
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
			output += $"{ingredient}\n";
		}

		output += CreateTitle($"Steps ({this._steps.Count})");

		foreach (Step step in this._steps) {
			output += $"{step}\n";
		}

		output += CreateTitle(
			$"Calories ({this._ingredients.Sum(ingredient => ingredient.Calories)})"
		);

		foreach (Ingredient ingredient in this._ingredients) {
			output += $"{ingredient.Name}: {ingredient.Calories}\n";
		}

		output += border;

		return output;
	}
}
