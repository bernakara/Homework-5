﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
	public class GFG
	{
		// A utility function to find the
		// vertex with minimum distance
		// value, from the set of vertices
		// not yet included in shortest
		// path tree
		public static int V=9;
	public	int minDistance(int[] dist,
						bool[] sptSet)
		{
			// Initialize min value
			int min = int.MaxValue, min_index = -1;

			for (int v = 0; v < V; v++)
				if (sptSet[v] == false && dist[v] <= min)
				{
					min = dist[v];
					min_index = v;
				}

			return min_index;
		}

		// A utility function to print
		// the constructed distance array

		// Let's define array  array[]
		public int[] array = new int[100];
		public int  printSolution(int[]dist)
		{
			


			Console.Write("\n\n Dijkstra Algorithm : \n");
			Console.Write("Vertex \t\t Distance "
						+ "from Source\n");
			for (int i = 0; i < V; i++)
			{
				Console.Write(i + " \t\t " + dist[i] + "\n");

				//I have transferred the menu results to array []
				array[i] = dist[i];
				
			}
			return 0;
	}

		// Funtion that implements Dijkstra's
		// single source shortest path algorithm
		// for a graph represented using adjacency
		// matrix representation


		public	int dijkstra(int[,] graph, int src)
		{
			

		   int[] dist = new int[V]; // The output array. dist[i]
									 // will hold the shortest
									 // distance from src to i

			// sptSet[i] will true if vertex
			// i is included in shortest path
			// tree or shortest distance from
			// src to i is finalized
			bool[] sptSet = new bool[V];

			// Initialize all distances as
			// INFINITE and stpSet[] as false
			for (int i = 0; i < V; i++)
			{
				dist[i] = int.MaxValue;
				sptSet[i] = false;

			
			}

			// Distance of source vertex
			// from itself is always 0
			dist[src] = 0;

			// Find shortest path for all vertices
			for (int count = 0; count < V - 1; count++)
			{
				// Pick the minimum distance vertex
				// from the set of vertices not yet
				// processed. u is always equal to
				// src in first iteration.
				int u = minDistance(dist, sptSet);

				// Mark the picked vertex as processed
				sptSet[u] = true;

				// Update dist value of the adjacent
				// vertices of the picked vertex.
				for (int v = 0; v < V; v++)

					// Update dist[v] only if is not in
					// sptSet, there is an edge from u
					// to v, and total weight of path
					// from src to v through u is smaller
					// than current value of dist[v]
					if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
						dist[v] = dist[u] + graph[u, v];
			}

			// print the constructed distance array
			printSolution(dist);

			return 0;
		}
	}

}
