﻿Feature: FinalTask BBC testing functionality
  As a User
  I want to test few functions of the site
  So that I can be sure that site works correctly

   @BBC1
  Scenario Outline: Check main article on the site
    Given User opens '<homePage>' page
    When User clicks News button
    Then User checks that main <index> article contains '<text>'
    Examples:
      | homePage             | index | text                                                |
      | https://www.bbc.com/ | 0     | Anger as Texas police alter key details of shooting |

    @BBC1
   Scenario Outline: Check first <count> secondary articles
    Given User opens '<homePage>' page
    When User clicks News button
    Then User checks first <count> articles in '<order>'
    Examples:
      | homePage             | count | order                                                                                                                                                                                                                                                  |
      | https://www.bbc.com/ | 5     | Husband of killed Texas teacher 'dies of grief';Ancient DNA reveals secrets of Pompeii victims;'I'm proud my coming out inspired others in sport';Australia frees asylum family after public outcry;Amber Heard: It's easy to forget I'm a human being |

    @BBC1
   Scenario Outline: Check first secondary articles
    Given User opens '<homePage>' page
    And User clicks News button
    And User copies Coronavirus selection text
    And User clicks Search button
    And User insert copied text to Search field
    When User clicks Search request button
    Then User checks that <index> article contains '<text>'
    Examples:
      | homePage             | index  | text                                           |
      | https://www.bbc.com/ | 0      | Ministers give coronavirus restrictions update |

    @BBC1
   Scenario Outline: Check sending story with correct data
    Given User opens '<homePage>' page
    And User clicks News button
    And User clicks Coronavirus selection
    And User clicks <index> Your Coronavirus Stories selection
    And User clicks How to share with BBC News article
    And User closes pop up window
    And User fills form with data: story - <story>, name - <name>, email - <email>, contact number - <number>, location - <location>
    And User clicks on checkBox I accept the Terms of Service
    When User clicks Submit button
    Then User checks result of sending story, it must contain '<firstParagraph>' and '<secondParagraph>'
    Examples:
    | homePage             | index | story                                                         | name   | email                    | number       | location      | firstParagraph                                                                                               | secondParagraph                                                                       |
    | https://www.bbc.com/ | 0     | Sorry for interruption, it's just testing form for project:^) | Dmytro | gmailtestemail@gmail.com | 123123123123 | Ukraine, Kyiv | Hey Dmytro, thanks for asking your question: ;Sorry for interruption, it's just testing form for project:^); | If we're able to investigate it further, we'll email you at gmailtestemail@gmail.com. |

    @BBC1
   Scenario Outline: Check sending story with empty data
    Given User opens '<homePage>' page
    And User clicks News button
    And User clicks Coronavirus selection
    And User clicks <index> Your Coronavirus Stories selection
    And User clicks How to share with BBC News article
    And User closes pop up window
    And User fills form with data: story - <story>, name - <name>, email - <email>, contact number - <number>, location - <location>
    When User clicks Submit button
    Then User checks that error messages displayed: error story empty field - <errorStory>, error name empty field - <errorName>, error acceptance terms - <errorTerms>
    Examples:
      | homePage             | index | story | name | email | number | location | errorStory     | errorName           | errorTerms       |
      | https://www.bbc.com/ | 0     |       |      |       |        |          | can't be blank | Name can't be blank | must be accepted |

     @BBC1
   Scenario Outline: Check sending story with invalid email
    Given User opens '<homePage>' page
    And User clicks News button
    And User clicks Coronavirus selection
    And User clicks <index> Your Coronavirus Stories selection
    And User clicks How to share with BBC News article
    And User closes pop up window
    And User fills form with data: story - <story>, name - <name>, email - <email>, contact number - <number>, location - <location>
    And User clicks on checkBox I accept the Terms of Service
    When User clicks Submit button
    Then User checks error '<message>' because of invalid email
    Examples:
    | homePage             | index | story                                                         | name   | email          | number       | location      | message                  |
    | https://www.bbc.com/ | 0     | Sorry for interruption, it's just testing form for project:^) | Dmytro | incorrectemail | 123123123123 | Ukraine, Kyiv | Email address is invalid |

    
    @BBC2
   Scenario Outline: Check scores of football match with specified teams, championship, year and month
    Given User opens '<homePage>' page
    And User clicks Sport button
    And User clicks on <index> Football section
    And User clicks on Scores & Fixtures section
    And User enters <championship> in Enter a team or competition input
    And User chooses <index> from the drop down list
    And User select <month> and <year> of competition
    When User finds match between <team1> and <team2> with score for first team - <score1>, and score for second team - <score2>
    Then User compares displayed scores with scores from previous page and specified scores: <score1>, <score2>
    Examples:
      | homePage             | index | championship             | month | year | team1             | team2                        | score1 | score2 |
      | https://www.bbc.com/ | 0     | Scottish Championship    | JUL   | 2021 | Arbroath          | Inverness Caledonian Thistle | 0      | 1      |
      | https://www.bbc.com/ | 0     | EUROPA LEAGUE            | FEB   | 2022 | Borussia Dortmund | Rangers                      | 2      | 4      |
      | https://www.bbc.com/ | 0     | Europa Conference League | JUL   | 2021 | Linfield          | Borac Banja Luka             | 4      | 0      |
      | https://www.bbc.com/ | 0     | Africa Cup of Nations    | JAN   | 2022 | Egypt             | Morocco                      | 2      | 1      |
      | https://www.bbc.com/ | 0     | French Coupe de France   | JAN   | 2022 | Vannes            | Paris Saint Germain          | 0      | 4      |
      