package com.restfulbooker.api.payloads;

import org.codehaus.jackson.annotate.JsonProperty;

import java.util.Date;

public class Booking {

    @JsonProperty
    private String firstname;
    @JsonProperty
    private String lastname;
    @JsonProperty
    private int totalprice;
    @JsonProperty
    private boolean depositpaid;
    @JsonProperty
    private BookingDates bookingdates;
    @JsonProperty
    private String additionalneeds;

    public String getFirstname() {
        return firstname;
    }

    public String getLastname() {
        return lastname;
    }

    public int getTotalprice() {
        return totalprice;
    }

    public boolean isDepositpaid() {
        return depositpaid;
    }

    public BookingDates getBookingdates() {
        return bookingdates;
    }

    public String getAdditionalneeds() {
        return additionalneeds;
    }

    // default constructor required by Jackson
    private Booking() {
        // nothing here
    }

    private Booking(String firstname, String lastname, int totalprice, boolean depositpaid, BookingDates bookingdates, String additionalneeds) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.totalprice = totalprice;
        this.depositpaid = depositpaid;
        this.bookingdates = bookingdates;
        this.additionalneeds = additionalneeds;
    }

    public static class Builder {

        private String firstname;
        private String lastname;
        private int totalprice;
        private boolean depositpaid;
        private BookingDates bookingdates;
        private String additionalneeds;

        public Builder setFirstname(String firstname) {
            this.firstname = firstname;
            return this;
        }

        public Builder setLastname(String lastname) {
            this.lastname = lastname;
            return this;
        }

        public Builder setTotalprice(int totalprice) {
            this.totalprice = totalprice;
            return this;
        }

        public Builder setDepositpaid(boolean depositpaid) {
            this.depositpaid = depositpaid;
            return this;
        }

        public Builder setBookingdates(BookingDates bookingdates) {
            this.bookingdates = bookingdates;
            return this;
        }

        public Builder setAdditionalneeds(String additionalneeds) {
            this.additionalneeds = additionalneeds;
            return this;
        }

        public Booking build(){
            return new Booking(firstname, lastname, totalprice, depositpaid, bookingdates, additionalneeds);
        }
    }
}
