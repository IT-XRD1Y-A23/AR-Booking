using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupMenu : MonoBehaviour
{
    public GameObject GroupPanel;
    public TMP_Dropdown GroupDropdown;
    [SerializeField] private TMP_Text GroupText;
    private bool isOpen;
    List<string> Groups = new List<string> { "group 1", "group 2", "group 3", "group 4", "group 5", "group 6" };

    public SettingsData SettingsData;

    void Start()
    {
        isOpen = true;
        GroupPanel.SetActive(isOpen);

        GroupDropdown.AddOptions(Groups);
        GroupText.text = GroupDropdown.options[SettingsData.GroupIndex].text;
        DropdownSelect(SettingsData.GroupIndex);
    }

    public void OpenGroupPanel()
    {
        if (GroupPanel != null)
        {
            isOpen = !isOpen;
            GroupPanel.SetActive(isOpen);
        }
    }

    public void DropdownSelect(int index)
    {
        GroupText.text = GroupDropdown.options[GroupDropdown.value].text;
        SettingsData.Group = GroupDropdown.options[GroupDropdown.value].text;
        SettingsData.GroupIndex = GroupDropdown.value;
        isOpen = !isOpen;
        GroupPanel.SetActive(isOpen);
    }
}
