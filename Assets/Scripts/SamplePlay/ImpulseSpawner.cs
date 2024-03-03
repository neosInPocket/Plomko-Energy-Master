using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class ImpulseSpawner : MonoBehaviour
{
	[SerializeField] private GameObject impulseEffect;
	[SerializeField] private float destroyTime = 1f;
	[SerializeField] private float[] forces;
	[SerializeField] private float castRadius;
	[SerializeField] private float castThreshold;
	[SerializeField] private Transform controlBall;
	private float controlBallForce;

	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	private void Start()
	{
		controlBallForce = forces[SaveScript.data.upgradesMassive[0]];
	}

	public void Enable(bool value)
	{
		if (!value)
		{
			Touch.onFingerDown -= SpawnImpulse;
		}
		else
		{
			Touch.onFingerDown += SpawnImpulse;
		}
	}

	private void SpawnImpulse(Finger finger)
	{
		var touchPosition = CageSpawner.FingerPositionToWorld(finger.screenPosition);
		var circleCast = Physics2D.CircleCastAll(touchPosition, castRadius, Vector2.right);

		var controlBall = circleCast.FirstOrDefault(x => x.collider.name == "ControlBall");

		if (controlBall.collider != null)
		{
			Vector2 direction = ((Vector2)controlBall.transform.position - touchPosition).normalized;
			float distance = Vector2.Distance(controlBall.transform.position, touchPosition);
			float magnitude = 1 - distance / castRadius;
			float forceMagnitude = 0;
			if (magnitude > castThreshold)
			{
				forceMagnitude = controlBallForce;
			}
			else
			{
				forceMagnitude = controlBallForce * magnitude;
			}

			controlBall.collider.GetComponent<ControlBall>().AddVelocity(direction * forceMagnitude);
		}

		StartCoroutine(spawnImpulse(((Vector2)this.controlBall.transform.position - touchPosition).normalized, touchPosition));
	}

	private IEnumerator spawnImpulse(Vector2 direction, Vector2 touchPosition)
	{
		var impulse = Instantiate(impulseEffect, touchPosition, Quaternion.identity, transform);
		Vector3 dir = (Vector3)direction;
		dir.z = 0;
		impulse.transform.up = dir;
		yield return new WaitForSeconds(destroyTime);
		Destroy(impulse.gameObject);
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
		Touch.onFingerDown -= SpawnImpulse;
	}
}
