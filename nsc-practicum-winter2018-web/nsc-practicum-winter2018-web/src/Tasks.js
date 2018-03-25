/* Tasks.js

The objective of this component is to list a NewHire's list of tasks and allow the user to modify the status of individual tasks.
"TaskList" to display user tasks.
"TaskStatusEdit" to edit the task status
"TaskSave" to save the changes to the task statuses
"TaskCancel" cancel the changes make to the task statuses
"TaskProgress" displays the percentage complete of tasks

@author  Karen Petersen
@version 1.0.0
@since   2018-03-06 */
import React from 'react';

//import statements that utilize admin-on-rest components
import { Line } from 'rc-progress';
import {
  Datagrid,
  Edit,
  EditButton,
  EmailField,
  Filter,
  FunctionField,
  List,
  RadioButtonGroupInput,
  ReferenceField,
  SimpleForm,
  SimpleShowLayout,
  Show,
  TextField,
  TextInput } from 'admin-on-rest';

//import SaveButton from './SaveButton';
//import CancelButton from './CancelButton';

// Admin-on-rest has a built in function that queries a JSON response from an api
const PostFilter = (props) => (
    <Filter {...props}>
        <TextInput label="Search" source="q" alwaysOn />
    </Filter>
);


//A function that gets the Id from the User resource and redisplays it back into the title.
//For example "Editing User:" <ID>
//@param userRecord: The user resource in the API.
const UserTitle = ({ userRecord }) => {
    return <span> Editing User {userRecord ? `"${userRecord.id}"` : ''}</span>;
};

//FunctionField Progress has hardcoded values for initial view of progress bar
//A component that displays a simple list of tasks.
//Admin-on-rest utilizes a component called <List> to grab information from the API.
//This information is displayed in a datagrid composed of different fields (Text/Email in this case).
//"Source" defines the resource being used in the "User" or "Task" resources of the API.
//@param props: Each Field component maps a different field in the API response, specified by the source prop.
export const UserList = (props) => (
    <List {...props} filters={<PostFilter />}>
        <Datagrid bodyOptions={{ stripedRows: true}}>
            <TextField source="firstName" />
            <TextField source="lastName" />
            <TextField source="email" />
            <TextField source="phone" />
            <TextField source="type" />
            <FunctionField label="Progress" render= {function render() { return ( <Line percent="40" strokeWidth="1" strokeColor="#38bcd5" />);}} />
        </Datagrid>
    </List>
);

export const UserShow = (props) => (
    <Show {...props}>
        <SimpleShowLayout>
            <TextField source="id" />
            <TextField source="firstName" />
            <TextField source="lastName" />
            <EmailField source="email" />
            <TextField source="phone" />
            <TextField source="type" />
        </SimpleShowLayout>
    </Show>
);

export default UserList;