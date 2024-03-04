using UnityEngine;

public class SpikeCrasher : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private PolygonCollider2D polygonCollider;
	[SerializeField] private new Rigidbody2D rigidbody2D;
	[SerializeField] private float angleSpeed;
	[SerializeField] private float[] sizes;
	[SerializeField] private float speed;
	public float size => spriteRenderer.size.x;

	private void Start()
	{
		var size = sizes[SaveScript.data.upgradesMassive[1]];
		spriteRenderer.size = new Vector2(size, size);
	}

	private void Update()
	{
		var angle = transform.eulerAngles;
		angle.z += angleSpeed * Mathf.Deg2Rad;
		transform.eulerAngles = angle;
	}

	public void SetSpeed(Vector2 dir)
	{
		rigidbody2D.velocity = dir * speed;
	}
}
