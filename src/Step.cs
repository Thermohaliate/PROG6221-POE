namespace POE;

/// <summary>
/// Class to store and handle a step.
/// </summary>
internal class Step {
	// fields --------------------------------------------------------------- //
	private readonly string _title;
	private readonly string _description;

	// constructors --------------------------------------------------------- //
	internal Step(string title, string description) {
		this._title = title;
		this._description = description;
	}

	// methods -------------------------------------------------------------- //
	public override string ToString() {
		string description = this._description;
		string line = this._description;
		int index = 0;

		while (line.Length > 38) {
			index += 38;

			while (description[index] != ' ') {
				index--;
			}

			description = string.Concat(
				description[..index],
				"\n",
				description.Substring(
					index + 1,
					(description.Length - index) - 1
				)
			);

			line = description.Substring(
				index + 1,
				(description.Length - index) - 1
			);
		}

		return $"{this._title}:\n{description}";
	}
}
