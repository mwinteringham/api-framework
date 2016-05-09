class BookingPayload

  attr_accessor :firstname, :lastname, :totalprice, :depositpaid, :checkin, :checkout, :additionalneeds

  def initialize(&block)
    instance_eval &block if block_given?
  end

  def toJson
    return "{
        \"firstname\": \"#{firstname}\",
        \"lastname\": \"#{lastname}\",
        \"totalprice\": #{totalprice},
        \"depositpaid\": #{depositpaid},
        \"bookingdates\": {
            \"checkin\": \"#{checkin}\",
            \"checkout\": \"#{checkout}\"
        },
        \"additionalneeds\": \"#{additionalneeds}\"
    }"
  end

end