using System.Collections.Generic;
using System.Linq;
using NRE.Common;
using NRules.Fluent.Dsl;
using NRules.RuleModel;

namespace NRE.NRules.Rules {

	[Repeatability( RuleRepeatability.NonRepeatable )]
	public sealed class GroupRule : Rule {

		public override void Define() {

			Node entity = null;
			IEnumerable<Node> entities = null;
			long cnt = 0;

			When()
				.Match( () => entity )
				.Query( () => entities, x => x
					.Match<Node>( o => o.Value == entity.Value )
					.Collect()
				)
				.Let( () => cnt, () => entities.Count() );

			Then()
				.Do( ctx => UpdateAll( entities, cnt ) )
				.Do( ctx => ctx.UpdateAll( entities ) );
		}

		private static void UpdateAll( IEnumerable<Node> entities, long cnt ) {
			Acc.Update( cnt );
			foreach( Node entity in entities ) {
				entity.Frequency = cnt;
			}
		}

	}

}
