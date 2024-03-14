using System.Collections.Generic;
using UnityEngine;

public class SkinsCounter : MonoBehaviour
{
	[SerializeField] private FrameController frameController;

	private void Start()
	{
		RefreshAllSkins();
	}

	public void RefreshAllSkins()
	{
		frameController.RestartForEachInfo();
	}

	public void SelectCurrentSkin(SkinHolder skinHolder)
	{
		SaveScript.data.currentSkinIndex = skinHolder.SkinIndex;
		SaveScript.DataSave();

		RefreshAllSkins();
	}
}

