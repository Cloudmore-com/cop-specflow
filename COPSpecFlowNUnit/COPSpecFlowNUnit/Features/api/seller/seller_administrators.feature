@CopApi
@SellerAdministrator
Feature: Seller Administrator

# Host admin user	: 	Micheal
# Seller			: 	Gridheart
# 	Seller Admin	: 	Mark
#	Seller Admin	:	Allister		
		
@CopApi
@HostAdmin
@SellerAdministrator
Scenario: Micheal creates seller admin via API for Gridheart.
	When Micheal sends valid information to create seller admin for Gridheart
	Then Seller administrator is created successfully for Gridheart

@CopApi
@Seller
@SellerAdministrator    
Scenario: Mark creates seller admin via API for Gridheart.
	Given Mark has granted access to use API
	When Mark sends valid information to create seller admin for Gridheart
	Then Seller administrator is created successfully for Gridheart