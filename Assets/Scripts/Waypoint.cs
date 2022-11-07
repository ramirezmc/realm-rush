using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	[SerializeField] bool isPlaceable; 
	[SerializeField] Ballista ballistaPrefab;
	
	public bool IsPlaceable{ get { return isPlaceable;} }
	
	void OnMouseDown()
	{
		if (isPlaceable)
		{
			bool isPlaced = ballistaPrefab.CreateTower(ballistaPrefab, transform.position);
			isPlaceable = !isPlaced;
		}
	}
}
