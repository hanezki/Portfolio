using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class MemoryGameManager : MonoBehaviour 
{

	string[] selectedCards = new string[2];
	public static bool isChecking = false;

	private int cardsNum = 0;

	public Text timeText;
	public Text movesText;


	// Use this for initialization
	void Start () 
	{
		Application.targetFrameRate = 60;

		selectedCards [0] = "";
		selectedCards [1] = "";

		if (Application.loadedLevel == 4) 
		{
			timeText.text = GameInfo.timer.ToString("0.0");
			movesText.text = GameInfo.Moves.ToString();
		}

	}
	
	// Update is called once per frame

	void Update () 
	{

		if (GameInfo.Running == true) 
		{
			IsRunning();
						
		} 


	}

	public void setCardName(string cardName){
		if(selectedCards[0].Equals("")){
			selectedCards[0] = cardName;

		}
		else{
			selectedCards[1] = cardName;
		}
	}

	public void checkCards()
	{
		List<Card> cards = GameObject.Find ("GameManager").GetComponent<Playmat> ().getCards ();

		int turnedCards = 0;

		for(int i = 0; cards.Count > i; i++ )
		{
			if(cards[i].CardState == 1){
				turnedCards++;
			}
		}
		//tarkistaa onko käännetyt kortit samat
		if(turnedCards == 2)
		{
			GameInfo.Turned = 2;
			GameInfo.Moves++;

			if(selectedCards[0].Substring(selectedCards[0].IndexOf("/")+1).Equals(selectedCards[1].Substring(selectedCards[1].IndexOf("/")+1)))
			{

				GameInfo.Turned = 0;
				cardsNum += 2;
				GameObject.Find (selectedCards [0]).GetComponent<Card> ().Match();
				GameObject.Find (selectedCards [1]).GetComponent<Card> ().Match();

				for(int i = 0; cards.Count > i; i++ )
				{
					if(cards[i].CardState == 1){
						cards[i].CardState = 2;
					}
				}



				if(GameInfo.Difficulty == 1)
				{
					if(cardsNum == 12)
					{
						Win();
					}
				}
				else if(GameInfo.Difficulty == 2)
				{
					if(cardsNum == 20)
					{
						Win();
					}
				}
				else if(GameInfo.Difficulty == 3)
				{
					if(cardsNum == 30)
					{
						Win();
					}
				}
				selectedCards [0] = "";
				selectedCards [1] = "";
			}
			else
			{

				isChecking = true;
				Invoke("VaaraPari", 1f);

			}
		}
	}
	//vaihtaa cardstaten takaisin 0 jos väärä pari
	private void VaaraPari()
	{
		AudioController.instance.CardFlip2 ();
		List<Card> cards = GameObject.Find ("GameManager").GetComponent<Playmat> ().getCards ();

		for(int i = 0; cards.Count > i; i++ )
		{
			if(cards[i].CardState == 1)
			{
				cards[i].CardState = 0;

			}

		}
		isChecking = false;
		

		GameObject.Find (selectedCards [0]).GetComponent<Card> ().FlipDown();
		GameObject.Find (selectedCards [1]).GetComponent<Card> ().FlipDown();
		GameInfo.Turned = 0;
		selectedCards [0] = "";
		selectedCards [1] = "";
	}
	//peli läpi, tekee tekstit voittoruutuun
	private void WinLevel()
	{
		Application.LoadLevel("MemoryMatchingGameScoreScreen");

	}
	//peli läpi, suorittaa win 2sec päästä.
		 private void Win()
		 {
			GameInfo.Turned = 0;
			GameInfo.Running = false;
			Invoke ("WinLevel", 2f);
		    
		 }

	// ajastin
	private void IsRunning()
	{
		GameInfo.timer += Time.deltaTime;

	}
}
