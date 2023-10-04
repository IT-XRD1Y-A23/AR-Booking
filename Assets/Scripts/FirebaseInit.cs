using System;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
   
    private DatabaseReference dbReference;
    

    private async void Start()
    {

        await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            Debug.Log(task.Exception != null ? $"Firebase failed to init - {task.Exception}" : "Firebase initialized");
        });
        
        while (FirebaseDatabase.DefaultInstance.RootReference == null)
        {
            print("Firebase is busy");
        }
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    public void CreateBooking()
    {
        var date = DateTime.Now.ToString("dd_MM_yyyy");
        var b1 = new Booking(1, DateTime.Now.ToString(),  1, "y2");
        var json = JsonUtility.ToJson(b1);
        dbReference.Child("bookings").Child(date).SetRawJsonValueAsync(json);
      
    }
}
