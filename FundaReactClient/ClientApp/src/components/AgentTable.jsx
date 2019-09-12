import React, { Component } from 'react';

export default class AgentTable extends Component {
	render() {
		// Retrieve the list of top agents
		const agents = this.props.agents;

		return (
			<div className="agent-table">
				<table>
					<tr>
						<th>Agent ID</th>
						<th>Name</th>
						<th>Properties Count</th>
					</tr>
				</table>
			</div>
		);
	}
}
