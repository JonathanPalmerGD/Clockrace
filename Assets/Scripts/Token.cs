using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour 
{
	public bool gainResources = true;
	public int[] value = { 5, 5, 5 };

	public bool gainTime = false;
	public float bonusTime = 5;

	public bool plusBaseJumpHeight = false;
	public float bonusBJumpH = 0;
	public bool plusExtraJumpHeight = false;
	public float bonusEJumpH = 0;
	public bool plusMaxForwardSpeed = false;
	public float bonusMForwardS = 0;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			PlayerStats stats = c.gameObject.GetComponent<PlayerStats>();

			if (gainResources)
			{
				stats.resources[0] += value[0];
				stats.resources[1] += value[1];
				stats.resources[2] += value[2];
			}

			if (gainTime)
			{
				stats.timeLeft += bonusTime;
			}

			if (plusBaseJumpHeight)
			{

				
			}

			if (plusExtraJumpHeight)
			{
				c.gameObject.GetComponent<CharacterMotor>().jumping.extraHeight += bonusEJumpH;
			}

			if (plusMaxForwardSpeed)
			{
				c.gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed += bonusMForwardS;
				c.gameObject.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed += bonusMForwardS;
				c.gameObject.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed += bonusMForwardS;
			}

			gameObject.SetActive(false);
		}
	}
}
