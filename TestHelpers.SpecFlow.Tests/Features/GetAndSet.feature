Feature: GetAndSet
	In order to reuse data between scenario steps
	As a SpecFlow developer
	I need a simple way to get and set objects

Scenario: Set and Get object without key
	Given I have called Set with value "Foo"
	When I call Get<string> 
	Then the result is "Foo"	

Scenario: Set and Get object with key
	Given I have called Set with value "Foo" and key "TheKey"
	When I call Get<string> with key "TheKey"
	Then the result is "Foo"	

Scenario: GetOrSet object without key when already set
	Given I have called Set with value "Foo"
	When I call GetOrSet<string> with default value "Bar" 
	Then the result is "Foo"	

Scenario: GetOrSet object with key when already set
	Given I have called Set with value "Foo" and key "TheKey"
	When I call GetOrSet<string> with key "TheKey" and default value "Bar"
	Then the result is "Foo"	

Scenario: GetOrSet object without key when not set	
	When I call GetOrSet<string> with default value "Bar" 
	Then the result is "Bar"	
	And the next call to Get<string> returns "Bar"

Scenario: GetOrSet object with key when not set	
	When I call GetOrSet<string> with key "TheKey" and default value "Bar"
	Then the result is "Bar"	
	And the next call to Get<string> with key "TheKey" returns "Bar"