namespace NRE.Common {

	public sealed class Node {

		public string Key { get; set; }

		public string Value { get; set; }

		public long? Frequency { get; set; }

		public override string ToString() {
			return Key + " " + Value;
		}

	}
}
