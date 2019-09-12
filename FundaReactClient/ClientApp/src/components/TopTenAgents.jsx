import React, { Component } from 'react';
import AgentTable from './AgentTable';
import * as request from 'superagent';

export default class TopTenAgents extends Component {
	state = {
		agents: []
	};

	loadTopAgents = () => {
		request
			.get('http://localhost:60398/api/funda/top10')
			.then((result) => {
				console.log(result);
			})
			.catch(console.error);
	};

	componentDidMount() {
		this.loadTopAgents();
	}

	render() {
		return (
			<div>
				<h1>Top 10 Agents with most properties</h1>
				<AgentTable agents="test" />
			</div>
		);
	}
}
