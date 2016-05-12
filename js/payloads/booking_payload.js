exports.create = function(firstname, lastname, totalprice, depositpaid, additionalneeds, checkin, checkout){
  return {
    'firstname': firstname,
    'lastname': lastname,
    'totalprice': totalprice,
    'depositpaid': depositpaid,
    'bookingdates': {
      'checkin': checkin,
      'checkout': checkout
    },
    'additionalneeds': additionalneeds
  }
}
