using UnityEngine;
using UnityEngine.UI;

public class MainStatusUI : MonoBehaviour
{
	[Header("Status Events")]
	[SerializeField] GameObject StatusUI;
	[SerializeField] Button openStatusButton;
	[SerializeField] Button closeStatusButton;

	void Start()
	{
		AddStatusEvents();
	}

	void AddStatusEvents()
	{
		openStatusButton.onClick.RemoveAllListeners();
		openStatusButton.onClick.AddListener(OpenStatus);

		closeStatusButton.onClick.RemoveAllListeners();
		closeStatusButton.onClick.AddListener(CloseStatus);
	}

	void OpenStatus()
	{
		StatusUI.SetActive(true);
	}

	void CloseStatus()
	{
		StatusUI.SetActive(false);
	}
}