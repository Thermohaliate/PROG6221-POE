using System;

namespace POE {
	internal class Step {
		// public variables ---------------------------------------------------------------------------------------- //
		public readonly string title;
		public readonly string description;

		// constructors -------------------------------------------------------------------------------------------- //
		public Step(string title, string description) {
			this.title = title;
			this.description = description;
		}

		// public methods ------------------------------------------------------------------------------------------ //
		public override string ToString() {
			string description = this.description;
			string new_line = this.description;
			int index = 0;

			Console.WriteLine(Math.Floor((double) description.Length / 85));
			
			while (new_line.Length > 85) {
				index += 85;

				while (description[index] != ' ') {
					index--;
				}

				description = (
					description.Substring(0, index) + 
					"\n" +
					description.Substring(index + 1, (description.Length - index) - 1)
				);

				new_line = description.Substring(index + 1, (description.Length - index) - 1);
			}

			return this.title + ":\n" + description;
		}
	}
}
