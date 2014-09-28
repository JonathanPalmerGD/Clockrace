using UnityEngine;
using System.Collections;

public class HideOnRun : MonoBehaviour 
{

	void Start ()
	{
		#if !UNITY_EDITOR
		renderer.enabled = false;
		#endif
	}
}
