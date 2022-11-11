using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	[SerializeField] bool isPlaceable; 
	[SerializeField] Ballista ballistaPrefab;
	
	GridManager gridManager;
	Pathfinder pathFinder;
	Vector2Int coordinates = new Vector2Int(); 
	protected void Awake()
	{
		gridManager = FindObjectOfType<GridManager>();
		pathFinder = FindObjectOfType<Pathfinder>();
	}
	
	void Start()
	{
		if(gridManager!= null)
		{
			coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
			
			if(!IsPlaceable)
			{
				gridManager.BlockNode(coordinates);
			}
		}
	}
	public bool IsPlaceable{ get { return isPlaceable;} }
	
	void OnMouseDown()
	{
		if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
		{
			bool isSuccessful = ballistaPrefab.CreateTower(ballistaPrefab, transform.position);
			if(isSuccessful)
			{
				gridManager.BlockNode(coordinates);
				pathFinder.NotifyRecievers();
			}
		}
	}
}
