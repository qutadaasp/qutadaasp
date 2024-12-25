class DeletecardActions{
    Deletecard(cardname){
        cy.findByTestId("trello-card").rightclick()
       
       //cy.findByTestId("quick-card-editor-card-front")
        //cy.findByTestId("quick-card-editor-archive").first().click()
        cy.get(".BppQGb2j7TfyB5").last().click()
        cy.get(".GDunJzzgFqQY_3").last().click()
        cy.get(".TJ69T0gm8D5GkA").eq(2).click()
        cy.get(".je6AvjOt_2Gpxt").last().click()
        cy.get("[aria-label=delete-confirm]").click()
        return this
    }
}

export default DeletecardActions