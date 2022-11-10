using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	Node startNode;
	[SerializeField]Vector2Int startCoords;
	Node endNode;
	[SerializeField]Vector2Int endCoords;
	Node currentSearchNode;
	
	Queue<Node> frontier = new Queue<Node>();
	Dictionary<Vector2Int,Node> reached = new Dictionary<Vector2Int, Node>();
	
	Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
	GridManager gridManager;
	Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
	
	
	protected void Awake()
	{
		gridManager = FindObjectOfType<GridManager>();
		if (gridManager != null)
		{
			grid = gridManager.Grid;
		}
		
		startNode = new Node(startCoords, true);
		endNode = new Node(endCoords, true);
	}
	
    void Start()
    {
	    BreadthFirstSearch();
    }
    
	void ExploreNeighbors()
	{
		List<Node>Neighbors = new List<Node>();
		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighborCoordinates = currentSearchNode.coordinates + direction;
			if (grid.ContainsKey(neighborCoordinates))
			{
				Neighbors.Add(grid[neighborCoordinates]);
			}
		}
		foreach(Node neighbor in Neighbors)
		{
			if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
			{
				reached.Add(neighbor.coordinates, neighbor);
				frontier.Enqueue(neighbor);
			}
		}
	}
    
    
	void BreadthFirstSearch()
	{
		bool isRunning = true;
		
		frontier.Enqueue(startNode);
		reached.Add(startCoords, startNode);
		
		while(frontier.Count > 0 && isRunning)
		{
			currentSearchNode = frontier.Dequeue();
			currentSearchNode.isExplored = true;
			ExploreNeighbors();
			if(currentSearchNode.coordinates == endCoords)
			{
				isRunning = false;
			}
		}
	}
}
