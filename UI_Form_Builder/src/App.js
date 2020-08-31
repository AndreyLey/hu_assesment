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
  const [url, setUrl] = useState('http://localhost:5050/');
  console.log(url);
    return (
      <Router>
        <Switch>
          <Route exact path="/">
            <FormSummary url={url} setFormId={setFormId} />
          </Route>
          
          <Route path="/form_builder">
            <FormBuilder url={url} form_id={form_Id} history={history}/>
          </Route>

          <Route path="/submission">
            <Submission url={url} form_id={form_Id} history={history}/>
          </Route>

          <Route path="/submited">
            <Submited url={url} form_id={form_Id}/>
          </Route>
        </Switch>
      </Router>
    );
  

}

export default App;
