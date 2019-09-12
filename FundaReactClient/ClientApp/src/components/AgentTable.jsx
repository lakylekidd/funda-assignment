import React, { Component } from 'react';
import './AgentTable.css';

export default class AgentTable extends Component {
	/**
     * Renders the table rows for each agent passed in the parameter
     */
	renderTableRows = (agents) => {
		return agents.map((agent) => {
			return (
				<tr key={agent.makelaarId}>
					<td>{agent.makelaarId}</td>
					<td>{agent.makelaarNaam}</td>
					<td>{agent.properties.length}</td>
				</tr>
			);
		});
	};
	/**
     * Renders an entire table with the top ten agents
     */
	renderAgentTabel = (agents) => (
		<table>
			<thead>
				<tr>
					<th>Agent ID</th>
					<th>Name</th>
					<th>Properties Count</th>
				</tr>
			</thead>
			<tbody>{this.renderTableRows(agents)}</tbody>
		</table>
	);
	render() {
		// Retrieve the list of top agents
		const agents = this.props.agents;
		return (
			<div className="agent-table">
				{agents.length > 0 && this.renderAgentTabel(agents)}
				{agents.length === 0 && <p className="loading">Loading the top ten agents...</p>}
			</div>
		);
	}
}
