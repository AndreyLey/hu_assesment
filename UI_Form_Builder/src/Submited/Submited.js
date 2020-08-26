import React, {useEffect, useState } from 'react';
import {useHistory} from 'react-router-dom';

function Submited(props) {
    const router =useHistory();
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [submissions, setSubmissions] = useState([]);
    const [fields, setFields] = useState([]);

    const loadContent = async()=>{
      try{
        var url='';
        console.log(url.concat('http://localhost:5050/forms/',props.form_id,'/submissions'));
        const response = await fetch(url.concat('http://localhost:5050/forms/', props.form_id,'/submissions'));//,props.region,'/countries/',props.country));//"http://localhost:5000/regions/Europe/countries/german");
        const json = await response.json();
        console.log(json);
        console.log(json[0].submitedFields);
        setSubmissions(json);
        setFields(json[0].submitedFields);
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
              {fields.map((field, i)=>
                <th key={i}>{field.field.label}</th> 
              )}
            </tr>
          
            {submissions.map((submission,i)=>
              <tr key={i}>
                {submission.submitedFields.map((field,index)=>
                <td key={index+i}>{field.value}</td>)}
              </tr>)}
  
          </tbody>
        </table>
        <button onClick={() => {router.goBack()}}>Back</button>
      </div>
    );
}


export default Submited;
