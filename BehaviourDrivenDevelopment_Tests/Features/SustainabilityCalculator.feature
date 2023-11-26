Feature: Sustainability Calculator

  Scenario: Calculate sustainability weighting for Cycling
    Given I have a distance of 20 miles
    And I travel to work by Cycling
    And I travel for 5 days a week
    When I calculate the sustainability weighting
    Then the result should be 0.005 * 20 * (5 * 2)

  Scenario: Calculate sustainability weighting for Walking
    Given I have a distance of 5 miles
    And I travel to work by Walking
    And I travel for 3 days a week
    When I calculate the sustainability weighting
    Then the result should be 0.005 * 5 * (3 * 2)

  Scenario: Calculate sustainability weighting for Diesel
    Given I have a distance of 30 miles
    And I travel to work by Diesel
    And I travel for 4 days a week
    When I calculate the sustainability weighting
    Then the result should be 10 * 30 * (4 * 2)