import React from 'react';
import { Route } from 'react-router-dom';

import NewUser from './NewUser';
import Tasks from './Tasks';
import UserList from './Users';

/* Set Custom Routing */
export default [
    <Route exact path="/NewUser" component={NewUser}/>,
    <Route exact path="/Tasks" component={Tasks}/>,
    <Route exact path="/Users" component={UserList}/>
];
