using System;
using System.Collections;
using UnityEngine;

public class MirrorBall : MonoBehaviour
{
	[SerializeField] private GameObject deathEffect;
	[SerializeField] private ControlBall controlBall;
	[SerializeField] private SpriteRenderer spriteRenderer;
	public Action OnTriggerEnter { get; set; }
	public Action CoinCollected { get; set; }
	[SerializeField] private TrailRenderer trailRenderer;
	[SerializeField] private Sprite[] skin;

	private void Start()
	{
		spriteRenderer.sprite = skin[SaveScript.data.currentSkinIndex];
	}

	public void Initialize(float yPosition)
	{
		transform.position = new Vector2(0, yPosition);
		trailRenderer.Clear();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<EmeraldObject>(out EmeraldObject component))
		{
			CoinCollected?.Invoke();
			component.OnCollect();
			return;
		}

		if (collider.TryGetComponent<SpikeCrasher>(out SpikeCrasher spike))
		{
			OnTriggerEnter?.Invoke();
			destroy();
			return;
		}
	}

	private void destroy()
	{
		controlBall.StopBall();
		spriteRenderer.enabled = false;
		deathEffect.gameObject.SetActive(true);
	}
}
