using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour 
{
	public AudioClip[] clip;
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			if (clip != null && clip.Length > 0)
			{
				int randIndex = Random.Range(0, clip.Length);
				AudioSource.PlayClipAtPoint(clip[randIndex], transform.position);
			}
		}
	}
}
