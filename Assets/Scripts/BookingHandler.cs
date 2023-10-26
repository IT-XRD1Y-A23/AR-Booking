using System;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class BookingHandler : MonoBehaviour
{
    // Reference to our custom Firebase Data Access Object, used for Firebase operations.
    private FirebaseDao _firebaseDao = new(); 

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start() 
    {
        // Initialize Firebase dependencies and services.
        InitializeFirebase();
    }

    /// <summary>
    /// Initializes Firebase services, ensuring all dependencies are available.
    /// </summary>
    private void InitializeFirebase()
    {
        // Asynchronously check and fix any Firebase dependencies issues.
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                // Log an error if Firebase initialization fails.
                Debug.LogError($"Failed to initialize Firebase: {task.Exception}");
                return;
            }

            // Notify successful Firebase initialization.
            Debug.Log("Firebase initialized successfully.");

            // Instantiate the Firebase DAO now that Firebase services are available.
            _firebaseDao = new FirebaseDao();
        });
    }

    /// <summary>
    /// Attempts to create a booking with predetermined details.
    /// In a real-world application, booking details would likely come from user input.
    /// </summary>
    public void TryCreateBooking() 
    {
        // Prepare a new booking instance with example details.
        Booking newBooking = new Booking("5", new DateTime(2023,10,26), TimeSlot.Evening, "11");

        // Attempt to create the booking in Firebase.
        _firebaseDao.TryCreateBooking(newBooking, 
            () => 
            {
                // Success callback: Log a success message.
                Debug.Log("Booking succeeded!");
            },
            errorMessage => 
            {
                // Failure callback: Log the received error message.
                Debug.LogError($"Booking failed: {errorMessage}");
            }
        );
    }
    
    /// <summary>
    /// Retrieves and logs all bookings from the Firebase database.
    /// </summary>
    public void FetchAllBookings() 
    {
        // Request all bookings from Firebase.
        _firebaseDao.FetchAllBookings(
            allBookings => 
            {
                // Success callback: Log each retrieved booking for verification.
                foreach (var booking in allBookings)
                {
                    Debug.Log($"Retrieved booking for group: {booking.groupNumber} Workstation: {booking.workstationNumber} Date: {booking.bookedDate} ID: {booking.id}" );
                }
            },
            error => 
            {
                // Failure callback: Log the error for debugging purposes.
                Debug.LogError($"Error retrieving bookings: {error}");
            }
        );
    }

    /// <summary>
    /// Retrieves and logs all bookings for a specific date.
    /// </summary>
    public IEnumerable<Booking> FetchBookingsForDate(DateTime specificDate) 
    {
     
        var myBookingList = new List<Booking>();
        // Request bookings for the specified date from Firebase.
        Debug.Log(specificDate.ToString("dd-MM-yyyy"));
        Debug.Log(_firebaseDao);
        _firebaseDao.FetchBookingsForDate(specificDate.ToString("dd-MM-yyyy"), 
            bookingsList => 
            {
                // Success callback: Log each retrieved booking for verification.
                foreach (var booking in bookingsList)
                {
                    Debug.Log($"Retrieved booking for group: {booking.groupNumber} {booking.id}");
                }

                myBookingList = bookingsList;
            },
            error => 
            {
                // Failure callback: Log the error for debugging purposes.
                Debug.LogError($"Error retrieving bookings for {specificDate}: {error}");
            }
        );

        return myBookingList;
    }
    
    /// <summary>
    /// Attempts to delete a booking from the system.
    /// </summary>
    public void TryDeleteBooking()
    {
        string tempBookingId = "-NhcguA75XIsaZOmmmqs"; // the booking ID
        string tempDate = "24-24-25"; // the date the booking is under
    
        // Attempt to delete the booking through Firebase DAO.
        _firebaseDao.DeleteBooking(tempDate, tempBookingId, 
            () => 
            {
                // Success callback: Log a success message.
                Debug.Log("Booking deleted successfully!");
            },
            errorMessage => 
            {
                // Failure callback: Log the received error message.
                Debug.LogError($"Failed to delete booking: {errorMessage}");
            }
        );
    }
}
