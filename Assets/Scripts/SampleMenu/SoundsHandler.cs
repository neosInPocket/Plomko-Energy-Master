using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
	[SerializeField] private int index;
	[SerializeField] private AudioSource musicSource;

	private void Awake()
	{
		index++;

		SoundsHandler[] foundOne = FindObjectsByType<SoundsHandler>(sortMode: FindObjectsSortMode.None);

		for (int i = 0; i < foundOne.Length; i++)
		{
			if (foundOne[i].gameObject.scene.name != "DontDestroyOnLoad")
			{
				if (foundOne[i] != this)
				{
					Destroy(foundOne[i].gameObject);
				}
				else
				{
					DontDestroyOnLoad(this.gameObject);
				}
			}
		}
	}

	private void Start()
	{
		SetEnabledValues(SaveScript.data.soundsEnabled[0]);
	}

	public void SetEnabledValues(bool valueEnabled)
	{
		musicSource.volume = !valueEnabled ? 0f : 1f;
	}
}
