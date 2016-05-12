var request        = require('supertest-as-promised'),
    expect         = require('chai').expect,
    should         = require('chai').should(),
    Booking        = require('../api/booking'),
    Authorise      = require('../api/authorise'),
    BookingPayload = require('../payloads/booking_payload'),
    AuthPayload    = require('../payloads/auth_payload');

describe('restful-booker', function(){

  it('returns a 200 when getting bookings', function testAllBookings(done) {
    Booking.all_bookings()
      .expect(200, done);
  });

  it('returns a 200 when getting a specific bookings', function testSpecificBooking(done) {
    Booking.specific_booking(1, 'application/json')
      .expect(200, done);
  });

  it('returns a 418 when getting a specific bookings with a bad heading', function testSpecificBookingBadHeading(done) {
    Booking.specific_booking(1, 'text/html')
      .expect(418, done);
  });

  it('returns a 200 when creating a booking', function testCreatingABooking(done){
    var payload = BookingPayload.create('Sally', 'Brown', 111, true, 'Breakfast', '2013-02-01', '2013-02-04');

    Booking.create_booking(payload, 'application/json')
      .expect(200, done);
  });

  it('returns a 200 when a DELETE is carried out on a booking', function deleteBooking(done){
    var booking_payload = BookingPayload.create('Sally', 'Brown', 111, true, 'Breakfast', '2013-02-01', '2013-02-04');
    var authorisation_payload = AuthPayload.create('admin', 'password123');

    Booking.create_booking(booking_payload, 'application/json')
      .then(function(res){
        var identifier = res.body.bookingid;
        Authorise.post_credentials(authorisation_payload)
          .then(function(res){
            Booking.deleteBooking(identifier, res.body.token)
              .expect(201, done);
          });
      })
  });

});
