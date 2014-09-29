using UnityEngine;
using System.Collections;

public class ExplosionTrigger : MonoBehaviour 
{
	public Detonator bomb;
	public GameObject endLoc;
	public AudioClip farExplosions;

	void OnTriggerEnter(Collider c)
	{
		GameObject.FindGameObjectWithTag("Player").transform.position = endLoc.transform.position;
		GameObject.FindGameObjectWithTag("Player").transform.rotation = endLoc.transform.rotation;
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Win();
		PlayAudio(farExplosions);
		bomb.Explode();
		Destroy(gameObject);
	}

	void PlayAudio(AudioClip clips)
	{
		AudioSource audio = GameObject.FindGameObjectWithTag("Player").AddComponent<AudioSource>();
		audio.PlayOneShot(clips);
	}
}
