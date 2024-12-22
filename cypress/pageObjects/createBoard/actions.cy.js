class createBoardActions {

    clickOnNavbarCreateButton(){
        cy.findByTestId("header-create-menu-button").click();
        return this; 
    }

    clickOnCreateBoardOption(){
        cy.findByTestId("header-create-board-button").click();
        return this;
    }

    typeInBoardTitleInputField(boardName){
        cy.findByTestId("create-board-title-input").type(boardName)
        return this;
    }

    clickOnCreateButton(){
        cy.findByTestId("create-board-submit-button").click();
        cy.wait(3000)
        return this;
    }
}
export default createBoardActions;