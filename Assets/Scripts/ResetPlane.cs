using UnityEngine;
using System.Collections;

public class ResetPlane : MonoBehaviour 
{
	private GameObject player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{
		if (player.transform.position.y < transform.position.y)
		{
			player.GetComponent<PlayerStats>().GoToCheckpoint();
		}
	}
}
