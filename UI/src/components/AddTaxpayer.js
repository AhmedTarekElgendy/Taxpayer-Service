import React, { useState } from 'react';
import{ Button , Input , Form , FormGroup , Label,Dropdown,DropdownItem } from 'reactstrap'
import {Link} from 'react-router-dom'
import axios from 'axios';

export const AddTaxpayer =()=>{
    
const [taxpayer , setTaxpayer] = useState({
    FirstName:"",
    SecondaryName:"",
    Phone:"",
    Address:"",
    Email:"",
    Language:0
}); 

const handleClick = ()=>{

var responpost= axios.post("https://localhost:44307/api/taxpayer",{
    FirstName: taxpayer.FirstName,
    SecondaryName: taxpayer.SecondaryName,
    Phone: taxpayer.Phone,
    Address: taxpayer.Address,
    Email: taxpayer.Email,
    Language: taxpayer.Language
  }).then((response) => {

    console.log("success",response.data);
    })
    .catch((error) => {
        console.log("error",error);
    });;
console.log("post op",responpost);
};

const handleChange = (event) =>{
    if(event.target.name=== "Language")
    {
        setTaxpayer({...taxpayer,[event.target.name]:Number(event.target.value)});
    }
    else{
        setTaxpayer({...taxpayer,[event.target.name]: event.target.value});
    }
}

const handleSubmit = (event) =>{
 event.preventDefault();
};

    return (
        <form className="parent" onSubmit={e=> handleSubmit(e)}>
            <FormGroup>
                <Input name="FirstName" onChange={e =>handleChange(e)} className="mt-4 ml-4" type="Text" placeholder="First Name"/>
                <Input name="SecondaryName" onChange={e =>handleChange(e)} className="mt-4 ml-4" type="Text" placeholder="Secondary Name"/>
                <Input name="Phone" onChange={e =>handleChange(e)} className="mt-4 ml-4" type="Text" placeholder="Phone"/>
                <Input name="Address" onChange={e =>handleChange(e)} className="mt-4 ml-4" type="Text" placeholder="Address"/>
                <Input name="Email" onChange={e =>handleChange(e)} className="mt-4 ml-4" type="Text" placeholder="Email"/>

                <select name="Language" onChange={e =>handleChange(e)}>
                    <option key="1" value="1">Arabic</option>
                    <option key="2" value="2">English</option>
                </select>

                <Button type="submit" onClick={handleClick} className="mt-4 btn btn-primary ml-4">Add Taxpayer</Button>
                <Link to="/" className="btn btn-danger mt-4 ml-4">Cancel</Link>
            </FormGroup>
        </form>
    )
}