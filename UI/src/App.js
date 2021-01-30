import './App.css';
import {Route , Link, Switch, BrowserRouter as Router}
from 'react-router-dom';
import {Home} from './components/Home';
import {AddTaxpayer} from './components/AddTaxpayer';
import {TaxpayerList} from './components/TaxpayerList';
import {Heading} from './components/Heading';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div>
     <Router>
       <Switch>
         <Route exact path="/" component={Home}/>
         <Route path="/Add" component={AddTaxpayer}/>

       </Switch>
     </Router>
       
    </div>
  );
}

export default App;
