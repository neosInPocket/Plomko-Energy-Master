using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
	[SerializeField] private Image[] buttons;
	[SerializeField] Color soundOffColor;
	[SerializeField] Color defaultColor;
	private SoundsHandler soundsHandler;

	private void Start()
	{
		soundsHandler = FindFirstObjectByType<SoundsHandler>();

		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].color = SaveScript.data.soundsEnabled[i] ? defaultColor : soundOffColor;
		}
	}

	public void SetSoundEnabled(int index)
	{
		var value = SaveScript.data.soundsEnabled[index];
		SaveScript.data.soundsEnabled[index] = !value;
		SaveScript.DataSave();

		buttons[index].color = SaveScript.data.soundsEnabled[index] ? defaultColor : soundOffColor;

		if (index == 0)
		{
			soundsHandler.SetEnabledValues(!value);
		}
	}
}
