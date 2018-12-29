using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_3 {
	public class WeightedGraph {

		#region "Fields and Properties"
		private int[,] _adjucencyMatrix;
		private int _infinityThreshold;

		public int NodeCount { get; private set; }
		public int[,] AdjucencyMatrix {
			get { return _adjucencyMatrix; }
			set {
				if (!(value is int[,]) || value.GetLength(0) != value.GetLength(1) || value.GetLength(0) != NodeCount) {
					throw new NotSupportedException();
				} else {
					_adjucencyMatrix = value;
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
					_adjucencyMatrix[i, j] = i == j ? 0 : random.Next((int)(InfinityThreshold * 1.30));
					if (_adjucencyMatrix[i, j] > _infinityThreshold) {
						_adjucencyMatrix[i, j] = int.MaxValue;
					}
				}
			}
		}

		public string PrettyFormat(int[,] input, string name = "A") {
			StringBuilder sb = new StringBuilder();
			var l = input.Cast<int>().ToList();
			l.RemoveAll(x => x == int.MaxValue);
			int fieldLength = (int)Math.Log10(l.Max()) + 1 + 1;
			string placeholder = string.Format("{{0,{0}}}", fieldLength);
			string namePH = string.Format("{0} = ", name);
			sb.Append(new string(' ', namePH.Length))
				.Append("┌ ").Append(string.Join("", Enumerable.Range(0, input.GetLength(1)).Select(n => string.Format(placeholder, "")))).AppendLine(" ┐");
			for (int i = 0; i < input.GetLength(0); i++) {
				sb.Append(i == input.GetLength(0) / 2 ? namePH : new string(' ', namePH.Length));
				sb.Append("│ ");
				for (int j = 0; j < input.GetLength(1); j++) {
					sb.Append(input[i, j] == int.MaxValue ? string.Format(placeholder, "∞") : string.Format(placeholder, input[i, j]));
				}
				sb.AppendLine(" │");
			}
			sb.Append(new string(' ', namePH.Length))
				.Append("└ ").Append(string.Join("", Enumerable.Range(0, input.GetLength(1)).Select(n => string.Format(placeholder, "")))).AppendLine(" ┘");
			return sb.ToString();
		}

		internal void PrettyPrint() {
			Console.WriteLine(PrettyFormat(AdjucencyMatrix));
		}

		private int Distance(int node1, int node2, int k) {
			int result = DistanceMatrix[k][node1, node2];

			return result;

		}


		public void FillDistanceMatrix() {

		}
	}
}
