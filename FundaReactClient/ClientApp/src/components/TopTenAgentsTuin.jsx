import React, { Component } from 'react';
import AgentTable from './AgentTable';
import * as request from 'superagent';

export default class TopTenAgentsTuin extends Component {
	state = {
		agents: []
	};

	loadTopAgents = () => {
		// Request top ten agents
		request
			.get('http://localhost:60398/api/funda/top10withtuin')
			.then((result) => {
				// Check if Result is successful
				if (result.status === 200) {
					// Assign the agents to the state
					this.setState({
						agents: result.body
					});
				}
			})
			.catch(console.error);
	};

	componentDidMount() {
		// Start loading the agents
		this.loadTopAgents();
	}

	render() {
		return (
			<div>
				<h1>Top 10 Agents with most properties that include a garden</h1>
				<AgentTable agents={this.state.agents} />
			</div>
		);
	}
}
