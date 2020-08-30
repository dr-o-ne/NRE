using System;
using NRE.Common;
using NRules.Fluent.Dsl;

namespace NRE.NRules.Rules {

	public class MaxRule : Rule {

		public override void Define() {
			Node entity = null;

			When()
				.Match( () => entity, x => x.Frequency.HasValue );

			Then()
				.Do( ctx => Log( entity ) );
		}

		private static void Log( Node entity ) {
			if( entity.Frequency == Acc.Max )
				Console.WriteLine( entity );
		}

	}

}
