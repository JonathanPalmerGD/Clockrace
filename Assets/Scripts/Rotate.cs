using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
	public Vector3 axisOfRotation = Vector3.up;
	public float rotationRate = 10;
	public float counter;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		transform.Rotate(axisOfRotation, rotationRate * Time.deltaTime);
	}
}
