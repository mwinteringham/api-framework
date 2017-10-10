import requests


def post_credentials(payload):
    headers = { 'Content-type': 'application/json'}
    return requests.post('https://restful-booker.herokuapp.com/auth', payload, headers=headers)
