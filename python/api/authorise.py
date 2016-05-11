import requests


def post_credentials(payload):
    headers = { 'Content-type': 'application/json'}
    return requests.post('http://localhost:3001/auth', payload, headers=headers)
