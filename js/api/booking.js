request = require('supertest-as-promised')

exports.all_bookings = function(){
  return request('https://restful-booker.herokuapp.com')
           .get('/booking')
};

exports.specific_booking = function(identifier, accept){
  return request('https://restful-booker.herokuapp.com')
          .get('/booking/' + identifier)
          .set('accept', accept)
};

exports.create_booking = function(payload, contentType){
  return request('https://restful-booker.herokuapp.com')
           .post('/booking')
           .set('accept', 'application/json')
           .set('Content-type', contentType)
           .send(payload)
};

exports.deleteBooking = function(identifier, token){
  return request('https://restful-booker.herokuapp.com')
           .delete('/booking/' + identifier)
           .set('Cookie', 'token=' + token)
}
