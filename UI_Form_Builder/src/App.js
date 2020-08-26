import React,{useState} from 'react';
import './App.css';
import { Route, BrowserRouter as Router, Switch,useHistory } from 'react-router-dom';
import FormSummary from './FormSummary/FormSummary';
import FormBuilder from './FormBuilder/FormBuilder';
import Submission from './Submission/Submission';
import Submited from './Submited/Submited';

function App(props) {
  const history = useHistory();
  const [form_Id, setFormId]=useState('');
  const [country, setCountry] =useState('Israel');
    return (
      <Router>
        <Switch>
          <Route exact path="/">
            <FormSummary  setFormId={setFormId} />
          </Route>
          
          <Route path="/form_builder">
            <FormBuilder form_id={form_Id} history={history}/>
          </Route>

          <Route path="/submission">
            <Submission form_id={form_Id} history={history}/>
          </Route>

          <Route path="/submited">
            <Submited form_id={form_Id}/>
          </Route>
        </Switch>
      </Router>
    );
  

}

export default App;
