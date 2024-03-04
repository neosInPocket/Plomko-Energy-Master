using System.Collections.Generic;
using UnityEngine;

public class CageSpawner : MonoBehaviour
{
	[SerializeField] private CageElement cageElement;
	[SerializeField] private BallsPartition ballsPartition;
	[SerializeField] private float topCageYSpawnPosition;
	[SerializeField] private float elementWidth;
	[SerializeField] private ControlBall controlBall;
	[SerializeField] private MirrorBall mirrorBall;
	private List<CageElement> elements;
	public Vector2 yCageBorders { get; set; }

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
		yCageBorders = new Vector2(screenSize.y * topCageYSpawnPosition - screenSize.y, 2 * screenSize.y * topCageYSpawnPosition - screenSize.y);

		SetPosition(0, leftPosition, leftSize);
		SetPosition(1, rightPosition, leftSize);
		SetPosition(2, topPosition, topSize);
		SetPosition(3, bottomPosition, topSize);

		ballsPartition.Initialize(new Vector2(0, screenSize.y * topCageYSpawnPosition - screenSize.y));
		mirrorBall.Initialize(3 * screenSize.y * topCageYSpawnPosition / 2 - screenSize.y);

		controlBall.Initialize(screenSize.y * topCageYSpawnPosition / 2 - screenSize.y, mirrorBall.transform.position.y);
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

	public static Vector2 FingerPositionToWorld(Vector2 screenPosition)
	{
		var screenSize = ScreenSize();

		var xRatio = screenPosition.x / Screen.width;
		var yRatio = screenPosition.y / Screen.height;
		var xCoord = 2 * xRatio * screenSize.x - screenSize.x;
		var yCoord = 2 * yRatio * screenSize.y - screenSize.y;

		return new Vector2(xCoord, yCoord);
	}
}
