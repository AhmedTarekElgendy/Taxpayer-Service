import React, { useState, useEffect } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';



export const TaxpayerList = () =>{

    const [TaxpayerList , setTaxpayerList] = useState([]);

    useEffect(()=>{
        loadTaxpayers();
    },[])
    
    const loadTaxpayers = ()=>{

     var axresponse=  axios.get("https://localhost:44307/api/taxpayer")
     .then(response => {
        setTaxpayerList(response.data);
    });

    };

    return(<table  className="table mt-4">
        
            <thead>
                <th scope="col">ID</th>
                <th scope="col">First Name</th>
                <th scope="col">Secondary Name</th>
                <th scope="col">Phone</th>
                <th scope="col">Address</th>
                <th scope="col">Email</th>
                <th scope="col">Language</th>
            </thead>
            <tbody>
            {TaxpayerList.map(tax =>(
                <tr>
                   <th scope="row">{tax.id}</th> 
                   <td>{tax.firstName}</td> 
                   <td>{tax.secondaryName}</td> 
                   <td>{tax.phone}</td> 
                   <td>{tax.address}</td> 
                   <td>{tax.email}</td> 
                   <td>{tax.language}</td>
            </tr>
            )
                )
            }
            </tbody>

        

    </table>)
}