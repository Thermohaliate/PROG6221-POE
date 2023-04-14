namespace POE {
	internal class Ingredient {
		// public variables ---------------------------------------------------------------------------------------- //
		public readonly string name;
		public double quantity;
		public readonly string measurement;

		// constructors -------------------------------------------------------------------------------------------- //
		public Ingredient(string name, double quantity) {
			this.name = name;
			this.quantity = quantity;
			this.measurement = "";
		}

		public Ingredient(string name, double quantity, string measurement) {
			this.name = name;
			this.quantity = quantity;
			this.measurement = measurement;
		}

		// public methods ------------------------------------------------------------------------------------------ //
		public override string ToString() {
			if (this.measurement == "") {
				return this.name + " (" + this.quantity + ")";
			} else {
				return this.name + " (" + this.quantity + " " + this.measurement + ")";
			}
		}
	}
}
