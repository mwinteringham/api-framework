package com.restfulbooker.api.payloads;

import org.codehaus.jackson.annotate.JsonProperty;

import java.util.Date;

public class BookingDates {

    @JsonProperty
    private Date checkin;
    @JsonProperty
    private Date checkout;

    // default constructor required by Jackson
    private BookingDates() {
        // nothing here
    }

    public BookingDates(Date checkin, Date checkout){
        this.checkin = checkin;
        this.checkout = checkout;
    }

    public Date getCheckin() {
        return checkin;
    }

    public Date getCheckout() {
        return checkout;
    }
}
