require 'rest-client'

module Booking

  def all_bookings
    begin
      return RestClient.get 'http://localhost:3001/booking'
    rescue => e
      return e.response
    end
  end

  def specific_booking(id, accept)
    begin
      return RestClient.get 'http://localhost:3001/booking/' + id.to_s, :accept => accept
    rescue => e
      return e.response
    end
  end

  def create_booking(payload, content_type)
    begin
      return RestClient.post 'http://localhost:3001/booking', payload, :accept => :json, :content_type => content_type
    rescue => e
      return e.response
    end
  end

  def delete_booking(id, token)
    begin
      return RestClient.delete 'http://localhost:3001/booking/' + id.to_s, :cookie => 'token=' + token
    rescue => e
      return e.response
    end
  end

end