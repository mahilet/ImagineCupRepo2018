import {  AUTH_CHECK,
          AUTH_ERROR,
          AUTH_LOGIN,
          AUTH_LOGOUT,
          AUTH_GET_PERMISSIONS
         } from 'admin-on-rest';
import { authContext } from './adalConfig/adalConfig';

export default (type, params) => {
    // Called when the user attempts to log in
  
    if (type === AUTH_LOGIN) {
        var { username } = params
        localStorage.setItem('username', username);

        if (username === 'Manager') {
          // Display Manager UI display
          localStorage.setItem('role', 'Manager')
          return Promise.resolve();

        } else {
          // Display New Hire UI display
          localStorage.setItem('role', 'NewHire')
          return Promise.resolve();
        }
    }
    
    // Called when the user clicks on the logout button
    if (type === AUTH_LOGOUT) {
        if (localStorage.getItem('role') !== null){ 
            localStorage.clear(); //clear role and username
            authContext.logOut(); //log out of Azure AD
        }
        return Promise.resolve();
    }

    // Called when the API returns an error
    if (type === AUTH_ERROR) {
        const { status } = params;
        if (status === 401 || status === 403) {
            return Promise.reject();
        }
        return Promise.resolve();
    }

    // Called when the user navigates to a new location
    if (type === AUTH_CHECK) {
        return localStorage.getItem('username') ? Promise.resolve() : Promise.reject();
    }

    // Called to check users permissions
    if (type === AUTH_GET_PERMISSIONS) {
        const role = localStorage.getItem('role');
        return Promise.resolve(role);
    }
    return Promise.reject('Unknown method');
};
