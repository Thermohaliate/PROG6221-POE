using System;

namespace POE;

/// <summary>
/// Class to store and handle an ingredient.
/// </summary>
public class Ingredient {
	// fields --------------------------------------------------------------- //
	private readonly string _name;
	private readonly Measurement _measurement;
	private readonly Measurement _originalMeasurement;
	private readonly int _originalCalories;
	private readonly FoodGroup _foodGroup;
	private int _calories;

	// constructors --------------------------------------------------------- //
	internal Ingredient(
		string name,
		Measurement measurement,
		int calories,
		FoodGroup foodGroup
	) {
		this._name = name;
		this._measurement = measurement;
		this._originalMeasurement = new Measurement(
			measurement.Quantity,
			measurement.Unit
		);
		this._calories = calories;
		this._originalCalories = calories;
		this._foodGroup = foodGroup;
	}

	// enums ---------------------------------------------------------------- //
	internal enum FoodGroup {
		Carbohydrate,
		Fibre,
		Fat,
		Mineral,
		Protein,
		Vitamin,
		Water
	}

	// properties ----------------------------------------------------------- //
	internal int Calories =>
		(int) Math.Round(this._calories * this._measurement.Quantity);

	internal FoodGroup Group => this._foodGroup;
	
	internal string Name => this._name;

	// methods -------------------------------------------------------------- //
	/// <summary>
	/// Reset the ingredient to its original measurement.
	/// </summary>
	internal void Reset() {
		this._measurement.Quantity = this._originalMeasurement.Quantity;
		this._measurement.Unit = this._originalMeasurement.Unit;
		this._calories = this._originalCalories;
	}

	/// <summary>
	/// Scale the ingredient by the given factor.
	/// </summary>
	/// <param name="factor"></param>
	internal void Scale(double factor) {
		this._measurement.Scale(factor);

		if (this._measurement.Unit != this._originalMeasurement.Unit) {
			switch (this._originalMeasurement.Unit) {
				case Measurement.UnitType.Cup:
					switch (this._measurement.Unit) {
						case Measurement.UnitType.Tablespoon:
							this._calories = (int) Math.Round(
								(double) this._originalCalories / 16
							);

							break;
						case Measurement.UnitType.Teaspoon:
							this._calories = (int) Math.Round(
								(double) this._originalCalories / 48
							);

							break;
					}

					break;
				case Measurement.UnitType.Tablespoon:
					switch (this._measurement.Unit) {
						case Measurement.UnitType.Cup:
							this._calories = (int) Math.Round(
								(double) this._originalCalories * 16
							);

							break;
						case Measurement.UnitType.Teaspoon:
							this._calories = (int) Math.Round(
								(double) this._originalCalories / 3
							);

							break;
					}

					break;
				case Measurement.UnitType.Teaspoon:
					switch (this._measurement.Unit) {
						case Measurement.UnitType.Cup:
							this._calories = (int) Math.Round(
								(double) this._originalCalories * 16
							);

							break;
						case Measurement.UnitType.Tablespoon:
							this._calories = (int) Math.Round(
								(double) this._originalCalories * 3
							);

							break;
					}

					break;
			}
		}
	}

	public override string ToString() {
		return $"{this._name} {this._measurement} ({this._foodGroup})";
	}
}
