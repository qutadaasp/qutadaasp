class createcardassertions{
     checklistconaincard(cardname){
        cy.findByTestId("card-name").should("contain",cardname)
        return this
     }
}

export default createcardassertions