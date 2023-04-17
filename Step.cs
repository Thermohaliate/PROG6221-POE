using System;

namespace POE {
	internal class Step {
		// private variables --------------------------------------------------------------------------------------- //
		private readonly string title;
		private readonly string description;

		// constructors -------------------------------------------------------------------------------------------- //
		public Step(string title, string description) {
			this.title = title;
			this.description = description;
		}

		// public properties --------------------------------------------------------------------------------------- //
		public string Title {
			get {
				return this.title;
			}
		}

		public string Description {
			get {
				return this.description;
			}
		}

		// public methods ------------------------------------------------------------------------------------------ //
		public override string ToString() {
			string description = this.description;
			string newLine = this.description;
			int index = 0;

			Console.WriteLine(Math.Floor((double) description.Length / 85));
			
			while (newLine.Length > 85) {
				index += 85;

				while (description[index] != ' ') {
					index--;
				}

				description = (
					description.Substring(0, index) + 
					"\n" +
					description.Substring(index + 1, (description.Length - index) - 1)
				);

				newLine = description.Substring(index + 1, (description.Length - index) - 1);
			}

			return this.title + ":\n" + description;
		}
	}
}
