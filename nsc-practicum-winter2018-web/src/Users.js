import React from 'react';
import {
  Datagrid,
  EmailField,
  Filter,
  FunctionField,
  List,
  SimpleShowLayout,
  Show,
  TextField,
  TextInput } from 'admin-on-rest';
import Progress from './Progress';
import ViewNewHireButton from './ViewNewHireButton';

// Admin-on-rest has a built in function that queries a JSON response from an api
const PostFilter = (props) => (
    <Filter {...props}>
        <TextInput label="Search" source="q" alwaysOn />
    </Filter>
);

//A function that gets the Id from the User resource and redisplays it back into the title.
//For example "User Information:" <ID>
//@param userRecord: The user resource in the API.
const UserTitle = ({ userRecord }) => {
    return <span> User Information {userRecord ? `"${userRecord.id}"` : ''}</span>;
};
//FunctionField Progress has hardcoded values for initial view of progress bar
//A component that displays a simple list of users.
//Admin-on-rest utilizes a component called <List> to grab information from the API.
//This information is displayed in a datagrid composed of different fields (Text/Email in this case).
//"Source" defines the resource being used in the "User" resource of the API.
//@param props: Each Field component maps a different field in the API response, specified by the source prop.
export const UserList = (props) => (
    <List title="Employees" {...props} filter={{ "type":"employee" }} filters={<PostFilter />}>
        <Datagrid bodyOptions={{ stripedRows: true}}>
            <TextField source="firstName" />
            <TextField source="lastName" />
            <TextField source="email" />
            <FunctionField label="Phone" source="phone" render={record => `${String(record.phone).replace(/\D/g, '').replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3")}`} />
            <TextField source="type" />
            <TextField source="StartDate" />
			<Progress />
            <ViewNewHireButton />
        </Datagrid>
    </List>
);


export const UserShow = (props) => (
    <Show title={<UserTitle />} {...props}>
        <SimpleShowLayout>
            <TextField source="id" />
            <TextField source="firstName" />
            <TextField source="lastName" />
            <EmailField source="email" />
            <TextField source="phone" />
            <TextField source="type" />
            <TextField source="StartDate" />
        </SimpleShowLayout>
    </Show>
);

export default UserList;
