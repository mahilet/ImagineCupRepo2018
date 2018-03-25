/* userForm.js

The objective of this component is to create forms which the user can enact upon to perform different actions.
"UserList" to display users and perform actions upon them (Create and edit). "UserCreate" to create a user.
"UserEdit" to delete or edit a user. 

Version 1.0.5 Update:

Fixed some compiling errors. Parsed date and reformatted/validated phone numbers.

@author  Satoru Ouchi
@version 1.0.5
@since   2018-03-20 */
import React from 'react';
//Our import statements that utilize "admin-on-rest's" components. 
import {Create,
        DateInput,
        DisabledInput,  
        Edit, 
        EditButton,
        List,
        TextInput,
        ReferenceInput,
        SelectInput,
        SimpleForm,
        NumberInput} from 'admin-on-rest';

import { DateParser } from './DateParser.js';



//A function that gets the Id from the User resource and redisplays it back into the title.
//For example "Editing User:" <ID>
//@param userRecord: The user resource in the API. 
const UserTitle = ({ userRecord }) => {
    return <span> Editing User {userRecord ? `"${userRecord.id}"` : ''}</span>;
};



//A function to validate user creation. If a field that has been entered is invalid, the form will
//throw an error.
//@param inputValues: An object that contains all the values that have been input into the form.
//We can call specific values such as "id" with inputValues.id.
const validateUserCreation = (inputValues) => {

    //A file that contains error messages for the user forms.
    var jsonData = require('../src/userFormErrors.json');

    //A regex value that is used to test against the inputValue. Recognized email values.
    var emailRegex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    
    //Errors that are to be displayed if a user does not enter correct input. Currently empty.
    const errors = {};

    //An if block that checks for valid input.
    if (!inputValues.id) {
        //Error message: "This field required."
        errors.id = jsonData[0].message;
    }
    if (!inputValues.firstName) {
        //Error message: "This field required."
        errors.firstName = jsonData[0].message;
    }
    if (!inputValues.lastName) {
        //Error message: "This field required."
        errors.lastName = jsonData[0].message;
    }
    if (emailRegex.test(inputValues.email)  === false) {
        //Error message: "Requires valid email."
        errors.email = jsonData[2].message;
    }

    if(!inputValues.phone){
        //Error message: "This field required."
        errors.phone = jsonData[0].message;
    } 

    else if (inputValues.phone.toString().length > 10 ) {
        //Error message: "Phone number must be 10 digits or less."
        errors.phone = jsonData[4].message;
    }

    else if (inputValues.phone.toString().length < 10 ) {
        //Error message: "Please enter an area code."
        errors.phone = jsonData[5].message;
    }

    if (!inputValues.type) {
        //Error message: "User must be a manager or employee."
        errors.type = jsonData[3].message;
    }
    if (!inputValues.StartDate) {
        //Error message: "This field required."
        errors.StartDate = jsonData[0].message;
    }
    return errors
};

//A component that redirects the user to a form that creates a user. 
//Similar to the <List> component, the <Create> component defines what information is to be written to
//what resource. This is further specified by "source." This form calls for validation and redirects to UserList
//when save is hit. <SimpleForm> is Admin-on-Rest's <Form>. Provides a few different functions such as redirection
//and validation.
//@param props: Each field component is mapped to a different field in the API response, specified by the source prop.

//Sets default values for Sources "Tasks" and "employees" when the user is created.
const userDefaultValue = { Tasks: new Array(), employees: new Array()};

export const UserCreate = (props) => (
    <Create {...props}>
        <SimpleForm validate={validateUserCreation} defaultValue={userDefaultValue} redirect="list" >
            <TextInput label="Id" source="id" />     
            <TextInput label = "First Name" source="firstName" />
            <TextInput label = "Last Name" source="lastName" />
            <TextInput label = "Email" source="email" />
            <NumberInput label = "Phone" source="phone" />
            <SelectInput source="type" label = "Type" choices={[
                { id: 'manager', name: 'Manager' },
                { id: 'employee', name: 'Employee' },
            ]} />
            <DateInput parse={DateParser} label = "Start Date" source="StartDate"/>
            <ReferenceInput label="Workflow" source="Workflow" reference="Workflows" allowEmpty>
                <SelectInput allowEmpty optionText="name" />
            </ReferenceInput>
        </SimpleForm>
    </Create>
);

//A component that redirects the user to a form that edits a user. This redirection happens from UserList.
//Similar to the <List> component, the <Edit> component defines what information is to be edited to
//what resource. This is further defined by "source." This form calls for validationand redirects to UserList
//when save is hit. This form utilizes a RadioButtonGroup to force the user to choose between two different
//types of employees.
//@param props: Each field component is mapped to a different field in the API response, specified by the source prop.
export const UserEdit = (props) => (
    <Edit title={<UserTitle />} {...props}>
        <SimpleForm validate={validateUserCreation} redirect="list">
            <DisabledInput label="Id" source="id" />
            <TextInput label = "First Name" source="firstName" />
            <TextInput label = "Last Name" source="lastName" />
            <TextInput label = "Email" source="email" />
            <NumberInput label = "Phone" source="phone" />
            <SelectInput source="type" label = "Type" choices={[
                { id: 'manager', name: 'Manager' },
                { id: 'employee', name: 'Employee' },
            ]} />
            <DateInput parse={DateParser} label = "Start Date" source="StartDate"/>
            <ReferenceInput label="Workflow" source="Workflow" reference="Workflows"  allowEmpty>
                <SelectInput optionText="name" allowEmpty />
            </ReferenceInput>
        </SimpleForm>
    </Edit>
);



