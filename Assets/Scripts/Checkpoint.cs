using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour 
{
	private bool activeCheckpoint = false;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			c.gameObject.GetComponent<PlayerStats>().UpdateCheckpoint(this);
		}
	}


	public void Deactivate()
	{

	}

	public void Activate()
	{

	}
}
