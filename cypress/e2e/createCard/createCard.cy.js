/// <reference types = "cypress" />
import { Given , When , Then } from "cypress-cucumber-preprocessor/steps";
import datautils from "../../support/datautils.cy";
import createcardactions from "../../pageObjects/createCard/actions.cy";
import createcardassertions from "../../pageObjects/createCard/assertion.cy";


const datautil = new datautils()
const boardname = "Q1"
let boardurl,boardid
const createcardaction = new createcardactions()
const cardname = "mycard"
const createcardassertion = new createcardassertions()
before(()=>{
    //create board using request
    datautil.createboard(boardname)
    .then((response)=>{
        cy.log(response.body.url)
        boardurl=response.body.url
        boardid = response.body.id
    })
    cy.loginToTrello()
})

Given("The user navigate to the board",()=>{
 createcardaction.openboard(boardurl)
})

When("Clicks add a card button",()=>{
    createcardaction.clickonAddacardbutton()
})

When("Types card name in card title input field",()=>{
    createcardaction.Typeincardinputfield(cardname)
})

When("Clicks on add card button",()=>{
    createcardaction.clickonAddcardbutton()
})

Then("The card will be created",()=>{
    createcardassertion.checklistconaincard(cardname)
})

after(()=>{
    cy.wait(3000)
    datautil.deleteboard(boardid)
})