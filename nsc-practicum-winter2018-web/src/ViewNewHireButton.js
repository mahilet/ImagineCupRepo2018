import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import FlatButton from 'material-ui/FlatButton';
import { showNotification as showNotificationAction } from 'admin-on-rest';
import { push as pushAction } from 'react-router-redux';

class ViewNewHireButton extends Component {
    handleClick = () => {
        const { push, record, showNotification } = this.props;

        // point the user's browser to this users page
        push(`/user/${record.id}/show`);

        // Display a notification to the browser 
        showNotification(`Viewing ${record.firstName}`);
    }

    render() {
        return <FlatButton label="View" onClick={this.handleClick} />;
    }
}

ViewNewHireButton.propTypes = {
    push: PropTypes.func,
    record: PropTypes.object,
    showNotification: PropTypes.func,
};

export default connect(null, {
    showNotification: showNotificationAction,
    push: pushAction,
})(ViewNewHireButton);
