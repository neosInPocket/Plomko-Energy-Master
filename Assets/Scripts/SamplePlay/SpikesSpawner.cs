using System.Collections;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{
	[SerializeField] private SpikeCrasher[] spikes;
	[SerializeField] private float[] delayTimes;
	[SerializeField] private CageSpawner cageSpawner;
	bool isRunning;
	bool isSpawnRunning;
	private Vector2 screenSize;

	private void Start()
	{
		screenSize = CageSpawner.ScreenSize();
	}

	public void Enable(bool enabled)
	{
		isRunning = enabled;
		if (!enabled)
		{
			StopAllCoroutines();
		}
	}

	private void Update()
	{
		if (!isRunning) return;
		StartCoroutine(spawnRoute());
	}

	private IEnumerator spawnRoute()
	{
		isSpawnRunning = true;
		Vector2 spikePosition = GetSpikeSpawnPosition();
		var spike = Instantiate(spikes[Random.Range(0, spikes.Length)], spikePosition, Quaternion.identity, transform);
		yield return new WaitForSeconds(Random.Range(delayTimes[0], delayTimes[1]));
		isSpawnRunning = false;
	}

	private Vector2 GetSpikeSpawnPosition()
	{
		return Vector2.one;
	}
}
