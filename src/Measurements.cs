using System;
using System.Collections.Generic;

namespace POE {
	internal class Measurements {
		internal enum Unit {
			Milligram,
			Gram,
			Kilogram,
			Ounce,
			Pound,
			Custom
		}

		internal double value;
		internal Unit unit;

		private readonly Dictionary<Unit, string> text = new() {
			{Unit.Milligram, "mg"},
			{Unit.Gram, "g"},
			{Unit.Kilogram, "kg"},
			{Unit.Ounce, "oz"},
			{Unit.Pound, "lb"}
		};

		internal Measurements(double value, Unit unit) {
			this.value = value;
			this.unit = unit;

			this.Normalise();
		}

		private void Normalise() {
			switch (this.unit) {
				case Unit.Milligram:
					if (this.value >= 1000) {
						this.value = Math.Floor(this.value / 1000);
						this.unit = Unit.Gram;
					}

					break;
				case Unit.Gram:
					if (this.value < 1) {
						this.value *= 1000;
						this.unit = Unit.Milligram;
					} else if (this.value > 1000) {
						this.value = Math.Floor(this.value / 1000);
						this.unit = Unit.Kilogram;
					}

					break;
				case Unit.Kilogram:
					if (this.value < 0.000001) {
						this.value *= 1000000;
						this.unit = Unit.Milligram;
					} else if (this.value < 0.001) {
						this.value *= 1000;
						this.unit = Unit.Gram;
					}

					break;
				case Unit.Ounce:
					if (this.value >= 16) {
						this.value = Math.Floor(this.value / 16);
						this.unit = Unit.Pound;
					}

					break;
				case Unit.Pound:
					if (this.value < 0.6) {
						this.value *= 16;
						this.unit = Unit.Ounce;
					}

					break;
			}
		}

		internal static Measurements Milligram(double value) {
			return new Measurements(value, Unit.Milligram);
		}

		internal static Measurements Gram(double value) {
			return new Measurements(value, Unit.Gram);
		}

		internal static Measurements Kilogram(double value) {
			return new Measurements(value, Unit.Kilogram);
		}

		internal static Measurements Ounce(double value) {
			return new Measurements(value, Unit.Ounce);
		}

		internal static Measurements Pound(double value) {
			return new Measurements(value, Unit.Pound);
		}

		internal static Measurements Custom(double value) {
			return new Measurements(value, Unit.Custom);
		}

		internal void Scale(double scale) {
			this.value *= scale;

			this.Normalise();
		}

		public override string ToString() {
			if (this.unit is Unit.Custom) {
				return this.value.ToString();
			} else {
				return this.value + " " + this.text[this.unit];
			}
		}
	}
}
