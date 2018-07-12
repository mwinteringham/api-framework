package com.restfulbooker.api.payloads.response;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Date;

@JsonIgnoreProperties(ignoreUnknown = true)
public class BookingDetailsDates {

    @JsonProperty
    private Date checkin;
    @JsonProperty
    private Date checkout;

    public Date getCheckin() {
        return checkin;
    }

    public Date getCheckout() {
        return checkout;
    }

}
