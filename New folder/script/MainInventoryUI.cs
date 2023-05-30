using UnityEngine;
using UnityEngine.UI;

public class MainInventoryUI : MonoBehaviour
{
	[Header("Inventory Events")]
	[SerializeField] GameObject InventoryUI;
	[SerializeField] Button openInventoryButton;
	[SerializeField] Button closeInventoryButton;

	void Start()
	{
		AddInventoryEvents();
	}

	void AddInventoryEvents()
	{
		openInventoryButton.onClick.RemoveAllListeners();
		openInventoryButton.onClick.AddListener(OpenInventory);

		closeInventoryButton.onClick.RemoveAllListeners();
		closeInventoryButton.onClick.AddListener(CloseInventory);
	}

	void OpenInventory()
	{
		InventoryUI.SetActive(true);
	}

	void CloseInventory()
	{
		InventoryUI.SetActive(false);
	}
}