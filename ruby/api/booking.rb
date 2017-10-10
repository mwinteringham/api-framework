require 'rest-client'

module Booking

  def all_bookings
    begin
      return RestClient.get 'https://restful-booker.herokuapp.com/booking'
    rescue => e
      return e.response
    end
  end

  def specific_booking(id, accept)
    begin
      return RestClient.get 'https://restful-booker.herokuapp.com/booking/' + id.to_s, :accept => accept
    rescue => e
      return e.response
    end
  end

  def create_booking(payload, content_type)
    begin
      return RestClient.post 'https://restful-booker.herokuapp.com/booking', payload, :accept => :json, :content_type => content_type
    rescue => e
      return e.response
    end
  end

  def delete_booking(id, token)
    begin
      return RestClient.delete 'https://restful-booker.herokuapp.com/booking/' + id.to_s, :cookie => 'token=' + token
    rescue => e
      return e.response
    end
  end

end