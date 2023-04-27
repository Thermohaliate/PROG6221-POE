namespace POE;

/// <summary>
/// Class to store and handle an ingredient.
/// </summary>
public class Ingredient {
	// fields --------------------------------------------------------------- //
	private readonly string _name;
	private readonly Measurement _measurement;
	private readonly Measurement _originalMeasurement;

	// constructors --------------------------------------------------------- //
	internal Ingredient(string name, Measurement measurement) {
		this._name = name;
		this._measurement = measurement;
		this._originalMeasurement = new(measurement.Quantity, measurement.Unit);
	}

	// methods -------------------------------------------------------------- //
	/// <summary>
	/// Reset the ingredient to its original measurement.
	/// </summary>
	internal void Reset() {
		this._measurement.Quantity = this._originalMeasurement.Quantity;
		this._measurement.Unit = this._originalMeasurement.Unit;
	}

	/// <summary>
	/// Scale the ingredient by the given factor.
	/// </summary>
	/// <param name="factor"></param>
	internal void Scale(double factor) {
		this._measurement.Scale(factor);
	}
	
	public override string ToString() {
		return $"{this._name} {this._measurement}";
	}
}
