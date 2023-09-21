using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookingMenu : MonoBehaviour
{
    public GameObject BookingPanel;
    private bool isOpen;

    void Start()
    {
        isOpen = false;
        BookingPanel.SetActive(isOpen);
    }

    public void OpenBookingPanel()
    {
        if(BookingPanel != null)
        {
            isOpen = !isOpen;
            BookingPanel.SetActive(isOpen);
        }
    }
}
