package com.restfulbooker.api.payloads.request;

import org.codehaus.jackson.annotate.JsonProperty;

public class AuthPayload {

    @JsonProperty
    private String username;
    @JsonProperty
    private String password;

    private AuthPayload(String username, String password) {
        this.username = username;
        this.password = password;
    }

    public String getUsername() {
        return username;
    }

    public String getPassword() {
        return password;
    }

    public static class AuthPayloadBuilder{

        private String username;
        private String password;

        public AuthPayloadBuilder setUsername(String username) {
            this.username = username;
            return this;
        }

        public AuthPayloadBuilder setPassword(String password) {
            this.password = password;
            return this;
        }

        public AuthPayload build(){
            return new AuthPayload(username, password);
        }
    }
}
