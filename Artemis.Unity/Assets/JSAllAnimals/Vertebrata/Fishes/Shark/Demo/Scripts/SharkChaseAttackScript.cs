using UnityEngine;
using System.Collections;

public class SharkChaseAttackScript : MonoBehaviour
{

	SharkCharacter sharkCharacter;
	public GameObject chaseTarget;
	public float debugValue;

	void Start()
	{
		sharkCharacter = GetComponent<SharkCharacter>();
	}

	void FixedUpdate()
	{
		Vector3 targetRelPos = chaseTarget.transform.position - transform.position;
		
		float sqrDistance = targetRelPos.sqrMagnitude;
		sharkCharacter.forwardAccerelation = Mathf.Clamp(sqrDistance * 0.1f, 0f, 2f);
		debugValue = sqrDistance;

		if(sqrDistance < 1f)
		{
			sharkCharacter.Bite();
		}

		if(sqrDistance < 0.3f)
		{
			sharkCharacter.forwardAccerelation = 0;
		}

		targetRelPos.Normalize();
		sharkCharacter.turnAccerelation = Vector3.Dot(targetRelPos, transform.right);
		sharkCharacter.upDownAccerelation = Vector3.Dot(targetRelPos, transform.up);

		if(transform.up.y > 0f)
		{
			sharkCharacter.rollAccerelation = -transform.right.y;
		}
		else if(transform.right.y > 0f)
		{
			sharkCharacter.rollAccerelation = -2f + transform.right.y;
		}
		else if(transform.right.y > 0f)
		{
			sharkCharacter.rollAccerelation = 2f - transform.right.y;
		}
	}
}
