using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntryLoader : MonoBehaviour
{
	[SerializeField] private string sceneName;

	public void Entry()
	{
		SceneManager.LoadScene(sceneName);
	}
}
