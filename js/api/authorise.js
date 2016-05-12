request = require('supertest-as-promised')

exports.post_credentials = function(payload){
  return request('http://localhost:3001')
           .post('/auth')
           .send(payload)
};
