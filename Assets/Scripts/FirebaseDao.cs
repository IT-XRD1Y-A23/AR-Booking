using System;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class FirebaseDao 
{
    // Database reference used for Firebase operations.
    private readonly DatabaseReference _dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    /// <summary>
    /// Attempts to create a new booking after checking for conflicts.
    /// </summary>
    public void TryCreateBooking(Booking newBooking, Action onSuccess, Action<string> onFailure)
    {
        // First, check for booking conflicts.
        CheckForBookingConflict(newBooking.bookedDate, newBooking, 
            () => 
            {
                // No conflicts, proceed to create the booking.
                DatabaseReference dateRef = _dbReference.Child("bookings").Child(newBooking.bookedDate);
                string bookingJson = JsonUtility.ToJson(newBooking);
            
                dateRef.Push().SetRawJsonValueAsync(bookingJson).ContinueWith(bookingTask => 
                {
                    if (bookingTask.IsFaulted)
                    {
                        onFailure?.Invoke($"Booking creation failed: {bookingTask.Exception}");
                    }
                    else
                    {
                        onSuccess?.Invoke();
                    }
                });
            },
            onFailure
        );
    }


    /// <summary>
    /// Checks if there's a booking conflict for the specified date and booking details.
    /// </summary>
    private void CheckForBookingConflict(string date, Booking newBooking, Action onSuccess, Action<string> onFailure)
    {
        DatabaseReference dateRef = _dbReference.Child("bookings").Child(date);

        dateRef.GetValueAsync().ContinueWith(task => 
        {
            if (task.IsFaulted)
            {
                onFailure?.Invoke($"Failed to retrieve existing bookings: {task.Exception}");
                return;
            }

            DataSnapshot snapshot = task.Result;
            foreach (var child in snapshot.Children)
            {
                Booking existingBooking = JsonUtility.FromJson<Booking>(child.GetRawJsonValue());
            
                if (existingBooking.workstationNumber == newBooking.workstationNumber && existingBooking.timeslot == newBooking.timeslot)
                {
                    onFailure?.Invoke("Booking conflict: Workstation already booked for this timeslot.");
                    return;
                }
            }

            // If no conflicts found, invoke the success callback.
            onSuccess?.Invoke();
        });
    }
    
    /// <summary>
    /// Retrieves all bookings stored in the database.
    /// </summary>
    public void FetchAllBookings(Action<List<Booking>> onSuccess, Action<AggregateException> onFailure)
    {
        _dbReference.Child("bookings").GetValueAsync().ContinueWith(task => 
        {
            if (task.IsFaulted)
            {
                onFailure?.Invoke(task.Exception);
                return;
            }

            DataSnapshot snapshot = task.Result;
            List<Booking> allBookings = new List<Booking>();

            // Extract all bookings from the snapshot.
            foreach (DataSnapshot dateSnapshot in snapshot.Children)
            {
                foreach (DataSnapshot bookingSnapshot in dateSnapshot.Children)
                {
                    Booking booking = JsonUtility.FromJson<Booking>(bookingSnapshot.GetRawJsonValue());
                    booking.id = bookingSnapshot.Key; // Assign the Firebase-generated ID.
                    allBookings.Add(booking);
                }
            }

            onSuccess?.Invoke(allBookings);
        });
    }

    /// <summary>
    /// Retrieves all bookings for a specified date.
    /// </summary>
    public void FetchBookingsForDate(string date, Action<List<Booking>> onSuccess, Action<AggregateException> onFailure)
    {
        _dbReference.Child("bookings").Child(date).GetValueAsync().ContinueWith(task => 
        {
            if (task.IsFaulted)
            {
                onFailure?.Invoke(task.Exception);
                return;
            }

            DataSnapshot snapshot = task.Result;
            List<Booking> bookingsForDate = new List<Booking>(); // Renamed for clarity.

            // Parse the snapshot to extract booking details.
            foreach (DataSnapshot bookingSnapshot in snapshot.Children)
            {
                Booking booking = JsonUtility.FromJson<Booking>(bookingSnapshot.GetRawJsonValue());
                booking.id = bookingSnapshot.Key; // Assign the Firebase-generated ID.
                bookingsForDate.Add(booking);
            }

            onSuccess?.Invoke(bookingsForDate);
        });
    }
    
    /// <summary>
    /// Deletes a specific booking from the database.
    /// </summary>
    public void DeleteBooking(string date, string bookingId, Action onSuccess, Action<string> onFailure)
    {
        // Null checks to prevent any null reference exception.
        if (string.IsNullOrEmpty(date) || string.IsNullOrEmpty(bookingId))
        {
            onFailure?.Invoke("Invalid booking data.");
            return;
        }

        // Reference to the specific booking based on its unique ID and the date.
        DatabaseReference bookingRef = _dbReference.Child("bookings").Child(date).Child(bookingId);

        // Attempt to remove the booking.
        bookingRef.RemoveValueAsync().ContinueWith(task => 
        {
            if (task.IsFaulted)
            {
                onFailure?.Invoke($"Failed to delete booking: {task.Exception}");
            }
            else
            {
                onSuccess?.Invoke(); // Notify of successful deletion.
            }
        });
    }
}


