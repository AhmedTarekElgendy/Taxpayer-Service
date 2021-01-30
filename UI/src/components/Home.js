import React, { Component } from 'react';
import {Heading} from './Heading';
import { TaxpayerList} from './TaxpayerList'

export const Home =()=>{
    return(<div>
        <Heading/>
        <TaxpayerList />
    </div>)
}