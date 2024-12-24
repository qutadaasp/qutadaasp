class createcardactions{
    openboard(boardurl){
        cy.visit(boardurl)
        return this
    }

    clickonAddacardbutton(){
          cy.findByTestId("list-add-card-button").first().click()
          return this
    }

    Typeincardinputfield(cardname){
        cy.findByTestId("list-card-composer-textarea").type(cardname)
        return this
    }
    clickonAddcardbutton(){
        cy.findByTestId("list-card-composer-add-card-button").click()
        return this
  }
}

export default createcardactions