using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.Text.RegularExpressions;
public class RadioButtonSystem : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public GameObject[] toggles;
    public TextMeshProUGUI dateLabel;

    string pattern = @"8:00-12:00|12:00-16:00|16:00-00:00";
   
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    public void Submit()
    { Regex regex = new Regex(pattern);
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        for(int i=0; i<toggles.Length; i++){
            if(toggles[i].GetComponent<Toggle>().isOn){
                if(regex.IsMatch(dateLabel.text)){
                    Debug.Log("matchers");
                dateLabel.text= dateLabel.text.Substring(0,dateLabel.text.Length-12);


                }
             
                dateLabel.text += " "+toggles[i].GetComponentInChildren<Text>().text;
            
            }
        }
        }
}
