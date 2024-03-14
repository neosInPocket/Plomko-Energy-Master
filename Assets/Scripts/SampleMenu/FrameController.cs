using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour
{
	[SerializeField] private List<GlobalFrame> frames;
	[SerializeField] private List<SkinHolder> SkinHolders;
	[SerializeField] private List<MainMenuInfoRefresher> refreshers;

	private void Start()
	{
		RestartForEachInfo();
	}

	public void RestartForEachInfo()
	{
		refreshers.ForEach(x => x.RefreshInfo());
		frames.ForEach(x => x.RefreshUpgradeFrame());
		SkinHolders.ForEach(x => x.SetDefaultStoreValues());
	}

	public void Upgrade(int index)
	{
		frames[index].GetUpgrade();
		RestartForEachInfo();
	}
}
