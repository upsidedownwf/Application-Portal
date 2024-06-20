# Application Portal
With this simple Web API companies can create application forms for various purposes and actually collect applications submitted by various candidates.

## Build

Run `dotnet build` from a terminal in the application folder (Application Portal) to build the app.

## Running application
Run `dotnet run` from a terminal in the API project folder (Application Portal\ApplicationPortal.API) and visit `https://localhost:7177` on your browser to access the api.

### Technical Notes from developer
I have tied question to an appplication form such that the questions cannot be saved individually but rather along with the application form.

I also categorized the application form into two major sections namely **Personal Information** section and **Additional Questions** section as seen in the UI from the figma file, I have made the assumption that all forms would have some standard field/questions in the Personal Information section e.g First Name, Last Name, Phone Number etc and as such modelled them as boolean properties whose value depend on the show/hide toggle button from the UI (true when shown, false when hidden), because we can also add custom questions/fields to the Personal Information section as seen in the UI too, I have modelled a List\<Questions\> property to store these custom questions too. Please check PersonalInformationQuestion class.

I have structured the project in such a way that each concept i.e question, application and application form is seperated and handled in diffrerent controllers so as its easier to maintain and more features can be added in a clean way e.g from the UI there's a functionality to delete a question in an application form, such functionality can be added in a delete method for the Questions Controller and implemented cleanly.
There are two controllers to facilitate this;
1. **The Form Controller:** 
    1. AddForm: This is a POST method to create/save a new application form.
    2. GetForm: This is a GET method to retrieve a saved form.
2. **The Questions Controller:**
    1. GetAllQuestions: This is a GET all method to retrieve all saved questions for a saved form.
    2. UpdateQuestion: This is a PUT method to edit a question for a saved form.
3. **The Application Controller:**
    1. GetApplication: This is a GET method to retrieve a saved application.
    2. AddApplication: This is a POST method to save an application for a saved form.

I have also attached some sample payload (in the samplepayload.js file for adding a new application form and submitting a new application for easy testing.

Please feel free to reach out for any further clarification/discussion.
