using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Playmat : MonoBehaviour 
{
	public GameObject cardPrefab;
	public Layout layout;
	public GameObject board;

	public List<Card> cards = new List<Card>();

	private List<Card> randomizedCards = new List<Card>();
	// Use this for initialization
	void Start () 
	{
		//GameSettings.Instance ().SetDifficulty (GameSettings.GameDifficulty.Medium);


		CreateLayout ();
		CreateCardsFromLayout ();


	}
	void CreateLayout()
	{
		board = layout.GetLayoutFromIndex ();
	
	}


	public GameObject GenerateCard(string cardType)
	{
		//Debug.Log (cardType);
		return Resources.Load ("Prefabs/"+cardType) as GameObject;
		//
	}


	void CreateCardsFromLayout()
	{
		
		int i = 1;
		int j = 0;
		string cardString = "Card";

		foreach (Slot s in layout.slots) 
		{

			GameObject go = Instantiate(GenerateCard(cardString + i.ToString()), s.transform.position,Quaternion.Euler(0,0,0)) as GameObject;

			go.transform.parent = s.transform;
			go.transform.parent = s.transform;
			
			cards.Add (go.GetComponent<Card>());

			if(GameInfo.Difficulty == 2)
			{
				go.transform.localScale *= 0.75F;
			}
			else if(GameInfo.Difficulty == 3)
			{
				go.transform.localScale *= 0.6F;
				
			}

			j++;

			if(j % 2 == 0) 
			{
				//Debug.Log ("raising the counter...");
				i++;
			}
		}

		//randomisoi kortit
		int listSize = cards.Count;
		for(int k = 0; k < listSize; k++)
		{
			int index = Random.Range (0, cards.Count - 1);
			randomizedCards.Add (cards [index]);
			cards.RemoveAt (index);
		}

		for(int k = 0; k < listSize; k++)
		{
			randomizedCards[k].transform.position = layout.slots[k].transform.position;
		}


	}

	public List<Card> getCards(){
		return randomizedCards;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
