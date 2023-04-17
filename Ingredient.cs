namespace POE {
	internal class Ingredient {
		// private variables --------------------------------------------------------------------------------------- //
		private readonly string name;
		private double quantity;
		private readonly double originalQuantity;
		private readonly string measurement;

		// constructors -------------------------------------------------------------------------------------------- //
		public Ingredient(string name, double quantity) {
			this.name = name;
			this.quantity = quantity;
			this.originalQuantity = quantity;
			this.measurement = "";
		}

		public Ingredient(string name, double quantity, string measurement) {
			this.name = name;
			this.quantity = quantity;
			this.originalQuantity = quantity;
			this.measurement = measurement;
		}

		// public properties --------------------------------------------------------------------------------------- //
		public string Measurement {
			get {
				return this.measurement;
			}	
		}
		
		public string Name {
			get {
				return this.name;
			}
		}

		public double Quantity {
			get {
				return this.quantity;
			}
			set {
				this.quantity = value;
			}
		}

		// public methods ------------------------------------------------------------------------------------------ //
		public void Reset() {
			this.quantity = this.originalQuantity;
		}

		public override string ToString() {
			if (this.measurement == "") {
				return this.name + " (" + this.quantity + ")";
			} else {
				return this.name + " (" + this.quantity + " " + this.measurement + ")";
			}
		}
	}
}
