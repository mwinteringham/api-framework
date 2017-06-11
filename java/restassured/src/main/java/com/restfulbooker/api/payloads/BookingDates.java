package com.restfulbooker.api.payloads;

import org.codehaus.jackson.annotate.JsonProperty;

import java.util.Date;

public class BookingDates {

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

    // default constructor required by Jackson
    private BookingDates() {
        // nothing here
    }

    private BookingDates(Date checkin, Date checkout){
        this.checkin = checkin;
        this.checkout = checkout;
    }

    public static class Builder {

        private Date checkin;
        private Date checkout;

        public Builder setCheckin(Date checkin) {
            this.checkin = checkin;
            return this;
        }

        public Builder setCheckout(Date checkout) {
            this.checkout = checkout;
            return this;
        }

        public BookingDates build() {
            return new BookingDates(checkin, checkout);
        }
    }
}
