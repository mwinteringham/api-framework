request = require('supertest-as-promised')

exports.post_credentials = function(payload){
  return request('https://restful-booker.herokuapp.com')
           .post('/auth')
           .send(payload)
};
