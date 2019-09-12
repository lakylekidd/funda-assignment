import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import TopTenAgents from './components/TopTenAgents';
import TopTenAgentsTuin from './components/TopTenAgentsTuin';

export default class App extends Component {
	static displayName = App.name;

	render() {
		return (
			<Layout>
				<Route exact path="/" component={Home} />
				<Route path="/agents/top10" component={TopTenAgents} />
				<Route path="/agents/top10tuin" component={TopTenAgentsTuin} />
			</Layout>
		);
	}
}
