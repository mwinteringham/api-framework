import requests


def all_bookings():
    return requests.get('http://localhost:3001/booking')


def specific_booking(identifier, accept):
    headers = {'Accept': accept}
    return requests.get('http://localhost:3001/booking/' + str(identifier), headers=headers)


def create_booking(payload, content_type):
    headers = {'Accept': 'application/json', 'Content-type': content_type}
    return requests.post('http://localhost:3001/booking', payload, headers=headers)


def delete_booking(identifier, token):
    headers = {'Cookie': 'token=' + token}
    return requests.delete('http://localhost:3001/booking/' + str(identifier), headers=headers)

