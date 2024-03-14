using UnityEngine;

public class ControlBall : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private MirrorBall mirrorBall;
	private Vector2 initialPosition;
	private float yOffset;
	private Vector2 currentPosition;
	[SerializeField] private TrailRenderer trailRenderer;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Sprite[] skin;

	private void Start()
	{
		spriteRenderer.sprite = skin[SaveScript.data.currentSkinIndex];
	}

	public void Initialize(float yPosition, float mirrorY)
	{
		transform.position = new Vector2(0, yPosition);
		initialPosition = transform.position;
		yOffset = mirrorY - transform.position.y;
		trailRenderer.Clear();
	}

	private void Update()
	{
		currentPosition = transform.position;
		currentPosition.y += yOffset;

		mirrorBall.transform.position = currentPosition;
	}

	public void AddVelocity(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.transform.position.x == 0)
		{
			rb.velocity = Vector2.Reflect(rb.velocity, Vector2.up);
		}
		else
		{
			rb.velocity = Vector2.Reflect(rb.velocity, Vector2.right);
		}
	}

	public void StopBall()
	{
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
	}
}
