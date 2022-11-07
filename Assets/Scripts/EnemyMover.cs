using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	[SerializeField] List<Waypoint> path = new List<Waypoint>();
	[SerializeField] [Range(0f, 5f)] float travelSpeed = 1;
	Enemy enemy;
	void OnEnable()
	{
		enemy = GetComponent<Enemy>();
		FindPath();
		StartCoroutine (FollowPath());
	}
	
	void OnDisable()
	{
		ReturnToStart();
	}
	
	void FindPath()
	{
		path.Clear();
		
		GameObject waypoints = GameObject.FindGameObjectWithTag("Path");
		foreach (Transform points in waypoints.transform)
		{
			Waypoint waypoint = points.GetComponent<Waypoint>();
			if(waypoint != null)
			{
				path.Add(waypoint);
			}
		}
	}
	
	void ReturnToStart()
	{
		transform.position = path[0].transform.position;
	}
	
	void FinishPath()
	{
		enemy.StealGold();
		gameObject.SetActive(false);
	}
	
	IEnumerator FollowPath()
	{
		foreach (Waypoint point in path)
		{
			Vector3 startPosition = transform.position;
			Vector3 endPosition = point.transform.position;
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
