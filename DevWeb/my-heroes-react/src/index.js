import React from 'react';
import ReactDOM from 'react-dom';

import './index.css';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/css/bootstrap-theme.css'
import Hero from './Hero';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<Hero />, document.getElementById('root'));
registerServiceWorker();
