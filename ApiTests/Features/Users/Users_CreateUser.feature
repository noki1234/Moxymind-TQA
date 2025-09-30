Feature: Users_CreateUser
   
Scenario Outline: CreateUser - should succeed - with valid data
    When I create user with values: name-'<name>' job-'<job>'
    Then I see created user values: name-'<name>' job-'<job>' createdAt-'now'
    And I see last response status code is 'Created'
    And I see last response time is under '1000'
Examples:
| id | name  | job        |
| 01 | James | Technician |
| 02 | Jack  | Artist     |
| 03 | Boris | Mechanic   |

@DataSource:../../TestData/Users.csv
Scenario: CreateUser - should succeed - with valid data - from external source 
    When I create user with values: name-'<Name>' job-'<Job>'
    Then I see created user values: name-'<Name>' job-'<Job>' createdAt-'now'
    And I see last response status code is 'Created'
    And I see last response time is under '1000'


Scenario Outline: CreateUser - should succeed - check response data type
    When I create user with values: name-'James' job-'Teacher'
    Then I see response value-'<valueName>' is dataType-'<dataType>'
    Examples:    
      | id | valueName | dataType |
      | 01 | name      | string   |
      | 02 | job       | string   |
      | 03 | id        | string   |
      | 04 | createdAt | date     |