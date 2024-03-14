using System;

[Serializable]
public class SaveScriptData
{
	public int levelPlayer;
	public int emeralds;
	public int[] upgradesMassive;
	public bool[] skinMassive;
	public bool[] soundsEnabled;
	public bool guideEnabled;
	public int currentSkinIndex;

	public SaveScriptData()
	{
		levelPlayer = 1;
		emeralds = 10;
		upgradesMassive = new int[] { 0, 0 };
		skinMassive = new bool[] { true, false, false };
		soundsEnabled = new bool[] { true, true };
		currentSkinIndex = 0;
		guideEnabled = true;
	}
}
