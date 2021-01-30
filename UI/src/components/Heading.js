import React, { Component } from 'react';
import {Link} from 'react-router-dom';
import {Nav , Navbar , NavbarBrand , NavItem , Container} from 'reactstrap';

export const Heading = () =>{
    return(<Navbar color="dark" dark>
        <Container>
            <NavbarBrand>Taxpayers</NavbarBrand>
            <Nav>
                <NavItem>
                <Link to="/Add" className="btn btn-primary">Add Taxpayer</Link>
                </NavItem>
            </Nav>
        </Container>
    </Navbar>)
}