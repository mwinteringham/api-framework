import requests


def all_bookings():
    return requests.get('https://restful-booker.herokuapp.com/booking')


def specific_booking(identifier, accept):
    headers = {'Accept': accept}
    return requests.get('https://restful-booker.herokuapp.com/booking/' + str(identifier), headers=headers)


def create_booking(payload, content_type):
    headers = {'Accept': 'application/json', 'Content-type': content_type}
    return requests.post('https://restful-booker.herokuapp.com/booking', payload, headers=headers)


def delete_booking(identifier, token):
    headers = {'Cookie': 'token=' + token}
    return requests.delete('https://restful-booker.herokuapp.com/booking/' + str(identifier), headers=headers)

