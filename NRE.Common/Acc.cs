using System;

namespace NRE.Common {

	public static class Acc {

		public static long Max { get; private set; }

		public static void Update( long value ) {
			Max = Math.Max( Max, value );
		}

	}
}
