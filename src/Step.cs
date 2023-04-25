namespace POE {
	internal class Step {
		private readonly string title;
		private readonly string description;

		internal Step(string title, string description) {
			this.title = title;
			this.description = description;
		}

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

		public override string ToString() {
			string description = this.description;
			string newLine = this.description;
			int index = 0;

			while (newLine.Length > 50) {
				index += 50;

				while (description[index] != ' ') {
					index--;
				}

				description = string.Concat(
					description[..index],
					"\n",
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
