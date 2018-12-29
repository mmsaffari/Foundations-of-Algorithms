using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_3 {
	public class WeightedGraph {

		#region "Fields and Properties"
		private int[,] _aducencyMatrix;
		private int _infinityThreshold;

		public int NodeCount { get; private set; }
		public int[,] AdjucencyMatrix {
			get { return _aducencyMatrix; }
			set {
				if (!(value is int[,]) || value.GetLength(0) != value.GetLength(1) || value.GetLength(0) != NodeCount) {
					throw new NotSupportedException();
				} else {
					_aducencyMatrix = value;
				}
			}
		}

		public List<int[,]> DistanceMatrix { get; private set; }
		#endregion

		public WeightedGraph(int NodeCount = 10) {
			this.NodeCount = NodeCount;
			AdjucencyMatrix = new int[NodeCount, NodeCount];
		}

		public void GenerateRandomGraph(int InfinityThreshold = 15) {
			_infinityThreshold = InfinityThreshold;
			Random random = new Random();
			for (int i = 0; i < NodeCount; i++) {
				for (int j = 0; j < NodeCount; j++) {
					_aducencyMatrix[i, j] = i == j ? 0 : random.Next(20);
					if (_aducencyMatrix[i, j] > _infinityThreshold) {
						_aducencyMatrix[i, j] = int.MaxValue;
					}
				}
			}
		}

		public string PrettyFormat(int[,] input, string name = "A") {
			StringBuilder sb = new StringBuilder();
			var l = input.Cast<int>().ToList();
			l.RemoveAll(x => x == int.MaxValue);
			int fieldLength = (int)Math.Log10(l.Max()) + 1;
			string placeholder = string.Format("{{0,{0}}}", fieldLength);
			return sb.ToString();
		}

		internal void PrettyPrint() {
			Console.WriteLine(PrettyFormat(AdjucencyMatrix));
		}

	}
}
