import React, { useState,useEffect } from 'react';
import { Link, useHistory, useLocation} from 'react-router-dom';

function FormSummary(props) {
  const location = useLocation();
  const router = useHistory();
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [forms, setForms] = useState([]);

  const onClickSetFormId=(formId)=>{
    console.log('REGION IS:'+formId);
    props.setFormId(formId);
  }

  const loadContent = async()=>{
    try{
      var url='';
      console.log(url.concat(props.url,'forms/'));
      const response = await fetch(url.concat(props.url,'forms/'));
      const json = await response.json();
      console.log(json);
      setForms(json);
      console.log(forms);
    }
    catch(error)
    {
      setIsLoaded(true);
      setError(error);
      console.log(error);
    }
  }

  useEffect(()=>{
    loadContent();
  },[])

     return (
      <div>

      <table id="leftText">
        <tbody>
          <tr>
            <th>Id</th>
            <th>Form Name</th> 
            <th>#Submissions</th> 
            <th>Submite Page</th> 
            <th>Submissions Page</th> 
          </tr>
        
          {forms.map((form,i)=>
            <tr key={i}>
              <td>{i+1}</td>
              <td>{form.formName}</td>
              <td>{form.submissions}</td>
              <td><Link to="/submission" onClick={()=>onClickSetFormId(form.id)}>Submission</Link></td>
              <td><Link to="/submited" onClick={()=>onClickSetFormId(form.id)}>Submited</Link></td>
            </tr>)}

        </tbody>
      </table>
      <button onClick={()=>{router.push('/form_builder')}}>Add New Form</button>
    </div>
  );
}

export default FormSummary;
