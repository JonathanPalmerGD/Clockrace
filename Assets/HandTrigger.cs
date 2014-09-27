using UnityEngine;
using System.Collections;

public class HandTrigger : MonoBehaviour 
{
	public float pointsLost;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			c.gameObject.GetComponent<PlayerStats>().points -= pointsLost;
		}
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
}
