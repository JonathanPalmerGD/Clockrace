using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour 
{
	public static bool paused = false;

	public Rect playerGUI;
	public float points;
	public Time timeLeft;

	void OnGUI()
	{
		playerGUI = GUI.Window(0, playerGUI, PlayerUI, "Clock Race!");
	}

	void PlayerUI(int windowID)
	{
		GUI.Label(new Rect(10, 20, 150, 40), "Points: " + points);
	}

	void Start () 
	{
		float windowWidth = 600;
		playerGUI = new Rect(Screen.width / 2 - windowWidth / 2, 35, windowWidth, 60);
	}
	
	void Update () 
	{
	
	}
}
