//https://api.trello.com/1/cards/{id}?key=APIKey&token=APIToken

/// <reference types = "cypress" />
import { Given , When , Then } from "cypress-cucumber-preprocessor/steps";
import datautils from "../../support/datautils.cy";
import createcardactions from "../../pageObjects/createCard/actions.cy";
//import createcardassertions from "../../pageObjects/createCard/assertion.cy";
import DeletecardActions from "../../pageObjects/deleteExistCard/Actions.cy";
import Assertioncarddelete from "../../pageObjects/deleteExistCard/Assertions.cy";


const DeletecardAction = new DeletecardActions()
const datautil = new datautils()
const boardname = "Q1"
let boardurl,boardid
const createcardaction = new createcardactions()
const cardname = "mycard"
const Assertioncarddelet = new Assertioncarddelete()
//let carddeletename

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
 createcardaction.clickonAddacardbutton()
 createcardaction.Typeincardinputfield(cardname)
 createcardaction.clickonAddcardbutton()
})
//quick-card-editor-archive
When("Move card to archive",()=>{
   
    DeletecardAction.Deletecard(cardname)
    
})
Then("The card will delete",()=>{
       cy.log("assert")
       Assertioncarddelet.assertafterdel()
})




after(()=>{
    cy.wait(3000)
    datautil.deleteboard(boardid)
})