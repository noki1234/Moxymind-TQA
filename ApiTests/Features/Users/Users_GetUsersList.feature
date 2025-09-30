Feature: Users_GetUsersList
   
Scenario: GetUsersList - should succeed - check response data
    When I retrieve users from page-'2'
    Then I see users list values: page-'2' perPage-'6' total-'12' totalPages-'2'
    And I see user in list on position-'1' has values: id-'7' email-'michael.lawson@reqres.in' firstname-'Michael' lastname-'Lawson' avatar-'https://reqres.in/img/faces/7-image.jpg'
    And I see user in list on position-'2' has values: id-'8' email-'lindsay.ferguson@reqres.in' firstname-'Lindsay' lastname-'Ferguson' avatar-'https://reqres.in/img/faces/8-image.jpg'
    And I see user list contains usersCount-'6' per page
    
    
Scenario Outline: GetUserList - should succeed - check response data type
    When I retrieve users from page-'2'
    Then I see response value-'<valueName>' is dataType-'<dataType>'
Examples:    
| id | valueName          | dataType |
| 01 | page               | integer  |
| 02 | per_page           | integer  |
| 03 | total              | integer  |
| 04 | total_pages        | integer  |
| 05 | data               | array    |
| 06 | data[0].id         | int      |
| 07 | data[0].email      | string   |
| 08 | data[0].first_name | string   |
| 09 | data[0].last_name  | string   |
| 10 | data[0].avatar     | string   |
| 11 | support            | object   |
| 12 | support.url        | string   |
| 13 | support.text       | string   |

Scenario: GetUsersList - should succeed - count of all users should equal total
    When I retrieve users from page-'1'
    And I retrieve users from page-'2'
    Then I see count of all received users match with total count
    
    


