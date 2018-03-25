import React from 'react';
import { Admin, jsonServerRestClient, Resource} from 'admin-on-rest';
import MyLoginPage from './MyLoginPage';

import {UserList,
        UserShow} from './Users';
import {UserCreate,
        UserEdit} from './AddUserForm';

import Dashboard from './Dashboard';
import Menu from './Menu';

import authClient from './authClient';
import customRoutes from './customRoutes';

const UstOnboardingApp = () => (
    <Admin
        authClient={authClient}
        customRoutes={customRoutes}
        dashboard={Dashboard}
        loginPage={MyLoginPage}
        menu={Menu}
        restClient={jsonServerRestClient('http://localhost:4001')}
        title="UST New Hire Onboarding">
        <Resource
          name="user"
          create={UserCreate}
          edit={UserEdit}
          list={UserList}
          show={UserShow}  />
		<Resource 
			name="Workflows" />
      </Admin>
);

export default UstOnboardingApp;
