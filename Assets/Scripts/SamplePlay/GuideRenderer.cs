using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class GuideRenderer : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private TMP_Text text;
	[SerializeField] private List<string> charactedBlocks;
	[SerializeField] private BootstrapManager bootstrapManager;
	private int currentCharacterCounter;

	private void Awake()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		currentCharacterCounter = 0;
	}

	public void Renderer()
	{
		gameObject.SetActive(true);

		Touch.onFingerDown += CharacterAction;
	}

	private void CharacterAction(Finger finger)
	{
		text.text = charactedBlocks[currentCharacterCounter];
		animator.SetTrigger(currentCharacterCounter.ToString());
		currentCharacterCounter++;
	}

	public void OnEnd()
	{
		Touch.onFingerDown -= CharacterAction;
		bootstrapManager.OnGameEndRenderer();
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= CharacterAction;
	}
}
