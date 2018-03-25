import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import FlatButton from 'material-ui/FlatButton';
import { showNotification as showNotificationAction } from 'admin-on-rest';
import { push as pushAction } from 'react-router-redux';

class ViewEmployeesButton extends Component {
    handleClick = () => {
        const { push } = this.props;

        // point the user's browser to this users page
        push(`/user`);

    }

    render() {
        return <FlatButton
                  label="View Employees"
                  onClick={this.handleClick}
                  primary={true}/>;
    }
}

ViewEmployeesButton.propTypes = {
    push: PropTypes.func,
    record: PropTypes.object,
    showNotification: PropTypes.func,
};

export default connect(null, {
    showNotification: showNotificationAction,
    push: pushAction,
})(ViewEmployeesButton);
