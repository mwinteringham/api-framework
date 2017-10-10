package com.restfulbooker.api.payloads;

import org.codehaus.jackson.annotate.JsonProperty;

public class Auth {

    @JsonProperty
    private String username;
    @JsonProperty
    private String password;

    public String getUsername() {
        return username;
    }

    public String getPassword() {
        return password;
    }

    private Auth(String username, String password) {
        this.username = username;
        this.password = password;
    }

    public static class Builder {

        private String username;
        private String password;

        public Builder setUsername(String username) {
            this.username = username;
            return this;
        }

        public Builder setPassword(String password) {
            this.password = password;
            return this;
        }

        public Auth build(){
            return new Auth(username, password);
        }
    }
}
