import React from 'react';
import { connect } from 'react-redux';
import {  MenuItemLink,
          WithPermission,
          getResources } from 'admin-on-rest';

import AddUserIcon from 'material-ui/svg-icons/social/person-add';
import UserIcon from 'material-ui/svg-icons/social/group';
import ListIcon from 'material-ui/svg-icons/action/list';

var request = require('request')

var options = {
  url: 'https://apidevelopment.azurewebsites.net/user/test-id-demo5' //'http://nsc420winter2018practicum.azure-api.net/dev/user/test-id-demo5'

  /**
  headers: {
    'Ocp-Apim-Subscription-Key': '1dd0367c476f4785a3d00e7d713c6b10',
    'mode':'no-cors'
  }
  */
};

function callback(error, response, body) {
  if (!error && response.statusCode === 200) {
    var info = JSON.parse(body);
    console.log(info)
  }
  else {
    console.log(error)
  }
}

function sampleCall() {
  request.get(options, callback)
}

const Menu = ({ resources, onMenuTap, logout }) => (
    <div>
        {/* Display username within menu */}
        <div className="WelcomeUserStyle">Hello, {localStorage.getItem('username')}</div>

        {/* Manager Menu Options */}
        <WithPermission value="Manager">
            <MenuItemLink to="/User"
                          primaryText="Employees"
                          onClick={onMenuTap}
                          leftIcon={<UserIcon />}/>
            <MenuItemLink to="/user/create"
                          primaryText="New User"
                          onClick={onMenuTap}
                          leftIcon={<AddUserIcon />} />
        </WithPermission>

        {/* New Hire Menu Options */}
        <WithPermission value="NewHire">
            <MenuItemLink to="/Tasks"
                          primaryText="Tasks"
                          onClick={onMenuTap}
                          leftIcon={<ListIcon/>} />
        </WithPermission>

        {/* Default Menu Options */}
        {/*<MenuItemLink
                      primaryText="Sample API Call"
                      onClick={() => sampleCall()}
                      leftIcon={<ListIcon/>} /> */}
        {logout}
    </div>

);

const mapStateToProps = state => ({
    resources: getResources(state),
})
export default connect(mapStateToProps)(Menu);
