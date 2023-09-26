using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class RadioButtonSystem : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public GameObject[] toggles;
    public TextMeshProUGUI dateLabel;


    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        for(int i=0; i<toggles.Length; i++){
            if(toggles[i].GetComponent<Toggle>().isOn){
                dateLabel.text = toggles[i].GetComponentInChildren<Text>().text;
            }
        }
        }
}
