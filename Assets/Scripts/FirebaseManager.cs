using System;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class FirebaseManager : IFirebaseManager
{
    private DatabaseReference dbReference;
    
    public bool BookWorkstation(Booking booking)
    {
        Debug.Log("HEllO");
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        
        Debug.Log(dbReference);
        
        var json = JsonUtility.ToJson(booking.groupNumber);
        Debug.Log(json);
        
        dbReference.Child("bookings").Child(booking.bookedDate.ToString("dd-MM-yyyy"))
            .Child(booking.timeslot.ToString()).Child(booking.workstationNumber.ToString()).SetRawJsonValueAsync(booking.groupNumber);

        return true;
    }

    public bool DeleteBooking(Booking booking)
    {
        throw new NotImplementedException();
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
