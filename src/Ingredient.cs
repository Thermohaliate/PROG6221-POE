namespace POE {
	internal class Ingredient {
		// private variables ----------------------------------------------- //
		private readonly string name;
		private double quantity;
		private readonly double originalQuantity;
		private readonly string measurement;

		// internal constructors ------------------------------------------- //
		internal Ingredient(string name, double quantity) {
			this.name = name;
			this.quantity = quantity;
			this.originalQuantity = quantity;
			this.measurement = "";
		}

		internal Ingredient(string name, double quantity, string measurement) {
			this.name = name;
			this.quantity = quantity;
			this.originalQuantity = quantity;
			this.measurement = measurement;
		}

		// internal properties --------------------------------------------- //
		internal string Measurement {
			get {
				return this.measurement;
			}
		}

		internal string Name {
			get {
				return this.name;
			}
		}

		internal double Quantity {
			get {
				return this.quantity;
			}
			set {
				this.quantity = value;
			}
		}

		// internal methods ------------------------------------------------ //
		internal void Reset() {
			this.quantity = this.originalQuantity;
		}

		// public methods -------------------------------------------------- //
		public override string ToString() {
			if (this.measurement == "") {
				return this.name + " (" + this.quantity + ")";
			} else {
				return this.name + " (" + this.quantity + " " + this.measurement + ")";
			}
		}
	}
}
