using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour 
{
	public static bool paused = false;

	public Rect playerGUI;
	public int[] resources = { 5, 5, 5 };
	public enum WarpColor { Purple, Green, Blue }
	public float timeLeft = 300;
	public Checkpoint checkpoint;
	public GUIStyle big;
	public GUIStyle normal;

	void OnGUI()
	{
		big = new GUIStyle(GUI.skin.box);
		normal = new GUIStyle(GUI.skin.box);
		big.fontSize = 48;

		playerGUI = GUI.Window(0, playerGUI, PlayerUI, "Resources!");
		GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 140, 400, 130), "Time Left\n" + ((int)timeLeft).ToString(), big);
	}

	void PlayerUI(int windowID)
	{
		
		GUI.Box(new Rect(10, 20, 150, 40), "Purples: " + resources[0]);
		GUI.Box(new Rect(170, 20, 150, 40), "Greens: " + resources[1]);
		GUI.Box(new Rect(340, 20, 150, 40), "Blues: " + resources[1]);

	}

	void Start () 
	{
		float windowWidth = 600;
		playerGUI = new Rect(Screen.width / 2 - windowWidth / 2, 35, windowWidth, 60);
	}

	public void UpdateCheckpoint(Checkpoint newCheckpoint)
	{
		if (checkpoint != null)
		{
			checkpoint.Deactivate();
		}
		newCheckpoint.Activate();
		checkpoint = newCheckpoint;
	}

	public void GoToCheckpoint()
	{
		gameObject.transform.position = checkpoint.transform.position;
		gameObject.transform.rotation = checkpoint.transform.rotation;
	}

	public void Update()
	{
		timeLeft -= Time.deltaTime;

		if (paused)
		{
			Screen.showCursor = true;
			Screen.lockCursor = false;

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ResumePlay();
			} 
		}
		else if (!paused)
		{
			Screen.showCursor = false;
			Screen.lockCursor = true;

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				PausePlay();
			} 
		}

		CheckInput();
	}

	void CheckInput()
	{
		if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
		{
			CharacterMotor motor = gameObject.GetComponent<CharacterMotor>();
			motor.SetVelocity(new Vector3(motor.movement.velocity.x, 20, motor.movement.velocity.z));
			
		}
	}

	void PausePlay()
	{
		paused = true;
		Time.timeScale = 0.0f;
	}

	void ResumePlay()
	{
		paused = false;
		Time.timeScale = 1.0f;
	}
}
