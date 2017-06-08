Feature: restful-booker api test demo

Background: 
* url 'http://localhost:3001'
* header Accept = 'application/json'
* def date = read('new-date.js')
* def payload = 
"""
{ 
  firstname: 'Mary', lastname: 'White', totalprice: 200, depositpaid: true,
  bookingdates: { checkin: '#(date())', checkout: '#(date())' }
}
"""

Scenario: get booking should return 200
  Given path 'booking'
  When method get
  Then status 200
  # not supported by rest-assured
  And match each response == { bookingid: '#number' }

Scenario: get booking by id should return 200
  Given path 'booking', 1  
  When method get
  Then status 200

Scenario: get booking by id with bad accept header should return 418
  Given path 'booking', 1
  And header Accept = 'text/plain'
  When method get
  Then status 418

Scenario: post booking returns 200 and delete booking returns 201
  Given path 'booking'
  And request payload
  When method post
  Then status 200
  # not supported by rest-assured
  And match response.booking == payload
  And def bookingId = response.bookingid

  Given path 'auth'
  And request { username: 'admin', password: 'password123' }
  When method post
  Then status 200
  And def authToken = response.token

  Given path 'booking', bookingId
  And header Cookie = 'token=' + authToken
  When method delete
  Then status 201
