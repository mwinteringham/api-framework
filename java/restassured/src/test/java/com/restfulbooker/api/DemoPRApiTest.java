package com.restfulbooker.api;

import com.restfulbooker.api.api.AuthApi;
import com.restfulbooker.api.api.BookingApi;
import com.restfulbooker.api.payloads.*;
import io.restassured.response.Response;
import org.approvaltests.Approvals;
import org.junit.jupiter.api.Test;

import java.util.Date;

public class DemoPRApiTest {

    @Test
    public void deleteBookingReturns201(){
        BookingDates dates = new BookingDates.Builder()
                .setCheckin(new Date())
                .setCheckout(new Date())
                .build();

        Booking payload = new Booking.Builder()
                .setFirstname("Mary")
                .setLastname("White")
                .setTotalprice(200)
                .setDepositpaid(true)
                .setBookingdates(dates)
                .setAdditionalneeds("None")
                .build();

        BookingResponse createdBookingResponse = BookingApi.postBooking(payload).as(BookingResponse.class);

        Auth auth = new Auth.Builder()
                .setUsername("admin")
                .setPassword("password123")
                .build();

        AuthResponse authResponse = AuthApi.postAuth(auth).as(AuthResponse.class);

        Response deleteResponse = BookingApi.deleteBooking(
                createdBookingResponse.getBookingid(),
                authResponse.getToken());

        Approvals.verify(deleteResponse.getStatusCode());
    }

}
