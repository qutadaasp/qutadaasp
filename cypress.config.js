const { defineConfig } = require("cypress");
const cucumber = require("cypress-cucumber-preprocessor").default;
module.exports = defineConfig({
 e2e: {
  chromeWebSecurity : false,
   specPattern: "**/*.feature",
   baseUrl:"http://trello.com",
   setupNodeEvents(on, config) {
     on("file:preprocessor", cucumber());
   },
}
});