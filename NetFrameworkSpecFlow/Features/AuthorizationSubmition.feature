Feature: AuthorizationSubmition
	
@mytag
Scenario: Successful Authorization
	Given As a default user with Authorization Permitions enabled I login and go to search Authorization page
	And I populate patient search page with default values
	When Create authorization page is filled for service type 'Chemoterapy' with values from the 'ChemoterapyDefault.yaml'
	Then I can see Authorization details page
