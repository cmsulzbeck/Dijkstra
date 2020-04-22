using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
	class Program
	{
		static void Main(string[] args)
		{
			int[,] matrix = new int[5,5]; // Stores the nodes
			int[] distance = new int[5]; // Stores the distances between nodes
			int[] visited = new int[5]; // Stores the visited nodes
			int[] preD = new int[5];


			int min = 999; // Sets minimun to infinity for all Nodes
			int nextNode = 0;

			Console.WriteLine("Enter the matrix!");

			// Reads the adjancecy matrix from the user
			for (int i = 0; i < 5; i++)
			{
				visited[i] = 0;
				preD[i] = 0;

				for (int j = 0; j < 5; j++)
				{
					matrix[i,j] = Convert.ToInt32(Console.ReadLine());

					if (matrix[i, j] == 0)
						matrix[i, j] = 999; // Sets all nodes to INIFINTY expect for the starting node
				}
			}

			for (int i = 0; i < 5; i++)
			{
				distance[i] = matrix[0, i]; // Sets the distance array to the first row of the matrix
			}
			distance[0] = 0; // Sets the initial distance to the source array (always 0)
			visited[0] = 1;

			// Start of the algorithm
			for (int i = 0; i < 5; i++)
			{
				min = 999;

				for (int j = 0; j < 5; j++)
				{
					if(min > distance[j] && visited[j] != 1)
					{
						min = distance[j];
						nextNode = j;
					}

					visited[nextNode] = 1;
				}

				for (int c = 0; c < 5; c++)
				{
					if(visited[c] != 1)
						if(min + matrix[nextNode, c] < distance[c])
						{
							distance[c] = min + matrix[nextNode, c];
							preD[c] = nextNode;
						}
				}
			}

			for (int i = 0; i < 5; i++)
			{
				Console.Write("|" + distance[i]);
			}
			Console.Write("|");

			// Printing the path
			for (int i = 0; i < 5; i++)
			{
				int j;

				Console.Write("Path = " + i);
				j = i;

				do
				{
					j = preD[j];
					Console.WriteLine(" <- " + j);
				} while (j != 0);
			}
		}
	}
}
