package com.restfulbooker.api;

import com.restfulbooker.api.api.AuthApi;
import com.restfulbooker.api.api.BookingApi;
import com.restfulbooker.api.payloads.request.AuthPayload;
import com.restfulbooker.api.payloads.request.BookingPayload;
import com.restfulbooker.api.payloads.response.AuthResponse;
import com.restfulbooker.api.payloads.response.BookingResponse;
import io.restassured.response.Response;
import org.junit.Test;

import java.util.Date;

import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;

public class ApiTest {

    @Test
    public void getBookingShouldReturn200(){
        Response response = BookingApi.getBookings();

        assertThat(response.getStatusCode(), is(200));
    }

    @Test
    public void getBookingIdShouldReturn200(){
        Response response = BookingApi.getBooking(1, "application/json");

        assertThat(response.getStatusCode(), is(200));
    }

    @Test
    public void getBookingIdWithBadAcceptShouldReturn418(){
        Response response = BookingApi.getBooking(1, "text/plain");

        assertThat(response.getStatusCode(), is(418));
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

        Response response = BookingApi.postBooking(payload);

        assertThat(response.getStatusCode(), is(200));
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

        BookingResponse createdBookingResponse = BookingApi.postBooking(payload).as(BookingResponse.class);

        AuthPayload authPayload = new AuthPayload.AuthPayloadBuilder()
                .setUsername("admin")
                .setPassword("password123")
                .build();

        AuthResponse authResponse = AuthApi.postAuth(authPayload).as(AuthResponse.class);

        Response deleteResponse = BookingApi.deleteBooking(
                createdBookingResponse.getBookingid(),
                authResponse.getToken());

        assertThat(deleteResponse.getStatusCode(), is(201));
    }

}
