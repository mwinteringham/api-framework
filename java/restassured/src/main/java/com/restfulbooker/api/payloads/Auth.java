package com.restfulbooker.api.payloads;

        import org.codehaus.jackson.annotate.JsonProperty;

public class Auth {

    @JsonProperty
    private String username;
    @JsonProperty
    private String password;

    private Auth(String username, String password) {
        this.username = username;
        this.password = password;
    }

    public String getUsername() {
        return username;
    }

    public String getPassword() {
        return password;
    }

    public static class AuthBuilder {

        private String username;
        private String password;

        public AuthBuilder setUsername(String username) {
            this.username = username;
            return this;
        }

        public AuthBuilder setPassword(String password) {
            this.password = password;
            return this;
        }

        public Auth build(){
            return new Auth(username, password);
        }
    }
}
