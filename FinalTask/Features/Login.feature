Feature: Login Test

  Scenario: Login with invalid username
  Given I am on the login page
  When I enter username "invalid_user" and password "secret_sauce"
  And I click the login button
  Then I should see an error message "Epic sadface: Username and password do not match any user in this service"

Scenario: Login with invalid password
  Given I am on the login page
  When I enter username "standard_user" and password "invalid_password"
  And I click the login button
  Then I should see an error message "Epic sadface: Username and password do not match any user in this service"

  Scenario: Login with valid credentials
    Given I am on the login page
    When I enter username "standard_user" and password "secret_sauce"
    And I click the login button
    Then I should be redirected to the dashboard