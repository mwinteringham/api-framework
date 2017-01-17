# api-framework

A group of templated API test frameworks based upon this series:  http://www.mwtestconsultancy.co.uk/category/api-web-service-testing/ The frameworks all have the same structure that is based upon the tutorial series I wrote last year on [how to build an automated API test framework](http://www.mwtestconsultancy.co.uk/build-automated-api-test-framework/).  The key to these templates is to demonstrate a way of structuring your API test framework regardless of what tools or languages that are used and is loosely based upon the principles of Page object architecture used for WebDriver.  The idea being that the structure will increase readability, reduce maintenance and prevent brittle tests from appearing.  

The framework contains three areas:

<ul>
<li>Tests - Surprisingly where the tests themselves are stored.  The tests will call functions from the API and Payload areas of the framework and be responsible for asserting responses.</li>
<li>API - All of the HTTP requests that you want to make are stored here.  They are grouped based on the resource you are calling so if there are two resources called Booking and Auth then we create two classes named Booking and Auth.  Each function is tied to an individual request that can be called multiple times.  This means if the request changes it requires a single change to propagate through the framework.</li>
<li>Payloads - Payloads that are required for requests and responses are stored in this area.  The idea is similar to the API area in that one class is responsible for one payload that may be called multiple times.  Again, this means if the payload changes it requires a single change to propagate through the framework.</li>
</ul>

## Setup

Each framework has been setup using their respective package manager and there is an assumption you know how to use it.  Simple use the package manager in each to pull down dependencies to get running.

All frameworks have been designed to run tests against [https://github.com/mwinteringham/restful-booker](https://github.com/mwinteringham/restful-booker) so to run the tests you will need to have an instance of [restful-booker](https://github.com/mwinteringham/restful-booker) running locally.
