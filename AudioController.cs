using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private static AudioController _instance;
	public static AudioController instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<AudioController>();
			return _instance;
		}
	}

	public AudioSource sound1;
	public AudioSource sound2;
	public AudioSource sound3;
	public AudioSource sound4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ButtonClick()
	{
		sound2.Play ();
	}
	public void CardFlip1()
	{
		sound1.Play ();
	}
	public void CardFlip2()
	{
		sound3.Play ();
	}
	public void MatchSound()
	{
		sound4.Play ();
	}
}
