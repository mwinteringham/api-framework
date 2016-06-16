package com.beyondchecks.api;

import com.beyondchecks.api.api.Auth;
import com.beyondchecks.api.api.Booking;
import com.beyondchecks.api.payloads.request.AuthPayload;
import com.beyondchecks.api.payloads.request.BookingPayload;
import com.beyondchecks.api.payloads.response.AuthResponse;
import com.beyondchecks.api.payloads.response.BookingResponse;
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

        assertThat(response.getStatusCode(), is(HttpStatus.OK));
    }

    @Test
    public void getBookingIdShouldReturn200(){
        ResponseEntity<String> response = Booking.getBooking(1, MediaType.APPLICATION_JSON);

        assertThat(response.getStatusCode(), is(HttpStatus.OK));
    }

    @Test
    public void getBookingIdWithBadAcceptShouldReturn418(){
        try{
            ResponseEntity<String> response = Booking.getBooking(1, MediaType.TEXT_PLAIN);
            assertNotEquals(response.getStatusCode(), is(HttpStatus.OK));
        } catch (HttpClientErrorException e){
            assertThat(e.getRawStatusCode(), is(418));
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

        assertEquals(response.getStatusCode(), HttpStatus.OK);
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

        assertEquals(deleteResponse.getStatusCode(), HttpStatus.CREATED);
    }

}
