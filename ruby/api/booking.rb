require 'rest-client'

module Booking

  def all_bookings
    RestClient.get 'https://restful-booker.herokuapp.com/booking'
  rescue => e
    e.response
  end

  def specific_booking(id, accept)
    RestClient.get "https://restful-booker.herokuapp.com/booking/#{id}", accept: accept
  rescue => e
    e.response
  end

  def create_booking(payload, content_type)
    RestClient.post 'https://restful-booker.herokuapp.com/booking', payload, accept: :json, content_type: content_type
  rescue => e
    e.response
  end

  def delete_booking(id, token)
    RestClient.delete "https://restful-booker.herokuapp.com/booking/#{id}", cookie: "token=#{token}"
  rescue => e
    e.response
  end

end