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
    List<string> classes = new List<string> { "class 1", "class 2", "class 3", "class 4", "class 5", "class 6" };

    void Start()
    {
        isOpen = false;
        GroupPanel.SetActive(isOpen);

        GroupDropdown.AddOptions(classes);
        GroupText.text = GroupDropdown.options[GroupDropdown.value].text;
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
    }
}
