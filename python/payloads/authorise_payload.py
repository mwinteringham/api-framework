class AuthorisePayload:
    def __init__(self, username, password):
        self.username = username
        self.password = password


    def build(self):
        return """{{
            "username": "{username}",
            "password": "{password}"
        }}""".format(username=self.username,
                     password=self.password)
