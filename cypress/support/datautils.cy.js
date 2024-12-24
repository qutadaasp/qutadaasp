import { key,token } from "../support/constants.cy";

class datautils {
    createboard = (boardname)=>{
     return   cy.request("POST",`https://api.trello.com/1/boards/?name=${boardname}&key=${key}&token=${token}`)
    }
    deleteboard =(boardid)=>{
        return     cy.request("DELETE",`https://api.trello.com/1/boards/${boardid}?key=${key}&token=${token}`)

    }
}
export default datautils