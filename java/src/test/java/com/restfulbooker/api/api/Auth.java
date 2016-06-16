package com.restfulbooker.api.api;

import com.restfulbooker.api.payloads.request.AuthPayload;
import com.restfulbooker.api.payloads.response.AuthResponse;
import org.springframework.http.*;
import org.springframework.web.client.RestTemplate;

public class Auth {

    private static RestTemplate restTemplate = new RestTemplate();
    private static String baseUrl = "http://localhost:3001";

    public static ResponseEntity<AuthResponse> postAuth(AuthPayload payload){
        HttpHeaders requestHeaders = new HttpHeaders();
        requestHeaders.setContentType(MediaType.APPLICATION_JSON);

        HttpEntity<AuthPayload> httpEntity = new HttpEntity<AuthPayload>(payload, requestHeaders);

        return restTemplate.exchange(baseUrl + "/auth", HttpMethod.POST, httpEntity, AuthResponse.class);
    }
}
