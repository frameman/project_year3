using UnityEngine;
using UnityEngine.UI;

public class MainSettingUI : MonoBehaviour
{
	[Header("Setting Events")]
	[SerializeField] GameObject SettingUI;
	[SerializeField] Button openSettingButton;
	[SerializeField] Button closeSettingButton;

	void Start()
	{
		AddSettingEvents();
	}

	void AddSettingEvents()
	{
		openSettingButton.onClick.RemoveAllListeners();
		openSettingButton.onClick.AddListener(OpenSetting);

		closeSettingButton.onClick.RemoveAllListeners();
		closeSettingButton.onClick.AddListener(CloseSetting);
	}

	void OpenSetting()
	{
		SettingUI.SetActive(true);
	}

	void CloseSetting()
	{
		SettingUI.SetActive(false);
	}
}