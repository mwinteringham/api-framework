class BookingPayload

  attr_accessor :firstname, :lastname, :totalprice, :depositpaid, :checkin, :checkout, :additionalneeds

  def initialize(&block)
    instance_eval &block if block_given?
  end

  def to_json
    {firstname: firstname,
     lastname: lastname,
     totalprice: totalprice,
     depositpaid: depositpaid,
     bookingdates: {checkin: checkin,
                    checkout: checkout},
     additionalneeds: additionalneeds}.to_json
  end

end