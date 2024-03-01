using UnityEngine;

public class CageElement : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	public Vector2 CageSize
	{
		get => spriteRenderer.size;
		set => spriteRenderer.size = value;
	}
}
