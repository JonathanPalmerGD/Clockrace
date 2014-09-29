using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour 
{
	public AudioClip[] clip;
	public bool triggerOnce = false;
	private bool triggered = false;
	public bool destroyOnTrigger = false;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			if (clip != null && clip.Length > 0)
			{
				if (triggerOnce)
				{
					if (!triggered)
					{
						PlayAudio(c.gameObject);
						
						/*int randIndex = Random.Range(0, clip.Length);
						AudioSource.PlayClipAtPoint(clip[randIndex], transform.position);
						triggered = true;*/
					}
				}
				else
				{
					PlayAudio(c.gameObject);
					/*int randIndex = Random.Range(0, clip.Length);
					AudioSource.PlayClipAtPoint(clip[randIndex], transform.position);
					triggered = true;*/
				}
				
				if (destroyOnTrigger)
				{
					Destroy(this.gameObject);
				}
			}
		}
	}

	void PlayAudio(GameObject player)
	{
		AudioSource audio = player.AddComponent<AudioSource>();
		int randIndex = Random.Range(0, clip.Length);
		audio.PlayOneShot(clip[randIndex]);
		//AudioSource.PlayClipAtPoint(clip[randIndex], transform.position);
		triggered = true;
	}
}
