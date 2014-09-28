using UnityEngine;
using System.Collections;

public class WarpObject : MonoBehaviour 
{
	public bool targeted = false;
	public bool physical = false;

	public enum WarpColor { Purple = 0, Green = 1, Blue = 2 }
	public WarpColor objectColor;
	public int[] warpCost = {0,0,0};

	void Start()
	{
		Untarget();
		warpCost[(int)objectColor]++;
	}

	public void WarpIn()
	{
		renderer.material = Resources.Load("Active", typeof(Material)) as Material;
		collider.isTrigger = false;
		physical = true;
	}

	public void Untarget()
	{
		if (!physical)
		{
			if (objectColor == WarpColor.Purple)
			{
				renderer.material = Resources.Load("PurpleDormant", typeof(Material)) as Material;
			}
			else if (objectColor == WarpColor.Green)
			{
				renderer.material = Resources.Load("GreenDormant", typeof(Material)) as Material;
			}
			else if (objectColor == WarpColor.Blue)
			{
				renderer.material = Resources.Load("BlueDormant", typeof(Material)) as Material;
			}

			collider.isTrigger = true;
		}
	}

	public void Targeting()
	{
		if (!physical)
		{
			if (objectColor == WarpColor.Purple)
			{
				renderer.material = Resources.Load("PurplePotential", typeof(Material)) as Material;
			}
			else if (objectColor == WarpColor.Green)
			{
				renderer.material = Resources.Load("GreenPotential", typeof(Material)) as Material;
			}
			else if (objectColor == WarpColor.Blue)
			{
				renderer.material = Resources.Load("BluePotential", typeof(Material)) as Material;
			}
		}
	}

}
