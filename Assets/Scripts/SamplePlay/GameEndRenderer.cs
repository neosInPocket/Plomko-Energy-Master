using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;

public class GameEndRenderer : MonoBehaviour
{
	[SerializeField] private TMP_Text endText;
	[SerializeField] private TMP_Text emeraldsText;
	[SerializeField] private TMP_Text clickText;

	public void Renderer(bool value, int emeralds)
	{
		gameObject.SetActive(true);

		if (value)
		{
			endText.text = "COMPLETED!";
			emeraldsText.text = emeralds.ToString();
			clickText.text = "TAP TO CONTINUE";
		}
		else
		{
			endText.text = "YOU LOSE";
			emeraldsText.text = "0";
			clickText.text = "TAP TO RESTART LEVEL";
		}
	}

	public void LoadNext()
	{
		SceneManager.LoadScene("SampleMenu");
	}

	public void TapHandler()
	{
		SceneManager.LoadScene("SampleGame");
	}
}
