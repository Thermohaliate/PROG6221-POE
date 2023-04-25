namespace POE {
	internal class Ingredient {
		private readonly string name;
		private Measurements measurement;
		private readonly Measurements originalMeasurement;

		internal Ingredient(string name, double quantity) {
			this.name = name;
			this.measurement = Measurements.Custom(quantity);
			this.originalMeasurement = Measurements.Custom(quantity);
		}

		internal Ingredient(
			string name, double quantity, Measurements.Unit measurement
		) {
			this.name = name;
			this.measurement = new Measurements(quantity, measurement);
			this.originalMeasurement = new Measurements(quantity, measurement);
		}

		internal string Measurement {
			get {
				return this.measurement.unit.ToString();
			}
		}

		internal string Name {
			get {
				return this.name;
			}
		}

		internal double Quantity {
			get {
				return this.measurement.value;
			}
		}

		internal void Reset() {
			this.measurement = this.originalMeasurement;
		}

		internal void Scale(double scale) {
			this.measurement.Scale(scale);
		}

		public override string ToString() {
			return string.Format(
				"{0} ({1})",
				this.name,
				this.measurement.ToString()
			);
		}
	}
}
