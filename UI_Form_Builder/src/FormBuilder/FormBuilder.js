import React, { Component, useState, useEffect} from 'react';
import { Link, useHistory, useLocation} from 'react-router-dom';
import FieldForm from '../FieldForm/FieldForm';
import { useForm} from "react-hook-form";

function FormBuilder(props) {
  const router = useHistory();
  const { register, handleSubmit, errors } = useForm();
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [types, setTypes] = useState([]);
  const [fields, setFields] = useState([]);
  const [formKey, setFormKey] = useState(0);
  const [formFileds, setFormField] = useState([]);
  const newFormFields = [];

  const callback = (newField) =>{
    console.log(newField);
    setFormField([...formFileds, newField]);
  }

  const AddFields =()=>{
    console.log('Add new field');
    setFormKey(formKey+1);
    setFields([...fields, <FieldForm types={types} formKey={formKey} callback={callback}/>]);
  }
  
  const onFormSubmit = data =>{
    console.log(data);
    const newForm ={
      fields: formFileds
    }
    if(data.form_name !=="" || data.form_name !==null)
    {
      newForm.form_name = data.form_name;
    }
    console.log(JSON.stringify(newForm));
    sendContent(newForm);
    router.push('/');
  }

  const sendContent = async(toSend)=>{
    try{
      console.log(toSend);
      var url='';
      console.log(url.concat(props.url,'forms/'));
      const response = await fetch(url.concat(props.url,'forms/'),
        {method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(toSend)});
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
      console.log(url.concat(url.concat(props.url,'types/')));
      const response = await fetch(url.concat(props.url,'types/'));
      const json = await response.json();
      console.log(json);
      setTypes(json);
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

  return(
  <div>
    <div>
      <button onClick={AddFields}>Add field</button>
        {fields.map((field,index)=>
          <div key={index}>
            {field}
          </div>
        )}
    </div><br/>
    <form onSubmit={handleSubmit(onFormSubmit)}>
      <label htmlFor='form_name'>Form Name: 
      <input  type='text' id='form_name' name='form_name' ref={register({ required: true})}/>
      </label>
      <input type="submit" value="Save"/>
    </form><br/>
    <button onClick={()=>router.goBack()}>Back</button>
  </div>
  );
}

export default FormBuilder;
