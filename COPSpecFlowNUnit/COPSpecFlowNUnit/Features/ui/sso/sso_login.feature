Feature: Single Sing On Login in Cloudmore portal

# SSO Broker User		: Niklas
	 		

@CopUI
@SSO
@SSOAuthentication		
Scenario: Niklas logs in Cloudmore portal with his microsoft account. 
	Given Niklas submits his microsoft e-mail to Cloudmore portal
	When Niklas submits his microsoft credentials to Microsoft
	Then Niklas is authenticated successfully to Cloudmore portal