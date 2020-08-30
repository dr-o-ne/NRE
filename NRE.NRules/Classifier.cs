using System;
using System.Collections.Generic;
using System.Reflection;
using NRE.Common;
using NRules;
using NRules.Diagnostics;
using NRules.Fluent;

namespace NRE.NRules {

	public sealed class Classifier : IClassifier {

		public void Run( List<Node> nodes ) {

			//Load rules
			var repository = new RuleRepository();
			repository.Load( x => x.From( Assembly.GetExecutingAssembly() ) );

			//Compile rules
			var factory = repository.Compile();

			//Create a working session
			var session = factory.CreateSession();
			session.Events.RuleFiringEvent += OnRuleFiringEvent;

			foreach( var node in nodes )
				session.Insert( node );

			session.Fire();

		}

		private static void OnRuleFiringEvent( object sender, AgendaEventArgs e ) {
			Console.WriteLine( "Rule about to fire {0}", e.Rule.Name );
		}

	}

}
