import { Given , When , Then } from "cypress-cucumber-preprocessor/steps";
import createBoardActions from "../../pageObjects/createBoard/actions.cy";
import createBoardAssertions from "../../pageObjects/createBoard/assertion.cy";

const createBoardAction = new createBoardActions();
const createBoardAssertion = new createBoardAssertions();

const boardName = "MyFirstBoard";

Given("The user login to trello website",()=>{
    cy.loginToTrello()
})

When("Clicks on Create button in navbar",()=>{
    createBoardAction.clickOnNavbarCreateButton()
})

When("Choose create board option",()=>{
    createBoardAction.clickOnCreateBoardOption()
})

When("Types board name in board title field",()=>{
    createBoardAction.typeInBoardTitleInputField(boardName)
})

When("Clicks on Create button",()=>{
    createBoardAction.clickOnCreateButton();
})

Then("The board will created successfully",()=>{
    createBoardAssertion.checkBoardNameIsContain(boardName)
})