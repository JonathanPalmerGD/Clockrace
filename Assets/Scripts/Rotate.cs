using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
	public Vector3 axisOfRotation = Vector3.up;
	public float rotationRate;
	public bool varyRotation = false;

	void Start () 
	{
		if(varyRotation)
		{
			rotationRate += Random.Range(0, 50);
		}
	}
	
	void Update () 
	{
		transform.Rotate(axisOfRotation, rotationRate * Time.deltaTime);
	}
}
