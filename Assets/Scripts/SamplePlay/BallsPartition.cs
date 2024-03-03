using UnityEngine;

public class BallsPartition : MonoBehaviour
{
	[SerializeField] private Transform top;
	[SerializeField] private Transform bottom;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private float height;

	public void Initialize(Vector2 position)
	{
		var screenSize = CageSpawner.ScreenSize();
		var scale = transform.localScale;
		scale.x = screenSize.x;

		transform.position = position;

		spriteRenderer.size = new Vector2(2 * screenSize.x, height);
	}
}
