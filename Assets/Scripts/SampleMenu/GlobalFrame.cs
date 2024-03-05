using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalFrame : MonoBehaviour
{
	[SerializeField] private List<Image> medals;
	[SerializeField] private Color offColor;
	[SerializeField] private Button buy;
	[SerializeField] private int upgradeIndex;
	[SerializeField] private TMP_Text priceText;
	[SerializeField] private int price;
	[SerializeField] private TMP_Text buyButtonText;
	private int Upgraded
	{
		get => upgraded;
		set
		{
			upgraded = value;

			medals.ForEach(x => x.color = offColor);

			for (int h = 0; h < value; h++)
			{
				medals[h].color = Color.white;
			}
		}
	}

	private int upgraded;

	public void RefreshUpgradeFrame()
	{
		priceText.text = price.ToString();
		Upgraded = SaveScript.data.upgradesMassive[upgradeIndex];

		if (SaveScript.data.upgradesMassive[upgradeIndex] > 3)
		{
			buyButtonText.text = "UPGRADED";
			buy.interactable = false;
			buyButtonText.color = Color.green;
		}
		else
		{
			if (SaveScript.data.emeralds < price)
			{
				buyButtonText.text = "NO GEMS";
				buy.interactable = false;
				buyButtonText.color = Color.red;
			}
			else
			{
				buyButtonText.text = "UPGRADE";
				buy.interactable = true;
				buyButtonText.color = Color.white;
			}
		}
	}

	public void Upgrade()
	{
		SaveScript.data.upgradesMassive[upgradeIndex]++;
		SaveScript.data.emeralds -= price;
		SaveScript.DataSave();
	}
}
