using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace POE;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
	// fields --------------------------------------------------------------- //
	private readonly List<Recipe> _recipes;
	private Recipe _selectedRecipe;
	private Canvas _previousPage;

	// constructors --------------------------------------------------------- //
	public MainWindow() {
		this.InitializeComponent();

		this._recipes = new List<Recipe>();

		this.DataContext = this;
		this.RecipesListView.ItemsSource =
			this._recipes.Select(recipe => recipe.Name).ToList();
	}

	// events --------------------------------------------------------------- //
	private void AddIngredientPageAcceptButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		if (this.AddIngredientPageNameTextBox.Text == "") {
			MessageBox.Show(
				"Please enter a name for the ingredient.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (this.AddIngredientPageQuantityTextBox.Text == "") {
			MessageBox.Show(
				"Please enter a quantity for the ingredient.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (!double.TryParse(
				this.AddIngredientPageQuantityTextBox.Text,
				out _
			)) {
			MessageBox.Show(
				"Please enter a valid quantity for the ingredient.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (this.AddIngredientPageUnitComboBox.Text == "") {
			MessageBox.Show(
				"Please select a measurement for the ingredient.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (this.AddIngredientPageCaloriesTextBox.Text == "") {
			MessageBox.Show(
				"Please enter a calorie count for the ingredient.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (!double.TryParse(
				this.AddIngredientPageCaloriesTextBox.Text,
				out _
			)) {
			MessageBox.Show(
				"Please enter a valid calorie count for the ingredient.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (this.AddIngredientPageFoodGroupComboBox.Text == "") {
			MessageBox.Show(
				"Please select a food group for the ingredient.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		this._selectedRecipe.AddIngredient(
			new Ingredient(
				this.AddIngredientPageNameTextBox.Text,
				new Measurement(
					int.Parse(this.AddIngredientPageQuantityTextBox.Text),
					this.AddIngredientPageUnitComboBox.Text switch {
						"Teaspoon" => Measurement.UnitType.Teaspoon,
						"Tablespoon" => Measurement.UnitType.Tablespoon,
						"Cup" => Measurement.UnitType.Cup,
						"Custom" => Measurement.UnitType.Custom,
						_ => default
					}
				),
				int.Parse(this.AddIngredientPageCaloriesTextBox.Text),
				this.AddIngredientPageFoodGroupComboBox.Text switch {
					"Carbohydrate" => Ingredient.FoodGroup.Carbohydrate,
					"Fibre" => Ingredient.FoodGroup.Fibre,
					"Fat" => Ingredient.FoodGroup.Fat,
					"Mineral" => Ingredient.FoodGroup.Mineral,
					"Protein" => Ingredient.FoodGroup.Protein,
					"Vitamin" => Ingredient.FoodGroup.Vitamin,
					"Water" => Ingredient.FoodGroup.Water,
					_ => default
				}
			)
		);

		this.AddIngredientPageNameTextBox.Text = "";
		this.AddIngredientPageQuantityTextBox.Text = "";
		this.AddIngredientPageUnitComboBox.SelectedIndex = -1;
		this.AddIngredientPageCaloriesTextBox.Text = "";
		this.AddIngredientPageFoodGroupComboBox.SelectedIndex = -1;
		this.AddIngredientPage.Visibility = Visibility.Hidden;
		this._previousPage.Visibility = Visibility.Visible;
	}

	private void AddIngredientPageBackButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this.AddIngredientPageNameTextBox.Text = "";
		this.AddIngredientPageQuantityTextBox.Text = "";
		this.AddIngredientPageUnitComboBox.SelectedIndex = -1;
		this.AddIngredientPageCaloriesTextBox.Text = "";
		this.AddIngredientPageFoodGroupComboBox.SelectedIndex = -1;
		this.AddIngredientPage.Visibility = Visibility.Hidden;
		this._previousPage.Visibility = Visibility.Visible;
	}

	private void AddRecipePageAcceptButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		if (this.AddRecipePageNameTextBox.Text == "") {
			MessageBox.Show(
				"Please enter a name for the recipe.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		this._selectedRecipe = new Recipe(this.AddRecipePageNameTextBox.Text);
		this.AddRecipePageNameTextBox.Text = "";
		this.AddRecipePage.Visibility = Visibility.Hidden;
		this.EditRecipePage.Visibility = Visibility.Visible;
	}

	private void AddRecipePageBackButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this.AddRecipePageNameTextBox.Text = "";
		this.AddRecipePage.Visibility = Visibility.Hidden;
		this.HomePage.Visibility = Visibility.Visible;
	}

	private void AddStepPageAcceptButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		if (this.AddStepPageTitleTextBox.Text == "") {
			MessageBox.Show(
				"Please enter a title for the step.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (this.AddStepPageDescriptionTextBox.Text == "") {
			MessageBox.Show(
				"Please enter a description for the step.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		this._selectedRecipe.AddStep(
			new Step(
				this.AddStepPageTitleTextBox.Text,
				this.AddStepPageDescriptionTextBox.Text
			)
		);

		this.AddStepPageTitleTextBox.Text = "";
		this.AddStepPageDescriptionTextBox.Text = "";
		this.AddStepPage.Visibility = Visibility.Hidden;
		this._previousPage.Visibility = Visibility.Visible;
	}

	private void AddStepPageBackButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this.AddStepPageTitleTextBox.Text = "";
		this.AddStepPageDescriptionTextBox.Text = "";
		this.AddStepPage.Visibility = Visibility.Hidden;
		this._previousPage.Visibility = Visibility.Visible;
	}

	private void EditRecipePageAcceptButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		if (this._selectedRecipe.Ingredients.Count == 0) {
			MessageBox.Show(
				"Please add at least one ingredient to the recipe.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (this._selectedRecipe.Steps.Count == 0) {
			MessageBox.Show(
				"Please add at least one step to the recipe.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		this._recipes.Add(this._selectedRecipe);

		List<string> names =
			this._recipes.Select(recipe => recipe.Name).ToList();

		names.Sort();

		this.RecipesListView.ItemsSource = names;

		this.EditRecipePage.Visibility = Visibility.Hidden;
		this.HomePage.Visibility = Visibility.Visible;
	}

	private void EditRecipePageAddIngredientButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this._previousPage = this.EditRecipePage;

		this.EditRecipePage.Visibility = Visibility.Hidden;
		this.AddIngredientPage.Visibility = Visibility.Visible;
	}

	private void EditRecipePageAddStepButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this._previousPage = this.EditRecipePage;

		this.EditRecipePage.Visibility = Visibility.Hidden;
		this.AddStepPage.Visibility = Visibility.Visible;
	}


	private void HomePageAddRecipeButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this.HomePage.Visibility = Visibility.Hidden;
		this.AddRecipePage.Visibility = Visibility.Visible;
	}

	private void HomePageClearButton_OnClick(object sender, RoutedEventArgs e) {
		this.HomePageFoodGroupComboBox.SelectedIndex = -1;

		List<string> names =
			this._recipes.Select(recipe => recipe.Name).ToList();

		names.Sort();

		this.RecipesListView.ItemsSource = names;
	}

	private void HomePageViewRecipeButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		try {
			this._selectedRecipe = this._recipes[
				this.RecipesListView.SelectedIndex
			];

			this.HomePage.Visibility = Visibility.Hidden;
			this.ViewRecipePage.Visibility = Visibility.Visible;
		} catch (ArgumentOutOfRangeException) {
			MessageBox.Show(
				"Please select a recipe to view.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);
		}
	}

	private void HomePageFilterButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		List<string> names = new();

		Ingredient.FoodGroup foodGroup =
			this.HomePageFoodGroupComboBox.Text switch {
				"Carbohydrate" => Ingredient.FoodGroup.Carbohydrate,
				"Fibre" => Ingredient.FoodGroup.Fibre,
				"Fat" => Ingredient.FoodGroup.Fat,
				"Mineral" => Ingredient.FoodGroup.Mineral,
				"Protein" => Ingredient.FoodGroup.Protein,
				"Vitamin" => Ingredient.FoodGroup.Vitamin,
				"Water" => Ingredient.FoodGroup.Water,
				_ => default
			};

		foreach (
			Recipe recipe in this._recipes
		) {
			foreach (Ingredient ingredient in recipe.Ingredients) {
				if (ingredient.Group == foodGroup) {
					names.Add(recipe.Name);

					break;
				}
			}
		}

		names.Sort();

		this.RecipesListView.ItemsSource = names;
	}
	
	private void ScaleRecipePageAcceptButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		if (this.ScaleRecipePageScaleTextBox.Text == "") {
			MessageBox.Show(
				"Please enter a scale factor.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		if (!double.TryParse(
				this.ScaleRecipePageScaleTextBox.Text,
				out double scale
			)) {
			MessageBox.Show(
				"Please enter a valid scale factor.",
				"Error",
				MessageBoxButton.OK,
				MessageBoxImage.Error
			);

			return;
		}

		this._selectedRecipe.Scale(scale);
		this.ScaleRecipePageScaleTextBox.Text = "";
		this.ScaleRecipePage.Visibility = Visibility.Hidden;
		this.ViewRecipePage.Visibility = Visibility.Visible;
	}

	private void ViewRecipePageAddIngredientButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this._previousPage = this.ViewRecipePage;

		this.ViewRecipePage.Visibility = Visibility.Hidden;
		this.AddIngredientPage.Visibility = Visibility.Visible;
	}

	private void ViewRecipePageAddStepButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this._previousPage = this.ViewRecipePage;

		this.ViewRecipePage.Visibility = Visibility.Hidden;
		this.AddStepPage.Visibility = Visibility.Visible;
	}

	private void ViewRecipePageAcceptButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this.ViewRecipePage.Visibility = Visibility.Hidden;
		this.HomePage.Visibility = Visibility.Visible;
	}

	private void ViewRecipePageClearRecipeButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this._selectedRecipe.Clear();

		MessageBox.Show(
			"Recipe cleared.",
			"Recipe",
			MessageBoxButton.OK,
			MessageBoxImage.Information
		);
	}

	private void ViewRecipePageResetRecipeButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this._selectedRecipe.Reset();

		MessageBox.Show(
			"Recipe reset.",
			"Recipe",
			MessageBoxButton.OK,
			MessageBoxImage.Information
		);
	}

	private void ViewRecipePageViewRecipeButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		MessageBox.Show(
			this._selectedRecipe.ToString(),
			"Recipe",
			MessageBoxButton.OK,
			MessageBoxImage.Information
		);
	}

	private void ViewRecipePageScaleRecipeButton_OnClick(
		object sender,
		RoutedEventArgs e
	) {
		this.ViewRecipePage.Visibility = Visibility.Hidden;
		this.ScaleRecipePage.Visibility = Visibility.Visible;
	}
}
