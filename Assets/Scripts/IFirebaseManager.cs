using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFirebaseManager
{
  bool BookWorkstation(Booking booking);
  bool DeleteBooking(Booking booking);
  List<Booking> GetAllBookings();
  List<Booking> GetAllBookingsForDay(DateTime date);
}
