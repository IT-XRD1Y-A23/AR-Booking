using System;
using UnityEngine;
using TMPro;
public class DateDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    string currentDate = DateTime.Now.ToString("ddd, dd MMM");
    // Start is called before the first frame update
    void Start()
    {
        text = FindObjectOfType<TextMeshProUGUI>();
        text.text = currentDate +" 8:00-12:00";

    }
}
