using UnityEngine;
using System.Collections;

public class MakeTransparent : MonoBehaviour 
{
	private static string resourceName = "Checkered";
	
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("Player").transform.position.y < transform.position.y)
		{
			renderer.material = Resources.Load(resourceName, typeof(Material)) as Material;
			gameObject.collider.isTrigger = true;
			Destroy(this);
		}
	}
}
