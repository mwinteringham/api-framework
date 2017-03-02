package com.restfulbooker.api.payloads.response;

import org.codehaus.jackson.annotate.JsonIgnoreProperties;
import org.codehaus.jackson.annotate.JsonProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class BookingResponse {

    @JsonProperty
    private int bookingid;
    @JsonProperty
    private BookingDetails booking;

    public void setBookingid(int bookingid) {
        this.bookingid = bookingid;
    }

    public void setBooking(BookingDetails booking) {
        this.booking = booking;
    }

    public int getBookingid() {
        return bookingid;
    }

    public BookingDetails getBooking() {
        return booking;
    }
}
