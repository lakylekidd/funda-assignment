import React, { Component } from 'react';

export class Home extends Component {
	static displayName = Home.name;

	render() {
		return (
			<div>
				<h1>Hey there! &#128521;</h1>
				<p>
					Welcome to my <a href="https://www.funda.nl/en/">Funda</a> assignment!
				</p>
				<p>
					I hope you like my implementation of the requirements for this assignment. I know that I should not
					spend more than 4 hours on this assignment and hopefully I have implemented enough to show a part of
					my skills in C#, JavaScript and CSS.
				</p>
				For this client application I used the following technologies:
				<p />
				<ul>
					<li>ASP.NET Core 2.2</li>
					<li>React.js</li>
					<li>CSS</li>
					<li>Superagent</li>
				</ul>
				<p>
					Please have a look around the site as there are two pages where you can see a list of Agencies
					ranked by number of properties as requested.
				</p>
				<q>
					<b>Please Note:</b> due to the heave request operations on the API, it may take some time to load
					the data.
				</q>
				<br />
				<br />
				<p>Thank you for considering my application! &#10084;</p>
				<a href="https://linkedin.com/in/billy-vlachos/">Billy Vlachos</a>
			</div>
		);
	}
}
