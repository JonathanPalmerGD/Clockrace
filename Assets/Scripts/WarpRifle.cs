using UnityEngine;
using System.Collections;

public class WarpRifle : MonoBehaviour 
{
	public Camera cam;
	public GameObject targeting;
	public WarpObject targetingWarp;
	public AudioClip[] clip;

	void Start () 
	{

	}
	
	void Update () 
	{
		if (cam != null)
		{
			//Debug.DrawLine(transform.position, cam.transform.forward * 100, Color.red);
			RaycastHit hitInfo;
			if (Physics.Raycast(new Ray(transform.position, cam.transform.forward), out hitInfo, 50))
			{
				if (hitInfo.collider.gameObject.GetComponent<WarpObject>() != null)
				{
					//If it is something new
					if (hitInfo.collider.gameObject != targeting)
					{
						if (targetingWarp != null)
						{
							//Untarget the old
							targetingWarp.Untarget();
						}
						//Set the new
						targetingWarp = hitInfo.collider.gameObject.GetComponent<WarpObject>();
						targetingWarp.targeted = true;
						targeting = hitInfo.collider.gameObject;
						targetingWarp.Targeting();
					}
				}
				else
				{
					targeting = null;
					targetingWarp = null;
				}
			}
		}

		CheckInput();
	}

	void CheckInput()
	{
		if(Input.GetButton("Warp"))
		//if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q))
		{
			if (targeting != null)
			{
				if (!targetingWarp.physical)
				{
					if (targetingWarp.warpCost[(int)targetingWarp.objectColor] <= GetComponent<PlayerStats>().resources[(int)targetingWarp.objectColor])
					{
						GetComponent<PlayerStats>().resources[(int)targetingWarp.objectColor] -= targetingWarp.warpCost[(int)targetingWarp.objectColor];
						targetingWarp.WarpIn();
						PlayAudio();
					}
				}
			}
		}
	}

	void PlayAudio()
	{
		AudioSource audio = gameObject.AddComponent<AudioSource>();
		int randIndex = Random.Range(0, clip.Length);
		audio.PlayOneShot(clip[randIndex]);
	}
}
