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

    public static class BookingBuilder {

        private String firstname;
        private String lastname;
        private int totalprice;
        private boolean depositpaid;
        private Date checkin;
        private Date checkout;
        private String additionalneeds;

        public BookingBuilder setFirstname(String firstname) {
            this.firstname = firstname;
            return this;
        }

        public BookingBuilder setLastname(String lastname) {
            this.lastname = lastname;
            return this;
        }

        public BookingBuilder setTotalprice(int totalprice) {
            this.totalprice = totalprice;
            return this;
        }

        public BookingBuilder setDepositpaid(boolean depositpaid) {
            this.depositpaid = depositpaid;
            return this;
        }

        public BookingBuilder setCheckin(Date checkin) {
            this.checkin = checkin;
            return this;
        }

        public BookingBuilder setCheckout(Date checkout) {
            this.checkout = checkout;
            return this;
        }

        public BookingBuilder setAdditionalneeds(String additionalneeds) {
            this.additionalneeds = additionalneeds;
            return this;
        }

        public Booking build(){
            BookingDates bookingDates = new BookingDates(checkin, checkout);
            return new Booking(firstname, lastname, totalprice, depositpaid, bookingDates, additionalneeds);
        }
    }
}
