using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour 
{
	public float upward = 20;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			CharacterMotor motor = c.gameObject.GetComponent<CharacterMotor>();

			motor.SetVelocity(new Vector3(motor.movement.velocity.x * 1.5f, upward, motor.movement.velocity.z * 1.5f));
			//controller.SetVelocity(
			//CharacterMotor motor = controller.GetComponent<CharacterMotor>();


		}
	}

}
