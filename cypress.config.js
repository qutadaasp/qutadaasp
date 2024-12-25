const { defineConfig } = require("cypress");
const cucumber = require("cypress-cucumber-preprocessor").default;
module.exports = defineConfig({
 e2e: {
  chromeWebSecurity : false,
   specPattern: "**/*.feature",
   baseUrl:"http://trello.com",
   screenshotOnRunFailure : true,
   screenshotsFolder :"Test1",
   trashAssetsBeforeRuns:true,

   setupNodeEvents(on, config) {
     on("file:preprocessor", cucumber());
   },
}
});