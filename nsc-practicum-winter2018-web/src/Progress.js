import React, {Component} from 'react';
import {Line} from 'rc-progress';

//This custom component produces a progress bar that displays the 
//number of tasks that have been completed by each user out of the total
class Progress extends Component {
  constructor(props){
    super(props);
    this.state ={
    }
  }
	componentDidMount(workflowEndpoint) {
	
		//get count of user's completed tasks
		this.setState({  userTaskCount : (this.props.record.Tasks).length});
					
		//fetch tasks from workflow
		fetch   ( 'http://localhost:4001/Workflows/' + this.props.record.Workflow)
			.then(function(response) {
				if (!response.ok) {
					throw Error(response.statusText);
				}
				return response;
   			 }).then(results => {
				return results.json();
			}).then(data => {

			//get count of workflow tasks
			let taskCount = data.tasks.length;

			//divide count of user tasks by count total tasks to get progress percent
			// multiply this by 100 to format it as integer that rc-progress accepts
			this.setState({ progressPercent : (this.state.userTaskCount/taskCount)*100});
			
		})
	}
	
	//return rendered line using Progress Percent value
	render() {
		return (
		  <div>
			<Line percent={this.state.progressPercent} strokeWidth="20" strokeColor="#38bcd5" />
		  </div>
		);
	}
}

export default Progress;
