using System;
using System.Collections.Generic;
using NRE.Common;
using NRE.NRules;

namespace NRE {

	internal class Program {

		private static void Main( string[] args ) {

			List<Node> nodes = new List<Node> {
				new Node {Key = "income", Value = "2245"},
				new Node {Key = "income", Value = "2529"},
				new Node {Key = "income", Value = "2206"},
				new Node {Key = "tax", Value = "2210"},
				new Node {Key = "tax", Value = "2169"},
				new Node {Key = "income", Value = "2202"},
				new Node {Key = "tax", Value = "2202"},
				new Node {Key = "tax", Value = "2201"},
				new Node {Key = "tax", Value = "2200"},
				new Node {Key = "tax", Value = "2199"}
			};

			var classifier = new Classifier();
			classifier.Run( nodes );

			Console.WriteLine( "Hello World!" );
		}

	}

}
