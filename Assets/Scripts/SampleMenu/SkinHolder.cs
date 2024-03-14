using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinHolder : MonoBehaviour
{
	[SerializeField] private int skinNumber;
	[SerializeField] private Button button;
	[SerializeField] private TMP_Text avaliableText;
	[SerializeField] private int skinCost;
	[SerializeField] private TMP_Text skinCostText;
	[SerializeField] private GameObject skinCheck;
	[SerializeField] private GameObject moneyCheckObject;
	[SerializeField] private SkinsCounter skinsCounter;
	public int SkinIndex => skinNumber;

	private void Start()
	{
		SetDefaultStoreValues();
	}

	public void SetDefaultStoreValues()
	{
		skinCostText.text = skinCost.ToString();
		//Upgraded = SaveScript.data.upgradesMassive[upgradeIndex];

		if (SaveScript.data.currentSkinIndex == skinNumber)
		{
			skinCheck.gameObject.SetActive(true);
			moneyCheckObject.gameObject.SetActive(false);
			avaliableText.text = "EQUIPPED";
			avaliableText.color = Color.yellow;

			button.interactable = false;
		}
		else
		{
			if (SaveScript.data.skinMassive[skinNumber])
			{
				skinCheck.gameObject.SetActive(true);
				moneyCheckObject.gameObject.SetActive(false);
				avaliableText.text = "PURCHASED";
				avaliableText.color = Color.green;

				button.interactable = true;
			}
			else
			{
				if (SaveScript.data.emeralds < skinCost)
				{
					skinCheck.gameObject.SetActive(false);
					moneyCheckObject.gameObject.SetActive(true);
					avaliableText.text = "NOT ENOUGH GEMS";
					avaliableText.color = Color.red;

					button.interactable = false;
				}
				else
				{
					skinCheck.gameObject.SetActive(false);
					moneyCheckObject.gameObject.SetActive(true);
					avaliableText.text = "AVALIABLE";
					avaliableText.color = Color.white;

					button.interactable = true;
				}
			}
		}
	}

	public void PurchaseSkin()
	{
		SaveScript.data.emeralds -= skinCost;
		SaveScript.data.skinMassive[skinNumber] = true;
		SaveScript.DataSave();

		skinsCounter.RefreshAllSkins();
	}
}