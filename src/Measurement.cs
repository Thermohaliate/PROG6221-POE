using System;
using System.Collections.Generic;

namespace POE;

/// <summary>
/// Class to store and handle a measurement.
/// </summary>
internal class Measurement {
	// constant fields ------------------------------------------------------ //
	private readonly Dictionary<UnitType, string> _symbols = new() {
		{UnitType.Teaspoon, "tsp"},
		{UnitType.Tablespoon, "tbsp"},
		{UnitType.Cup, "cup"}
	};

	// fields --------------------------------------------------------------- //
	private UnitType _unit;
	private double _quantity;

	// constructors --------------------------------------------------------- //
	internal Measurement(double quantity, UnitType unit) {
		this._quantity = quantity;
		this._unit = unit;

		this.Normalise();
	}

	// enums ---------------------------------------------------------------- //
	/// <summary>
	/// Different types of measurement units.
	/// </summary>
	internal enum UnitType {
		Teaspoon,
		Tablespoon,
		Cup,
		Custom
	}

	// properties ----------------------------------------------------------- //
	internal double Quantity {
		get => this._quantity;
		set => this._quantity = value;
	}
	
	internal UnitType Unit {
		get => this._unit;
		set => this._unit = value;
	}

	// methods -------------------------------------------------------------- //
	/// <summary>
	/// Normalise the values by converting it to a smaller if necessary.
	/// </summary>
	private void Normalise() {
		switch (this._unit) {
			case UnitType.Teaspoon:
				if (this._quantity >= 3) {
					this._quantity /= 3;
					this._unit = UnitType.Tablespoon;
				}

				break;
			case UnitType.Tablespoon:
				if (this._quantity < 1) {
					this._quantity *= 3;
					this._unit = UnitType.Teaspoon;
				} else if (this._quantity >= 16) {
					this._quantity /= 16;
					this._unit = UnitType.Cup;
				}

				break;
			case UnitType.Cup:
				if (this._quantity < 1) {
					this._quantity *= 16;
					this._unit = UnitType.Tablespoon;
				}

				break;
		}
	}
	
	/// <summary>
	/// Scale the measurement by the given factor.
	/// </summary>
	/// <param name="factor"></param>
	internal void Scale(double factor) {
		this._quantity *= factor;

		this.Normalise();
	}
	
	public override string ToString() {
		switch (this._unit) {
			case UnitType.Teaspoon:
				return $"({this._quantity} {this._symbols[this._unit]})";
			case UnitType.Custom:
				return $"({this._quantity.ToString()})";
		}
		
		if (this._quantity >= 1 && this._quantity % 1 == 0) {
			return $"({this._quantity} {this._symbols[this._unit]})";
		}
		
		string output = $"({Math.Floor(this._quantity)} " +
			$"{this._symbols[this._unit]}, ";
		double value = this._quantity;
		UnitType unit = this._unit;

		while (unit is not UnitType.Teaspoon) {
			unit = (UnitType) ((int) unit - 1);
			value %= 1;

			switch (unit) {
				case UnitType.Tablespoon:
					value = Math.Round(value * 16, 1);
					output += $"{Math.Floor(value)} {this._symbols[unit]}, ";

					break;
				case UnitType.Teaspoon:
					value = Math.Round(value * 3, 1);
					output += $"{value} {this._symbols[unit]}, ";

					break;
			}
		}

		return $"{output[..^2]})";
	}
}
