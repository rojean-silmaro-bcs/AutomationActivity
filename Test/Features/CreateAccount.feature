Feature: CreateAccount
	Sample given with parameters

@CreateAccount
Scenario: User Successfully create an account
	Given Ms as title, Hymie as first name, Test as last name, Mobile as phone number type, +639123456789 as mobile, bcs#@webjet.com.au as email, staddr as st. addr., Manila as city, Australia as country, QLD as state, 1234 as postcode, 123pass as password, town as security question, prov as security answer, 16/04/1998 as birthdate, https://devci.webjet.com.au/FlightSearch as url
	When I go to home page
	Then sign up for an account using the given details
