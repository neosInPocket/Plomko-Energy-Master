using System.IO;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
	[SerializeField] private bool clearPresets;
	[SerializeField] private string fileName;
	private static string pathFile;
	public static SaveScriptData data;

	private void Awake()
	{
		pathFile = Application.persistentDataPath + fileName + ".json";

		if (clearPresets)
		{
			GetDefaultData();

		}
		else
		{
			LoadFile();
		}
	}

	public static void DataSave()
	{
		if (File.Exists(pathFile))
		{
			SetFileData();

		}
		else
		{
			NewFileData();
		}
	}

	private void LoadFile()
	{
		if (File.Exists(pathFile))
		{
			LoadFileFromDisk();

		}
		else
		{
			NewFileData();
		}
	}

	private void GetDefaultData()
	{
		NewFileData();
	}

	private static void NewFileData()
	{
		data = new SaveScriptData();
		File.WriteAllText(pathFile, JsonUtility.ToJson(data));
	}

	private static void SetFileData()
	{
		File.WriteAllText(pathFile, JsonUtility.ToJson(data));
	}

	private static void LoadFileFromDisk()
	{
		string file = File.ReadAllText(pathFile);
		data = JsonUtility.FromJson<SaveScriptData>(file);
	}
}
