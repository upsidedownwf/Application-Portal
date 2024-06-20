// Sample Payload to create a form
// url: https://localhost:7177/forms
{
    "name": "Summer Internship Program",
        "description": "A comprehensive summer internship program.",
            "personalInformation": {
        "firstName": true,
            "lastName": true,
                "phoneNumber": true,
                    "email": true,
                        "nationality": true,
                            "birthDate": true,
                                "residence": true,
                                    "gender": true,
                                        "idNumber": true
    },
    "additionalQuestions": {
        "questions": [
            {
                "type": "Paragraph",
                "title": "Tell us about yourself"
            },
            {
                "type": "YesNo",
                "title": "Do you have any prior experience?"
            },
            {
                "type": "Dropdown",
                "title": "Select your education level",
                "choices": [
                    "High School",
                    "PhD"
                ]
            },
            {
                "type": "MultipleChoice",
                "title": "Which programming languages do you know?",
                "choices": [
                    "C#",
                    "Java",
                    "Python",
                    "JavaScript"
                ]
            },
            {
                "type": "Date",
                "title": "When can you start?"
            },
            {
                "type": "Number",
                "title": "Years of experience"
            }
        ]
    }
}





// Sample Payload to submit an application
// url: https://localhost:7177/forms/{formId}/applications
{
    "formId": "string",
        "personalInformation": {
        "firstName": "John",
            "lastName": "Doe",
                "phoneNumber": "1234567",
                    "email": "jane.doe@gmail.com",
                        "nationality": "british",
                            "birthDate": "2001-09-23",
                                "residence": "essex",
                                    "gender": "male",
                                        "idNumber": "1223445"
    },
    "additionalAnswers": [
        {
            "questionId": "8d1bdc88-ecca-4126-b73b-c93ce8fbecda",
            "value": ["I am a  boy"]
        },
        {
            "questionId": "20a0385c-851b-435e-a6ba-5cc7a07ebc44",
            "value": ["True"]
        },
        {
            "questionId": "  37d77cb1-3a3e-4d68-9ccb-6d2e715a79cd",
            "value": ["B.Eng."],
            "other": true
        },
        {
            "questionId": "e5ded54a-1a9d-4818-b57b-0d65c2bd6e17",
            "value": ["C#", "Javascript"],
            "other": false
        },
        {
            "questionId": "281347fc-41ef-437f-acf4-ffdf412d23a",
            "value": ["2024-04-24"]
        },
        {
            "questionId": "8f6375d3-f1cc-4008-ac44-df87e686d99c",
            "value": ["2"]
        }
    ]
}



// Sample Payload to update a question in a form
// url: https://localhost:7177/forms/{formId}/questions/{questionId}
{
    "type": "Dropdown",
        "title": "Select your education level",
            "choices": [
                "High School",
                "Undergraduate",
                "PhD"
            ]
}


