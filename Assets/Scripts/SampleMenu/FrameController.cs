using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour
{
	[SerializeField] private List<GlobalFrame> frames;
	[SerializeField] private List<MainMenuInfoRefresher> refreshers;

	private void Start()
	{
		RestartForEachInfo();
	}

	private void RestartForEachInfo()
	{
		refreshers.ForEach(x => x.RefreshInfo());

		frames.ForEach(x => x.RefreshUpgradeFrame());
	}

	public void Upgrade(int index)
	{
		frames[index].Upgrade();
		RestartForEachInfo();
	}
}
