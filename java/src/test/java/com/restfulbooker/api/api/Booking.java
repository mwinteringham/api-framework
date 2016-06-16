package com.restfulbooker.api.api;

import com.restfulbooker.api.payloads.request.BookingPayload;
import com.restfulbooker.api.payloads.response.BookingResponse;
import org.springframework.http.*;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.RestTemplate;

import java.util.Arrays;

public class Booking {

    private static RestTemplate restTemplate = new RestTemplate();
    private static String baseUrl = "http://localhost:3001";

    public static ResponseEntity<String> getBookings(){
        return restTemplate.getForEntity(baseUrl + "/booking", String.class);
    }

    public static ResponseEntity<String> getBooking(int id, MediaType accept) throws HttpClientErrorException {
        HttpHeaders requestHeaders = new HttpHeaders();
        requestHeaders.setAccept(Arrays.asList(accept));

        HttpEntity<String> httpEntity = new HttpEntity<String>(requestHeaders);

        return restTemplate.exchange(baseUrl + "/booking/" + Integer.toString(id), HttpMethod.GET, httpEntity, String.class);
    }

    public static ResponseEntity<BookingResponse> postBooking(BookingPayload payload) {
        HttpHeaders requestHeaders = new HttpHeaders();
        requestHeaders.setContentType(MediaType.APPLICATION_JSON);
        requestHeaders.setAccept(Arrays.asList(MediaType.APPLICATION_JSON));

        HttpEntity<BookingPayload> httpEntity = new HttpEntity<BookingPayload>(payload, requestHeaders);

        return restTemplate.exchange(baseUrl + "/booking", HttpMethod.POST, httpEntity, BookingResponse.class);
    }

    public static ResponseEntity<String> deleteBooking(int id, String tokenValue) {
        HttpHeaders requestHeaders = new HttpHeaders();
        requestHeaders.set("Cookie","token=" + tokenValue);

        HttpEntity<String> httpEntity = new HttpEntity<String>(requestHeaders);

        return restTemplate.exchange(baseUrl + "/booking/" + Integer.toString(id), HttpMethod.DELETE, httpEntity, String.class);
    }
}
