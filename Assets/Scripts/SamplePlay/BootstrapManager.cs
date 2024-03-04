using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BootstrapManager : MonoBehaviour
{
	[SerializeField] private ControlBall controlBall;
	[SerializeField] private MirrorBall mirrorBall;
	[SerializeField] private ImpulseSpawner impulseSpawner;
	[SerializeField] private SpikesSpawner spikesSpawner;
	[SerializeField] private TMP_Text infoText;
	[SerializeField] private TMP_Text levelvalue;
	[SerializeField] private Image innerImage;
	[SerializeField] private GuideRenderer guideRenderer;
	[SerializeField] private GameEndRenderer gameEndRenderer;
	[SerializeField] private Animator cdAnimator;
	[SerializeField] private TMP_Text cdTExt;
	private int goalEmeralds;
	private int currentEmeraldsCollected;

	private void Start()
	{
		goalEmeralds = SaveScript.data.levelPlayer * 2 + 1;
		currentEmeraldsCollected = 0;

		levelvalue.text = "LEVEL " + SaveScript.data.levelPlayer.ToString();
		infoText.text = currentEmeraldsCollected.ToString() + "/" + goalEmeralds.ToString();
		innerImage.fillAmount = (float)currentEmeraldsCollected / (float)goalEmeralds;

		if (SaveScript.data.guideEnabled)
		{
			SaveScript.data.guideEnabled = false;
			SaveScript.DataSave();
			guideRenderer.Renderer();
		}
		else
		{
			OnGameEndRenderer();
		}
	}

	public void OnGameEndRenderer()
	{
		cdAnimator.SetTrigger("CD");
	}

	private void OnGameStart()
	{
		impulseSpawner.Enable(true);
		spikesSpawner.Enable(true);

		mirrorBall.OnTriggerEnter += OnMirrorBallTriggerEnter;
		mirrorBall.CoinCollected += OnCoinCollected;
	}

	private void OnMirrorBallTriggerEnter()
	{
		EndGameProcess(false);
	}

	private void OnCoinCollected()
	{
		currentEmeraldsCollected++;
		bool goalReached = currentEmeraldsCollected >= goalEmeralds ? true : false;

		if (goalReached)
		{
			EndGameProcess(true);
		}

		infoText.text = currentEmeraldsCollected.ToString() + "/" + goalEmeralds.ToString();
		innerImage.fillAmount = (float)currentEmeraldsCollected / (float)goalEmeralds;
	}

	private void EndGameProcess(bool win)
	{
		controlBall.StopBall();
		mirrorBall.OnTriggerEnter -= OnMirrorBallTriggerEnter;
		mirrorBall.CoinCollected -= OnCoinCollected;

		if (win)
		{
			SaveScript.data.levelPlayer++;
			SaveScript.data.emeralds += goalEmeralds;
			SaveScript.DataSave();
		}

		gameEndRenderer.Renderer(win, goalEmeralds);
	}

	private void OnDestroy()
	{
		mirrorBall.OnTriggerEnter -= OnMirrorBallTriggerEnter;
	}

	public void ChangeCDText(string text)
	{
		cdTExt.text = text;
	}
}
