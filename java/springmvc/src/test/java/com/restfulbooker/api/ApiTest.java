package com.restfulbooker.api;

import com.restfulbooker.api.api.Auth;
import com.restfulbooker.api.api.Booking;
import com.restfulbooker.api.payloads.request.AuthPayload;
import com.restfulbooker.api.payloads.request.BookingPayload;
import com.restfulbooker.api.payloads.response.AuthResponse;
import com.restfulbooker.api.payloads.response.BookingResponse;
import org.approvaltests.Approvals;
import org.junit.Test;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.HttpClientErrorException;

import java.util.Date;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.*;

public class ApiTest {

    @Test
    public void getBookingShouldReturn200(){
        ResponseEntity<String> response = Booking.getBookings();

        Approvals.verify(response.getStatusCode());
    }

    @Test
    public void getBookingIdShouldReturn200(){
        ResponseEntity<String> response = Booking.getBooking(1, MediaType.APPLICATION_JSON);

        Approvals.verify(response.getStatusCode());
    }

    @Test
    public void getBookingIdWithBadAcceptShouldReturn418(){
        try{
            Booking.getBooking(1, MediaType.TEXT_PLAIN);

            fail("HttpClientError not thrown");
        } catch (HttpClientErrorException e){
            Approvals.verify(e.getStatusCode());
        }
    }

    @Test
    public void postBookingReturns200(){
        BookingPayload payload = new BookingPayload.BookingPayloadBuilder()
                .setFirstname("Mary")
                .setLastname("White")
                .setTotalprice(200)
                .setDepositpaid(true)
                .setCheckin(new Date())
                .setCheckout(new Date())
                .setAdditionalneeds("None")
                .build();

        ResponseEntity<BookingResponse> response = Booking.postBooking(payload);

        Approvals.verify(response.getStatusCode());
    }

    @Test
    public void deleteBookingReturns201(){
        BookingPayload payload = new BookingPayload.BookingPayloadBuilder()
                .setFirstname("Mary")
                .setLastname("White")
                .setTotalprice(200)
                .setDepositpaid(true)
                .setCheckin(new Date())
                .setCheckout(new Date())
                .setAdditionalneeds("None")
                .build();

        ResponseEntity<BookingResponse> createdBookingResponse = Booking.postBooking(payload);

        AuthPayload authPayload = new AuthPayload.AuthPayloadBuilder()
                .setUsername("admin")
                .setPassword("password123")
                .build();

        ResponseEntity<AuthResponse> authResponse = Auth.postAuth(authPayload);

        ResponseEntity<String> deleteResponse = Booking.deleteBooking(
                createdBookingResponse.getBody().getBookingid(),
                authResponse.getBody().getToken());

        Approvals.verify(deleteResponse.getStatusCode());
    }

}
