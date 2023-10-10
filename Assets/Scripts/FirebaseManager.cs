using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FirebaseManager
{
    private DatabaseReference dbReference;

    public void BookWorkstation(Booking booking, Action<bool> callback)
    {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        var task = dbReference.Child("bookings").Child(booking.bookedDate.ToString("dd-MM-yyyy"))
            .Child(booking.timeslot.ToString()).Child(booking.workstationNumber.ToString()).SetRawJsonValueAsync(booking.groupNumber);

        task.ContinueWith(t =>
        {
            if (t.IsFaulted || t.IsCanceled)
            {
                Debug.LogError("Failed to book workstation: " + t.Exception);
                callback?.Invoke(false);
            }
            else
            {
                callback?.Invoke(true);
            }
        });
    }

    public bool DeleteBooking(Booking booking)
    {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        dbReference.Child("bookings").Child("04-10-2023")
            .Child("1").Child("1").GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Debug.LogError("Failed to retrieve booking: " + task.Exception);

                }
                else
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Exists)
                    {
                        int groupNumber = int.Parse(snapshot.Value.ToString());
                        Debug.Log(groupNumber);
                    }
                }
            });
        return true;
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (e.DatabaseError != null)
        {
            throw new NotImplementedException();
        }

    }

    public List<Booking> GetAllBookings()
    {
        throw new NotImplementedException();
    }

    public List<Booking> GetAllBookingsForDay(DateTime date)
    {
        throw new NotImplementedException();
    }
}