require 'spec_helper'

include Booking
include Authorise

describe('Restful-booker') do

  it('GET /booking should return a 200') do
    response = Booking.all_bookings

    expect(response.code).to be(200)
  end

  it('GET /booking/{id} should return a 200') do
    response = Booking.specific_booking(1, :json)

    expect(response.code).to be(200)
  end

  it('GET /booking/{id} should return a 418 when sent a bad accept header') do
    response = Booking.specific_booking(1, :text)

    expect(response.code).to be(418)
  end

  it('POST /booking should return a 200') do
    payload = BookingPayload.new do
      self.firstname = 'Sally'
      self.lastname = 'Jenkins'
      self.totalprice = 111
      self.depositpaid = true
      self.checkin = '11-11-2010'
      self.checkout = '12-11-2010'
      self.additionalneeds = 'Breakfast'
    end

    response = Booking.create_booking(payload.toJson, :json)

    expect(response.code).to be(200)
  end

  it('DELETE /booking/{id} should return a 200') do
    payload = BookingPayload.new do
      self.firstname = 'Sally'
      self.lastname = 'Jenkins'
      self.totalprice = 111
      self.depositpaid = true
      self.checkin = '11-11-2010'
      self.checkout = '12-11-2010'
      self.additionalneeds = 'Breakfast'
    end

    created_response = Booking.create_booking(payload.toJson, :json)

    auth_payload = AuthorisePayload.new do
      self.username = "admin"
      self.password = "password123"
    end

    auth_response = Authorise.post_credentials(auth_payload.toJson)

    delete_response = Booking.delete_booking(JSON.parse(created_response.body)["bookingid"].to_i, JSON.parse(auth_response.body)["token"])

    expect(delete_response.code).to be(201)
  end

end