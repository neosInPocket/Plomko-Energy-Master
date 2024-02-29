using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuInfoRefresher : MonoBehaviour
{
	[SerializeField] private List<TMP_Text> emeralds;
	[SerializeField] private List<TMP_Text> level;

	private void Start()
	{
		RefreshInfo();
	}

	public void RefreshInfo()
	{
		emeralds.ForEach(x => x.text = SaveScript.data.emeralds.ToString());
		level.ForEach(x => x.text = "LEVEL: " + SaveScript.data.levelPlayer.ToString());
	}
}
