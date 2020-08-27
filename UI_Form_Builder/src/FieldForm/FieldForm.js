import React, { useState } from 'react';
import { useForm} from "react-hook-form";

const FieldForm=(props)=>{
  const { register, handleSubmit, errors } = useForm();
  const [submitDisable, setSubmitDisable] = useState(false);
  const onSaveClick = data =>
  {
    console.log(data);
    setSubmitDisable(true);
    props.callback(data);
  }

  return (
    <div key={props.fromKey} >
      <form key={props.formKey} onSubmit={handleSubmit(onSaveClick)}>
          <label htmlFor='label'>Field Labe:
                  <input type='text' id='label' name='label' ref={register({ required: true})}></input>
          </label>
          <label htmlFor='input_name'>Input Name:
                  <input type='text' id='input_name' name='input_name' ref={register({ required: true})}></input>
          </label>
          <label htmlFor='input_type'>Input Type:</label>
          <select name='input_type' ref={register({ required: true})}>
            {props.types.map((type,i)=>
                <option key={i} name = {type.name} value={type.name}>{type.name}</option>)}
          </select>
          <input type="submit" value="Save" disabled={submitDisable}/>
        </form>
    </div>);
}

export default FieldForm;
