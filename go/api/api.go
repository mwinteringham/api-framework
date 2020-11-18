package api

import (
	"bytes"
	"encoding/json"
	"fmt"
	"net/http"
	"net/url"

	"github.com/Rosalita/api-framework/go/payloads"
)

var baseURL = "https://restful-booker.herokuapp.com"

func RequestAuth(user, pw string) (*http.Request, error) {
	authPayload := payloads.Auth{
		Username: user,
		Password: pw,
	}

	payload, err := json.Marshal(&authPayload)
	if err != nil {
		return nil, err
	}

	reqURL, err := url.Parse(baseURL)
	if err != nil {
		return nil, err
	}

	reqURL.Path = "auth"
	req, err := http.NewRequest("POST", reqURL.String(), bytes.NewBuffer(payload))
	if err != nil {
		return nil, err
	}

	req.Header.Add("Content-Type", "application/json")
	return req, nil
}

//RequestAllBookings returns a GET request to https://restful-booker.herokuapp.com/booking
func RequestAllBookings() (*http.Request, error) {
	reqURL, err := url.Parse(baseURL)
	if err != nil {
		return nil, err
	}

	reqURL.Path = "booking"
	req, err := http.NewRequest("GET", reqURL.String(), nil)
	if err != nil {
		return nil, err
	}

	return req, nil
}

//RequestSpecificBooking returns a GET request to https://restful-booker.herokuapp.com/booking/{ID}
func RequestSpecificBooking(bookingID string) (*http.Request, error) {
	reqURL, err := url.Parse(baseURL)
	if err != nil {
		return nil, err
	}

	reqURL.Path = fmt.Sprintf("booking/%s", bookingID)
	req, err := http.NewRequest("GET", reqURL.String(), nil)
	if err != nil {
		return nil, err
	}

	req.Header.Add("Accept", "application/json")
	return req, nil
}

//RequestCreateBooking returns a POST request to https://restful-booker.herokuapp.com/booking
func RequestCreateBooking(bookingPayload payloads.Booking) (*http.Request, error) {

	payload, err := json.Marshal(&bookingPayload)
	if err != nil {
		return nil, err
	}

	reqURL, err := url.Parse(baseURL)
	if err != nil {
		return nil, err
	}

	reqURL.Path = "booking"
	req, err := http.NewRequest("POST", reqURL.String(), bytes.NewBuffer(payload))
	if err != nil {
		return nil, err
	}

	req.Header.Add("Accept", "application/json")
	req.Header.Add("Content-Type", "application/json")

	return req, nil
}

//RequestUpdateBooking returns a PUT request to https://restful-booker.herokuapp.com/booking/{ID}
func RequestUpdateBooking(bookingPayload payloads.Booking, bookingID string) (*http.Request, error) {

	payload, err := json.Marshal(&bookingPayload)
	if err != nil {
		return nil, err
	}

	reqURL, err := url.Parse(baseURL)
	if err != nil {
		return nil, err
	}

	reqURL.Path = fmt.Sprintf("booking/%s", bookingID)

	req, err := http.NewRequest("PUT", reqURL.String(), bytes.NewBuffer(payload))
	if err != nil {
		return nil, err
	}

	req.Header.Add("Accept", "application/json")
	req.Header.Add("Content-Type", "application/json")

	return req, nil
}
