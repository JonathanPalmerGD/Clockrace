using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour 
{
	public static bool paused = false;

	public Rect playerGUI;
	public int[] resources = { 0, 0, 0 };
	public enum WarpColor { Purple, Green, Blue }
	public float timeLeft = 300;
	public Checkpoint checkpoint;
	public GUIStyle big;
	public GUIStyle normal;
	public AudioClip[] quitClips;
	public AudioClip[] timeClips;
	public AudioClip[] nearExplosion;
	public Detonator bomb;
	public bool hasWon = false;
	public bool hasLost = false;
	public bool[] audTrig;
	public float counter = 0;

	void OnGUI()
	{
		big = new GUIStyle(GUI.skin.box);
		normal = new GUIStyle(GUI.skin.box);
		big.fontSize = 48;

		if (!hasWon && !hasLost && !paused)
		{
			playerGUI = GUI.Window(0, playerGUI, PlayerUI, "Resources!");
			GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 140, 400, 130), "Time Left\n" + ((int)timeLeft).ToString(), big);
		}
		if (hasLost)
		{
			GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 140, 400, 130), "YOU LOST!", big);
		}
		if(hasWon)
		{
			GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 140, 400, 130), "YOU WIN!", big);
		}
		
		if (paused)
		{
			GUI.Box(new Rect(-10, -10, Screen.width + 20, Screen.height + 20), "");
			GUI.Box(new Rect(-10, -10, Screen.width + 20, Screen.height + 20), "");
			Rect pauseBox = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 300);
			GUI.Box(pauseBox, "Game Paused!");

			if (GUI.Button(new Rect(pauseBox.xMin + 10, pauseBox.yMin + 50, 180, 50), "Resume!"))
			{
				ResumePlay();
			}
#if !UNITY_WEB
			if (GUI.Button(new Rect(pauseBox.xMin + 10, pauseBox.yMin + 170, 180, 50), "Quit!"))
			{
				Application.Quit();
			}
#endif

			GUI.Box(new Rect(pauseBox.xMin - pauseBox.width / 2, pauseBox.yMax + 40, pauseBox.width * 2, 100), "Game made by Jonathan Palmer!" +
			"\nwww.JonathanPalmerGD.com\n\n" +
			"Special thanks to Ben Throop for the Detonator Package!\nThanks to A Lab Software for the Skybox!\n" + "Game Made in ~9 hours for MiniLudum49");
		}

		
	}

	void PlayerUI(int windowID)
	{
		
		GUI.Box(new Rect(10, 20, 150, 40), "Purples: " + resources[0]);
		GUI.Box(new Rect(170, 20, 150, 40), "Greens: " + resources[1]);
		GUI.Box(new Rect(340, 20, 150, 40), "Blues: " + resources[2]);

	}

	void Start () 
	{
		float windowWidth = 600;
		playerGUI = new Rect(Screen.width / 2 - windowWidth / 2, 35, windowWidth, 60);

		audTrig = new bool[4];
	}

	public void UpdateCheckpoint(Checkpoint newCheckpoint)
	{
		Debug.Log(newCheckpoint.name + "\n");
		if (newCheckpoint != checkpoint)
		{	
			if (checkpoint != null)
			{
				checkpoint.Deactivate();
				Destroy(checkpoint.gameObject);
			}
			newCheckpoint.Activate();
			checkpoint = newCheckpoint;
		}
	}

	public void GoToCheckpoint()
	{
		gameObject.transform.position = checkpoint.transform.position;
		gameObject.transform.rotation = checkpoint.transform.rotation;
	}

	public void Update()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft < 60 && !audTrig[0])
		{
			audTrig[0] = true;
			PlayAudio(timeClips);
		}
		if (timeLeft > 60 && audTrig[0])
		{
			audTrig[0] = false;
		}
		if (timeLeft < 45 && !audTrig[1])
		{
			audTrig[1] = true;
			PlayAudio(timeClips);
		}
		if (timeLeft > 45 && audTrig[1])
		{
			audTrig[1] = false;
		}
		if (timeLeft < 30 && !audTrig[2])
		{
			audTrig[2] = true;
			PlayAudio(timeClips);
		}
		if (timeLeft > 30 && audTrig[2])
		{
			audTrig[2] = false;
		}
		if (timeLeft < 10 && !audTrig[3])
		{
			audTrig[3] = true;
			PlayAudio(timeClips);
		}
		if (timeLeft > 10 && audTrig[3])
		{
			audTrig[3] = false;
		}

		if (hasLost)
		{
			counter += Time.deltaTime;
		}

		if (timeLeft < 0 && !hasLost)
		{
			hasLost = true;
			PlayAudio(nearExplosion);
			bomb.Explode();
		}

		if (counter > 5)
		{
			Application.LoadLevel(0);
		}

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
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
		{
			CharacterMotor motor = gameObject.GetComponent<CharacterMotor>();
			motor.SetVelocity(new Vector3(motor.movement.velocity.x, 80, motor.movement.velocity.z));
		}
		if (Input.GetKeyDown(KeyCode.Y) )
		{
			timeLeft -= 30;
		}
#endif
	}

	void PausePlay()
	{
		paused = true;
		Time.timeScale = 0.0f;
		PlayAudio(quitClips);
	}

	void ResumePlay()
	{
		paused = false;
		Time.timeScale = 1.0f;
	}

	void PlayAudio(AudioClip[] clips)
	{
		AudioSource audio = gameObject.AddComponent<AudioSource>();
		int randIndex = Random.Range(0, clips.Length);
		audio.PlayOneShot(clips[randIndex]);
	}

	public void Win()
	{
		hasWon = true;
	}
}
