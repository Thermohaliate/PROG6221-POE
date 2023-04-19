namespace POE {
	internal class Step {
		// private variables ----------------------------------------------- //
		private readonly string title;
		private readonly string description;

		// internal constructors ------------------------------------------- //
		internal Step(string title, string description) {
			this.title = title;
			this.description = description;
		}

		// internal properties --------------------------------------------- //
		internal string Title {
			get {
				return this.title;
			}
		}

		internal string Description {
			get {
				return this.description;
			}
		}

		// public methods -------------------------------------------------- //
		public override string ToString() {
			string description = this.description;
			string newLine = this.description;
			int index = 0;

			while (newLine.Length > 50) {
				index += 50;

				while (description[index] != ' ') {
					index--;
				}

				description = (
					description.Substring(0, index) +
					"\n" +
					description.Substring(
						index + 1, (description.Length - index) - 1
					)
				);

				newLine = description.Substring(
					index + 1, (description.Length - index) - 1
				);
			}

			return this.title + ":\n" + description;
		}
	}
}
