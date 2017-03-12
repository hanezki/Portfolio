using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Layout 
{
	public List<string> layoutNames = new List<string>();
	public List<Slot> slots = new List<Slot>();
	//Luo pelin kortit difficultyn pohjalta
	public GameObject GetLayoutFromIndex()
	{
		GameObject go = null;
		if (GameInfo.Difficulty == 1)
		{
			GameObject resource = Resources.Load("Prefabs/EasySlots") as GameObject;

			go = GameObject.Instantiate(resource) as GameObject;


			foreach(Slot slot in go.GetComponentsInChildren<Slot>())
			{
				slots.Add(slot);
			}


		}
		else if (GameInfo.Difficulty == 2)
		{
			GameObject resource = Resources.Load("Prefabs/MediumSlots1") as GameObject;

			go = GameObject.Instantiate(resource) as GameObject;


			foreach(Slot slot in go.GetComponentsInChildren<Slot>())
			{
				slots.Add(slot);
			}


		}
		else if (GameInfo.Difficulty == 3)
		{
			GameObject resource = Resources.Load("Prefabs/HardSlots1") as GameObject;

			go = GameObject.Instantiate(resource) as GameObject;


			foreach(Slot slot in go.GetComponentsInChildren<Slot>())
			{
				slots.Add(slot);
			}


		}
		return go;
	}
}
