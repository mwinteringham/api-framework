package com.restfulbooker.api.api;

import com.restfulbooker.api.payloads.request.BookingPayload;
import io.restassured.http.ContentType;
import io.restassured.response.Response;

import static io.restassured.RestAssured.given;

public class Booking {

    private static String baseUrl = "http://localhost:3001";

    public static Response getBookings(){
        return given().get(baseUrl + "/booking");

    }

    public static Response getBooking(int id, String mediaType) {
        return given().header("Accept", mediaType).get(baseUrl + "/booking/" + Integer.toString(id));
    }

    public static Response postBooking(BookingPayload payload) {
        return given()
                .contentType(ContentType.JSON)
                .body(payload)
                .when()
                .post(baseUrl + "/booking");
    }

    public static Response deleteBooking(int id, String tokenValue) {
        return given()
                .header("Cookie", "token=" + tokenValue)
                .delete(baseUrl + "/booking/" + Integer.toString(id));
    }
}
