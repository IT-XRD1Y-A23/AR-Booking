using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseInit : MonoBehaviour
{
    private string userID;
    private DatabaseReference dbReference;
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            Debug.Log(task.Exception != null ? $"Firebase failed to init - {task.Exception}" : "Firebase initialized");
        });

        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    public void CreateBooking()
    {
        print("Hello");
       
        var date = DateTime.Now.ToString("dd_MM_yyyy");
        var b1 = new Booking(1, DateTime.Now.ToString(),  1, "y2");
        var json = JsonUtility.ToJson(b1);
        dbReference.Child("bookings").Child(date).SetRawJsonValueAsync(json);
      
    }
}
