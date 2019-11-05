import React, { Component } from 'react';
import { Header, Icon, List } from 'semantic-ui-react';
import './App.css';
import axios from 'axios';

class App extends Component {
  state = {
    weatherForecasts: []
  };

  componentDidMount() {
    axios.get('http://localhost:5000/weatherforecast').then(response => {
      this.setState({
        weatherForecasts: response.data
      });
    });
  }

  render() {
    return (
      <div>
        <Header as="h2">
          <Icon name="users" />
          <Header.Content>Reactivities</Header.Content>
        </Header>
        <List>
          {this.state.weatherForecasts.map((weatherForecast: any) => (
            <List.Item key={weatherForecast.id}>
              {weatherForecast.date}
            </List.Item>
          ))}
        </List>
      </div>
    );
  }
}

export default App;
