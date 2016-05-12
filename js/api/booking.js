request = require('supertest-as-promised')

exports.all_bookings = function(){
  return request('http://localhost:3001')
           .get('/booking')
};

exports.specific_booking = function(identifier, accept){
  return request('http://localhost:3001')
          .get('/booking/' + identifier)
          .set('accept', accept)
};

exports.create_booking = function(payload, contentType){
  return request('http://localhost:3001')
           .post('/booking')
           .set('accept', 'application/json')
           .set('Content-type', contentType)
           .send(payload)
};

exports.deleteBooking = function(identifier, token){
  return request('http://localhost:3001')
           .delete('/booking/' + identifier)
           .set('Cookie', 'token=' + token)
}
