using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class CoordinateLabeller : MonoBehaviour
{
	[SerializeField]Color defaultColor = Color.white;
	[SerializeField]Color blockedColor = Color.black;
	[SerializeField]Color exploredColor = Color.gray;
	[SerializeField]Color pathColor = Color.yellow;
	GridManager gridManager;
	TextMeshPro label;
	Vector2Int coordinates = new Vector2Int();
	
	void Awake()
	{
		gridManager = FindObjectOfType<GridManager>();
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
		if (gridManager == null){return;}
		
		Node node = gridManager.GetNode(coordinates);
		
		if(node == null){return;}
		
		if(!node.isWalkable)
		{
			label.color = blockedColor;
		}
		else if(node.isPath)
		{
			label.color = pathColor;
		}
		else if(node.isExplored)
		{
			label.color = exploredColor;
		}
		else
		{
			label.color = defaultColor;
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

