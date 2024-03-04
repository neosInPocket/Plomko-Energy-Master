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
		var activeSoundHandler = foundOne.FirstOrDefault(x => x.gameObject.scene.name == "DontDestroyOnLoad");
		var nonMine = foundOne.FirstOrDefault(x => x.gameObject.scene.name != "DontDestroyOnLoad");

		if (activeSoundHandler != null)
		{
			Destroy(nonMine.gameObject);
		}
		else
		{
			DontDestroyOnLoad(nonMine.gameObject);
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
