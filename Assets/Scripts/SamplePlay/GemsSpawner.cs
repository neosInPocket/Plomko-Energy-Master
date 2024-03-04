using System.Collections;
using UnityEngine;

public class GemsSpawner : MonoBehaviour
{
	[SerializeField] private EmeraldObject emeraldPrefab;
	[SerializeField] private EmeraldObject startEmerald;
	[SerializeField] private CageSpawner cageSpawner;
	private Vector2 screenSize;
	private EmeraldObject currentEmerald;


	private void Awake()
	{
		screenSize = CageSpawner.ScreenSize();
		currentEmerald = startEmerald;
		startEmerald.OnCollected += OnPrevEmeraldCollected;
	}

	private void OnPrevEmeraldCollected()
	{
		currentEmerald.OnCollected -= OnPrevEmeraldCollected;

		Vector2 emeraldPosition = GetEmeraldSpawnPosition();
		var emerald = Instantiate(emeraldPrefab, emeraldPosition, Quaternion.identity, transform);
		currentEmerald = emerald;
		emerald.OnCollected += OnPrevEmeraldCollected;
	}

	private Vector2 GetEmeraldSpawnPosition()
	{
		Vector2 position = new Vector2();

		var size = emeraldPrefab.SP.size.x;

		position.x = Random.Range(-screenSize.x + size / 2, screenSize.x - size / 2);
		position.y = Random.Range(cageSpawner.yCageBorders.x + size / 2, cageSpawner.yCageBorders.y - size / 2);

		return position;
	}
}
