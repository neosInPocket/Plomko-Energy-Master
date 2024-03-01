using System.Collections.Generic;
using UnityEngine;

public class CageSpawner : MonoBehaviour
{
	[SerializeField] private CageElement cageElement;
	[SerializeField] private BallsPartition ballsPartition;
	[SerializeField] private float topCageYSpawnPosition;
	[SerializeField] private float elementWidth;
	private List<CageElement> elements;

	private void Start()
	{
		elements = new();
		var screenSize = ScreenSize();

		for (int i = 0; i < 4; i++)
		{
			var element = Instantiate(cageElement, transform);
			elements.Add(element);
		}

		var leftSize = new Vector2(elementWidth, 2 * screenSize.y);
		var topSize = new Vector2(2 * screenSize.x, elementWidth);

		var leftPosition = new Vector2(-screenSize.x - elementWidth / 2, 0);
		var rightPosition = new Vector2(screenSize.x + elementWidth / 2, 0);
		var topPosition = new Vector2(0, 2 * screenSize.y * topCageYSpawnPosition - screenSize.y + elementWidth / 2);
		var bottomPosition = new Vector2(0, -screenSize.y - elementWidth / 2);

		SetPosition(0, leftPosition, leftSize);
		SetPosition(1, rightPosition, leftSize);
		SetPosition(2, topPosition, topSize);
		SetPosition(3, bottomPosition, topSize);
	}

	private void SetPosition(int index, Vector2 position, Vector2 size)
	{
		elements[index].transform.position = position;
		elements[index].CageSize = size;
	}

	public static Vector2 ScreenSize()
	{
		float orthoSize = Camera.main.orthographicSize;
		float width = (float)Screen.width / (float)Screen.height * orthoSize;
		return new Vector2(width, orthoSize);
	}
}
