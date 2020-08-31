import React, { useState, useEffect } from 'react';
import {useHistory } from 'react-router-dom';
import { useForm } from "react-hook-form";

function Submission(props) {
  const router = useHistory();
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [fields, setFields] = useState([]);
  const { register, handleSubmit, errors } = useForm();

  const onSubmit = data => {
    const submission = {
      submitedfields: []
    }
    console.log(data)
    for (var i = 0; i < fields.length; i++) {
      console.log(fields[i]);
      let value = data[fields[i].input_Name];
      console.log(value);
      submission.submitedfields[i]={'field':fields[i], 'value': value }
    }
    sendContent(submission);
    router.push('/');
  };

  const sendContent = async(toSend)=>{
    try{
      console.log(toSend);
      var url='';
      console.log(url.concat(props.url,'forms/',props.form_id,'/submission'));
      const response = await fetch(url.concat(props.url,'forms/', props.form_id,'/submission'),
        {method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(toSend)});
      //const json = await response.json();
    }
    catch(error)
    {
      setIsLoaded(true);
      setError(error);
      console.log(error);
    }
  }

  const loadContent = async()=>{
    try{
      var url='';
      console.log(url.concat(props.url,'forms/',props.form_id));
      const response = await fetch(url.concat(props.url,'forms/', props.form_id));
      const json = await response.json();
      console.log(json.fields);
      setFields(json.fields);
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
        <form  onSubmit={handleSubmit(onSubmit)}>
          {fields.map((field,i)=>
            <div key={i}>
              <label htmlFor={field.input_Name}>{field.label}:<br/>
                <input type={field.input_Type} id={field.input_Name}name={field.input_Name} ref={register({ required: true})}></input><br/>
              </label><br/>
            </div>
          )}
          <button onClick={() => {router.goBack()}}>Back</button>
          <input type="submit" value="Submit"/>
        </form>
    </div>
  );
}

export default Submission;
