using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Rect startRect;
	public Rect titleRect;

	void Start()
	{
		titleRect = new Rect(Screen.width / 2 - 250, Screen.height / 2 - 300, 500, 150);
		startRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 50);
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 46;
		style.alignment = TextAnchor.UpperCenter;

		GUI.Label(titleRect, "Race Against the End of the Universe!", style);
		if (GUI.Button(startRect, "Race Against Time!"))
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}

		GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 90, 400, 80), "Game made by Jonathan Palmer!" +
			"\nwww.JonathanPalmerGD.com\n\n" +
			"Game Made in ~9 hours for MiniLudum49");
	}
}
