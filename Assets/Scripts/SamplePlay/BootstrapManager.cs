using UnityEngine;

public class BootstrapManager : MonoBehaviour
{
	[SerializeField] private ControlBall controlBall;
	[SerializeField] private MirrorBall mirrorBall;
	[SerializeField] private ImpulseSpawner impulseSpawner;

	private void Start()
	{
		impulseSpawner.Enable(true);
	}
}
