using System.Collections;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{
	[SerializeField] private SpikeCrasher[] spikes;
	[SerializeField] private float[] delayTimes;
	[SerializeField] private CageSpawner cageSpawner;
	[SerializeField] private GameObject exclamation;
	[SerializeField] private float spawnDistance;
	[SerializeField] private float exclamationDistance;
	bool isRunning;
	bool isSpawnRunning;
	private Vector2 screenSize;

	private void Awake()
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
		if (isSpawnRunning) return;
		StartCoroutine(spawnRoute());
	}

	private IEnumerator spawnRoute()
	{
		isSpawnRunning = true;

		var spike = Instantiate(spikes[Random.Range(0, spikes.Length)], Vector2.zero, Quaternion.identity, transform);
		var positions = GetSpikeSpawnPosition(spike);
		spike.transform.position = positions.Item1;
		StartCoroutine(exclamationSpawn(positions.Item2));
		yield return new WaitForSeconds(Random.Range(delayTimes[0], delayTimes[1]));

		isSpawnRunning = false;
	}

	private IEnumerator exclamationSpawn(Vector2 position)
	{
		var exclamationObject = Instantiate(exclamation, position, Quaternion.identity, transform);
		yield return new WaitForSeconds(1f);
		Destroy(exclamationObject.gameObject);
	}

	private (Vector2, Vector2) GetSpikeSpawnPosition(SpikeCrasher spikeCrasher)
	{
		Vector2 position = new Vector2();
		Vector2 exclamation = new Vector2();
		var random = Random.Range(0, 2);

		if (random == 0)
		{
			position.x = -screenSize.x - spikeCrasher.size / 2 - spawnDistance;
			position.y = Random.Range(cageSpawner.yCageBorders.x + spikeCrasher.size / 2, cageSpawner.yCageBorders.y - spikeCrasher.size / 2);
			exclamation.x = -screenSize.x + exclamationDistance;
			exclamation.y = position.y;
			spikeCrasher.SetSpeed(Vector2.right);
		}

		if (random == 1)
		{
			position.x = screenSize.x + spikeCrasher.size / 2 + spawnDistance;
			position.y = Random.Range(cageSpawner.yCageBorders.x + spikeCrasher.size / 2, cageSpawner.yCageBorders.y - spikeCrasher.size / 2);
			exclamation.x = screenSize.x - exclamationDistance;
			exclamation.y = position.y;
			spikeCrasher.SetSpeed(Vector2.left);
		}

		return (position, exclamation);
	}
}
