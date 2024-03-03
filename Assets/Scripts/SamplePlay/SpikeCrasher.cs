using UnityEngine;

public class SpikeCrasher : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private PolygonCollider2D polygonCollider;
	[SerializeField] private float[] sizes;

	private void Start()
	{
		var size = sizes[SaveScript.data.upgradesMassive[1]];
		spriteRenderer.size = new Vector2(size, size);
	}
}
