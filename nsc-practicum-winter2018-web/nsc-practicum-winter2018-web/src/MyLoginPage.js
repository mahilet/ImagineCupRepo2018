import React, { Component } from 'react';
import { connect } from 'react-redux';
import RaisedButton from 'material-ui/RaisedButton'
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import { userLogin } from 'admin-on-rest';
import * as jwtDecode from 'jwt-decode';


//decode token
 var decodedToken = jwtDecode(window.sessionStorage.getItem("adal.idtoken"));
 var loginButtonValue = ("Proceed as " + decodedToken.name)

class MyLoginPage extends Component {

    submit = (e) => {
        e.preventDefault();
        // gather your data/credentials here
        const credentials = { username: decodedToken.name }

        // Dispatch the userLogin action (injected by connect)
        this.props.userLogin(credentials);
    }

    render() {
        return (
            <MuiThemeProvider>
            <form style ={formStyle} onSubmit={this.submit}>
            <RaisedButton backgroundColor='skyblue' type="submit" label={loginButtonValue}/>
            </form>
            </MuiThemeProvider>
        );
    }
};

var formStyle = {
    align: 'center',
    textAlign: 'center',
    marginTop: '100px'
}

export default connect(undefined, { userLogin })(MyLoginPage);