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
					DistanceMatrix = new List<int[,]>();
					Enumerable.Range(1, NodeCount).ToList().ForEach(i => DistanceMatrix.Add(new int[,] { }));
					DistanceMatrix[0] = value;
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
					_adjucencyMatrix[i, j] = i == j ? 0 : random.Next(1, (int)(InfinityThreshold * 1.30));
					if (_adjucencyMatrix[i, j] > _infinityThreshold) {
						_adjucencyMatrix[i, j] = int.MaxValue;
					}
				}
			}
			DistanceMatrix = new List<int[,]>();
			Enumerable.Range(1, NodeCount).ToList().ForEach(i => DistanceMatrix.Add(new int[,] { }));
			DistanceMatrix[0] = _adjucencyMatrix;
		}

		public string PrettyFormat(int[,] input, string name = "A") {
			StringBuilder sb = new StringBuilder();
			var l = input.Cast<int>().ToList();
			l.RemoveAll(x => x == int.MaxValue);
			int fieldLength = (int)Math.Log10(l.Max()) + 1 + 1;
			string placeholder = string.Format("{{0,{0}}}", fieldLength);
			string namePH = string.Format("{0} = ", name);
			sb.Append(new string(' ', namePH.Length))
				.Append("┌").Append(string.Join("", Enumerable.Range(0, input.GetLength(1)).Select(n => string.Format(placeholder, "")))).AppendLine(" ┐");
			for (int i = 0; i < input.GetLength(0); i++) {
				sb.Append(i == input.GetLength(0) / 2 ? namePH : new string(' ', namePH.Length));
				sb.Append("│");
				for (int j = 0; j < input.GetLength(1); j++) {
					sb.Append(input[i, j] == int.MaxValue ? string.Format(placeholder, "∞") : string.Format(placeholder, input[i, j]));
				}
				sb.AppendLine(" │");
			}
			sb.Append(new string(' ', namePH.Length))
				.Append("└").Append(string.Join("", Enumerable.Range(0, input.GetLength(1)).Select(n => string.Format(placeholder, "")))).AppendLine(" ┘");
			return sb.ToString();
		}

		internal void PrettyPrint(int[,] input = null, string name = "A") {
			if (input is null) {
				input = AdjucencyMatrix;
			}

			Console.WriteLine(PrettyFormat(AdjucencyMatrix), name);
		}


		public int Length(int[] path, int k = 0) {
			if (path.Length < 2) {
				throw new ArgumentException("", "path");
			}

			int result = 0;
			for (int i = 1; i < path.Length; i++) {
				//int d = DistanceMatrix[k][path[i - 1] - 1, path[i] - 1];
				int d = DistanceMatrix[k][path[i - 1], path[i]];
				if (d == int.MaxValue) {
					result = d;
					break;
				}
				result += d;
			}
			return result;
		}

		public void FillDistanceMatrix() {
			for (int k = 1; k < NodeCount; k++) {
				DistanceMatrix[k] = new int[NodeCount, NodeCount];
				for (int i = 0; i < NodeCount; i++) {
					for (int j = 0; j < NodeCount; j++) {
						List<int> distances = new List<int>();
						distances.Add(DistanceMatrix[k - 1][i, j]);
						GeneratePaths(i, j, k).ForEach(p => distances.Add(Length(p)));
						//DistanceMatrix[k][i, j] = (new int[] { DistanceMatrix[k - 1][i, j], Length(new int[] { i, k, j }, k - 1) }).Min();
						DistanceMatrix[k][i, j] = distances.Min();
					}
				}
				PrettyPrint(DistanceMatrix[k]);
			}
		}

		private List<int[]> GeneratePaths(int srcNode, int destNode, int intermediateNodesCount) {
			List<int[]> result = new List<int[]>();

			int[] path = new int[intermediateNodesCount + 2];
			path[0] = srcNode;
			path[intermediateNodesCount + 1] = destNode;


			return result;
		}
	}
}
