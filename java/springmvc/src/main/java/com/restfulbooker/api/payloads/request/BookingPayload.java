package com.restfulbooker.api.payloads.request;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Date;

public class BookingPayload {

    @JsonProperty
    private String firstname;
    @JsonProperty
    private String lastname;
    @JsonProperty
    private int totalprice;
    @JsonProperty
    private boolean depositpaid;
    @JsonProperty
    private BookingDatesPayload bookingdates;
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

    public BookingDatesPayload getBookingdates() {
        return bookingdates;
    }

    public String getAdditionalneeds() {
        return additionalneeds;
    }

    private BookingPayload(String firstname, String lastname, int totalprice, boolean depositpaid, BookingDatesPayload bookingdates, String additionalneeds) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.totalprice = totalprice;
        this.depositpaid = depositpaid;
        this.bookingdates = bookingdates;
        this.additionalneeds = additionalneeds;
    }

    public static class BookingPayloadBuilder {

        private String firstname;
        private String lastname;
        private int totalprice;
        private boolean depositpaid;
        private Date checkin;
        private Date checkout;
        private String additionalneeds;

        public BookingPayloadBuilder setFirstname(String firstname) {
            this.firstname = firstname;
            return this;
        }

        public BookingPayloadBuilder setLastname(String lastname) {
            this.lastname = lastname;
            return this;
        }

        public BookingPayloadBuilder setTotalprice(int totalprice) {
            this.totalprice = totalprice;
            return this;
        }

        public BookingPayloadBuilder setDepositpaid(boolean depositpaid) {
            this.depositpaid = depositpaid;
            return this;
        }

        public BookingPayloadBuilder setCheckin(Date checkin) {
            this.checkin = checkin;
            return this;
        }

        public BookingPayloadBuilder setCheckout(Date checkout) {
            this.checkout = checkout;
            return this;
        }

        public BookingPayloadBuilder setAdditionalneeds(String additionalneeds) {
            this.additionalneeds = additionalneeds;
            return this;
        }

        public BookingPayload build(){
            BookingDatesPayload bookingDates = new BookingDatesPayload(checkin, checkout);
            return new BookingPayload(firstname, lastname, totalprice, depositpaid, bookingDates, additionalneeds);
        }
    }
}
