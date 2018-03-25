import React from 'react';
import { Card, CardText } from 'material-ui/Card';
import { ViewTitle, WithPermission } from 'admin-on-rest';
import ViewEmployeesButton from './ViewEmployeesButton';

export default () => (
    <Card>
        {/* Manager Dashboard */}
        <WithPermission value="Manager">
          <ViewTitle title="Manager Dashboard" />
          {/*<CardText>Lorem ipsum sic dolor amet...</CardText>*/}
          <ViewEmployeesButton />
        </WithPermission>
        {/* New Hire Dashboard */}
        <WithPermission value="NewHire">
          <ViewTitle title="New Hire Dashboard" />
          {/*<CardText></CardText>*/}
        </WithPermission>
    </Card>
);
