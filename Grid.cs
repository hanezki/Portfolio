using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
//TÄLLÄ SCRIPTILLÄ LUODAAN VAIN SLOTIT JOTKA SITTEN PREFABATAAN, TÄTÄ EI KÄYTETÄ PELISSÄ.

[ExecuteInEditMode]
public class Grid : MonoBehaviour 
{
	public Vector2 StartingPosition = new Vector3 ();
	public enum GridType {XbyYClickToRemove}
	public GridType gridType;
	public enum Orientation {TopLeft}
	public Orientation orientation;
	public float XCoords;
	public float YCoords;
	public float XSpacing;
	public float YSpacing;
	public bool createGrid = false;
	public bool clearGrid = false;
	public bool save = false;
	public GameObject SlotPrefab;
	public GameObject gridRoot;
	public string LayoutName = "";
	public List <GameObject> slots = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		ClearGrid();
		CreateGrid();
		Save ();
	
	}
	void Save()
	{
		if (save) 
		{
			save = false;

		}

	}
	void ClearGrid()
	{
		if (clearGrid) 
		{
			clearGrid = false;
			for (int i=0;i<slots.Count;i++)
			{
				DestroyImmediate(slots[i]);
			}
			slots.Clear();
		}
	}
	void CreateGrid()
	{
		if (createGrid)
		{
			createGrid = false;
			int index = 0;
			for(int y =0;y<YCoords;y++)
			{
				for (int x=0;x<XCoords;x++)
				{
					GameObject go = Instantiate(SlotPrefab,Vector3.zero,Quaternion.identity) as GameObject;
					go.name = "Slot"+index.ToString();
					switch(orientation)
					{
					case Orientation.TopLeft:
							
						go.transform.position = new Vector3(
							StartingPosition.x + x*XSpacing,
							StartingPosition.y - y*YSpacing
					
							);
						break;
					}
					go.transform.parent = gridRoot.transform;
					


					index++;
					slots.Add (go);
				}
			}
		}
	}

}
