import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import RateManagement from './components/RateManagement';

function App() {
    return (
        <Router>
            <Switch>
                <Route path="/rates" component={RateManagement} />
                <Route path="/**" component={() => <h1>404 Not Found</h1>} />
            </Switch>
        </Router>
    );
}

export default App;
