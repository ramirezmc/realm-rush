using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinateLabeller : MonoBehaviour
{
	[SerializeField]Color defaultColor = Color.white;
	Color blockedColor = Color.clear;
	Waypoint waypoint;
	TextMeshPro label;
	Vector2Int coordinates = new Vector2Int();
	
	void Awake()
	{
		waypoint = GetComponentInParent<Waypoint>();
		label = GetComponent<TextMeshPro>();
		label.enabled = false;
		DisplayCoordinates();
	}
    void Update()
    {
	    if(!Application.isPlaying)
	    {
	    	label.enabled = true;
	    	DisplayCoordinates();
	    	UpdateObjectName();
	    }
	    SetLabelColor();
	    ToggleLables();
    }
    
	void DisplayCoordinates()
	{
		coordinates.x = Mathf.RoundToInt (transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
		coordinates.y = Mathf.RoundToInt (transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
		label.text = coordinates.x + "," + coordinates.y;
	}
	
	void UpdateObjectName()
	{
		transform.parent.name = coordinates.ToString();
	}
	
	void SetLabelColor()
	{
		if (waypoint.IsPlaceable)
		{
			label.color = defaultColor;
		}
		else
		{
			label.color = blockedColor;	
		}
	}
	
	void ToggleLables()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			label.enabled = !label.IsActive();
		}
	}
}

