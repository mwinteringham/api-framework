package com.restfulbooker.api.api;

import com.restfulbooker.api.payloads.request.AuthPayload;
import io.restassured.http.ContentType;
import io.restassured.response.Response;

import static io.restassured.RestAssured.given;

public class AuthApi extends BaseApi {

    private static final String apiUrl = baseUrl + "auth/";

    public static Response postAuth(AuthPayload payload){
        return given()
                .contentType(ContentType.JSON)
                .body(payload)
                .when()
                .post(apiUrl);
    }
}
