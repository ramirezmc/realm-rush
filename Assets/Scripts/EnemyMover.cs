using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	
	[SerializeField] [Range(0f, 5f)] float travelSpeed = 1;
	List<Node> path = new List<Node>();
	GridManager gridManager;
	Pathfinder pathFinder;
	Enemy enemy;
	protected void Awake()
	{
		enemy = GetComponent<Enemy>();
		gridManager = FindObjectOfType<GridManager>();
		pathFinder = FindObjectOfType<Pathfinder>();
	}
	void OnEnable()
	{
		ReturnToStart();
		RecalculatePath(true);
	}
	void OnDisable()
	{
		ReturnToStart();
	}
	
	void RecalculatePath(bool resetPath)
	{
		Vector2Int coordinates = new Vector2Int();
		if(resetPath)
		{
			coordinates = pathFinder.StartCoords;
		}
		else
		{
			coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
		}
		
		StopAllCoroutines();
		path.Clear();
		path = pathFinder.GetNewPath(coordinates);
		StartCoroutine (FollowPath());
	}
	
	void ReturnToStart()
	{
		transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoords);
	}
	
	void FinishPath()
	{
		enemy.StealGold();
		gameObject.SetActive(false);
	}
	
	IEnumerator FollowPath()
	{
		for(int i = 1; i < path.Count; i++)
		{
			Vector3 startPosition = transform.position;
			Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
			float travelPercent = 0f;
			
			transform.LookAt(endPosition);
			
			while(travelPercent < 1)
			{
				travelPercent+=Time.deltaTime * travelSpeed;
				transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
				yield return new WaitForEndOfFrame();
			}
		}
		FinishPath();
	}
}
