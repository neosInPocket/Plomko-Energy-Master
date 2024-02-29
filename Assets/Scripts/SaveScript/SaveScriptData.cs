using System;

[Serializable]
public class SaveScriptData
{
	public int levelPlayer;
	public int emeralds;
	public int[] upgradesMassive;
	public bool[] soundsEnabled;
	public bool guideEnabled;

	public SaveScriptData()
	{
		levelPlayer = 1;
		emeralds = 1000;
		upgradesMassive = new int[] { 0, 0 };
		soundsEnabled = new bool[] { true, true };
		guideEnabled = true;
	}
}
