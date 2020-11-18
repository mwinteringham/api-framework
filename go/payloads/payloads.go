package payloads

// Auth represents an authorisation payload
type Auth struct {
	Username string `json:"username"`
	Password string `json:"password"`
}

// AuthResponse is used to unmarshal an authorisation response
type AuthResponse struct {
	Token string `json:"token"`
}

//Booking represents a booking
type Booking struct {
	Firstname       string       `json:"firstname,omitempty"`
	Lastname        string       `json:"lastname,omitempty"`
	TotalPrice      float64      `json:"totalprice,omitempty"`
	DepositPaid     bool         `json:"depositpaid,omitempty"`
	BookingDates    BookingDates `json:"bookingdates,omitempty"`
	AdditionalNeeds string       `json:"additionalneeds,omitempty"`
}

// BookingDates represents a CheckIn and a CheckOut date
type BookingDates struct {
	CheckIn  string `json:"checkin"`
	CheckOut string `json:"checkout"`
}
