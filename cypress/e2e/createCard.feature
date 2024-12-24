Feature: create card in trello website

    Scenario: validate the user can create card

    Given The user navigate to the board
    When Clicks add a card button
    And Types card name in card title input field 
    And Clicks on add card button
    Then The card will be created