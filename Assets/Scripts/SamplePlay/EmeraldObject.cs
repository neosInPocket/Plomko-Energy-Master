using System;
using System.Collections;
using UnityEngine;

public class EmeraldObject : MonoBehaviour
{
	[SerializeField] private GameObject collectEffect;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject effect;
	public SpriteRenderer SP => spriteRenderer;
	public bool isCollected { get; set; }
	public Action OnCollected { get; set; }

	public void OnCollect()
	{
		if (isCollected) return;
		OnCollected?.Invoke();
		isCollected = true;
		StartCoroutine(collect());
	}

	private IEnumerator collect()
	{
		effect.gameObject.SetActive(false);
		spriteRenderer.color = new Color(0, 0, 0, 0);
		var collected = Instantiate(collectEffect, transform.position, Quaternion.identity, transform);
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
