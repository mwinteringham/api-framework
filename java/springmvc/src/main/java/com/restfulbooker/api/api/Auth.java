package com.restfulbooker.api.api;

import com.restfulbooker.api.payloads.request.AuthPayload;
import com.restfulbooker.api.payloads.response.AuthResponse;
import org.springframework.http.*;
import org.springframework.web.client.RestTemplate;

public class Auth {

    private static RestTemplate restTemplate = new RestTemplate();

    public static ResponseEntity<AuthResponse> postAuth(AuthPayload payload){
        HttpHeaders requestHeaders = new HttpHeaders();
        requestHeaders.setContentType(MediaType.APPLICATION_JSON);

        HttpEntity<AuthPayload> httpEntity = new HttpEntity<AuthPayload>(payload, requestHeaders);

        return restTemplate.exchange("http://localhost:3001/auth", HttpMethod.POST, httpEntity, AuthResponse.class);
    }
}
