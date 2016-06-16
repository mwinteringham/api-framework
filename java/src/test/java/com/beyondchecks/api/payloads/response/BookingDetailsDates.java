package com.beyondchecks.api.payloads.response;

import org.codehaus.jackson.annotate.JsonIgnoreProperties;
import org.codehaus.jackson.annotate.JsonProperty;

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
