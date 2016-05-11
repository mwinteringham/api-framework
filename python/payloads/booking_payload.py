class BookingPayload:
    def __init__(self, firstname, lastname, totalprice, depositpaid, checkin, checkout, additionalneeds):
        self.firstname = firstname
        self.lastname = lastname
        self.totalprice = totalprice
        self.depositpaid = depositpaid
        self.checkin = checkin
        self.checkout = checkout
        self.additionalneeds = additionalneeds

    def build(self):
        return """{{
            "firstname": "{firstname}",
            "lastname": "{lastname}",
            "totalprice": {totalprice},
            "depositpaid": {depositpaid},
            "bookingdates": {{
                "checkin": "{checkin}",
                "checkout": "{checkout}"
            }},
            "additionalneeds": "{additionalneeds}"
        }}""".format(firstname=self.firstname,
                    lastname=self.lastname,
                    totalprice=str(self.totalprice),
                    depositpaid=self.depositpaid,
                    checkin=self.checkin,
                    checkout=self.checkout,
                    additionalneeds=self.additionalneeds)
