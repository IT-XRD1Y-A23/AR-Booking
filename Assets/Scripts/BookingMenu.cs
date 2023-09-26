using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BookingMenu : MonoBehaviour
{
    public GameObject BookingPanel;
    public TMP_Text BookingText;
    private bool isOpen;
    List<string> Groups = new List<string> { "Booking 1", "Booking 2", "Booking 3", "Booking 4"};

    void Start()
    {
        isOpen = false;
        BookingPanel.SetActive(isOpen);
        BookingText.text = "";
    }

    void Update()
    {
        if(isOpen == false)
        {
            BookingText.text = "";
        }
    }

    public void OpenBookingPanel()
    {
        if(BookingPanel != null)
        {
            isOpen = !isOpen;
            BookingPanel.SetActive(isOpen);
            foreach (string booking in Groups)
            {
                BookingText.text += booking+"<br><br>";
            }
        }
    }
}
