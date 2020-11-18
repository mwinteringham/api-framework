package main

import (
	"fmt"
	"net/http"
	"testing"

	"github.com/mwinteringham/api-framework/go/api"
	"github.com/mwinteringham/api-framework/go/payloads"
	"github.com/stretchr/testify/assert"
)

type createReqFunc func(payloads.Booking) (*http.Request, error)
type updateReqFunc func(payloads.Booking, string) (*http.Request, error)

func TestAllBookings(t *testing.T) {
	req, err := api.RequestAllBookings()
	if err != nil {
		fmt.Println(err)
	}
	statusCode, _ := DoRequest(req)
	assert.Equal(t, 200, statusCode)
}

func TestSpecificBooking(t *testing.T) {
	req, err := api.RequestSpecificBooking("1")
	if err != nil {
		fmt.Println(err)
	}
	statusCode, _ := DoRequest(req)
	assert.Equal(t, 200, statusCode)
}

func TestCreateBookings(t *testing.T) {
	validBooking := payloads.Booking{
		Firstname:   "Jim",
		Lastname:    "Brown",
		TotalPrice:  111,
		DepositPaid: true,
		BookingDates: payloads.BookingDates{
			CheckIn:  "2018-01-01",
			CheckOut: "2019-01-01",
		},
	}

	validBookingWithBreakfast := payloads.Booking{
		Firstname:   "Jim",
		Lastname:    "Brown",
		TotalPrice:  111,
		DepositPaid: true,
		BookingDates: payloads.BookingDates{
			CheckIn:  "2018-01-01",
			CheckOut: "2019-01-01",
		},
		AdditionalNeeds: "Breakfast",
	}

	invalidBooking := payloads.Booking{
		TotalPrice: 111,
	}

	tests := []struct {
		reqFunc            createReqFunc
		payload            payloads.Booking
		ExpectedStatusCode int
	}{
		{api.RequestCreateBooking, validBooking, 200},
		{api.RequestCreateBooking, validBookingWithBreakfast, 200},
		{api.RequestCreateBooking, invalidBooking, 500},
	}

	for _, test := range tests {
		req, err := test.reqFunc(test.payload)

		if err != nil {
			fmt.Println(err)
		}
		statusCode, _ := DoRequest(req)
		assert.Equal(t, test.ExpectedStatusCode, statusCode)
	}
}

func TestUpdateBooking(t *testing.T) {

	validBooking := payloads.Booking{
		Firstname:   "Jim",
		Lastname:    "Brown",
		TotalPrice:  111,
		DepositPaid: true,
		BookingDates: payloads.BookingDates{
			CheckIn:  "2018-01-01",
			CheckOut: "2019-01-01",
		},
	}

	validBookingWithBreakfast := payloads.Booking{
		Firstname:   "Jim",
		Lastname:    "Brown",
		TotalPrice:  111,
		DepositPaid: true,
		BookingDates: payloads.BookingDates{
			CheckIn:  "2018-01-01",
			CheckOut: "2019-01-01",
		},
		AdditionalNeeds: "Breakfast",
	}

	invalidBooking := payloads.Booking{
		TotalPrice: 111,
	}

	tests := []struct {
		reqFunc            updateReqFunc
		payload            payloads.Booking
		id                 string
		ExpectedStatusCode int
	}{
		{api.RequestUpdateBooking, validBooking, "1", 200},
		{api.RequestUpdateBooking, validBookingWithBreakfast, "1", 200},
		{api.RequestUpdateBooking, invalidBooking, "1", 400},
	}

	for _, test := range tests {
		req, err := test.reqFunc(test.payload, test.id)
		if err != nil {
			fmt.Println(err)
		}

		req.Header.Add("Cookie", authCookie)

		statusCode, _ := DoRequest(req)
		assert.Equal(t, test.ExpectedStatusCode, statusCode)
	}
}
