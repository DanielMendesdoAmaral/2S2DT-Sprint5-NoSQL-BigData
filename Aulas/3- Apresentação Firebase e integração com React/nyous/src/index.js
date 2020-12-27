import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import * as serviceWorker from './serviceWorker';

//Para trabalhar com o firebase, você precisa indicar o provider, ou seja, dados do seu projeto do firebase, referenciar ele.
import {FirebaseAppProvider} from "reactfire";
import {firebaseConfig} from "./utils/firebaseConfig";

import Login from "./pages/login/login";
import Register from "./pages/register/register";
import Eventos from "./pages/eventos/eventos";

ReactDOM.render(
  <React.StrictMode>
    {/*Aqui, coloque esta tag passando as configurações do projeto no firebase, referenciando ele.*/}
    <FirebaseAppProvider firebaseConfig={firebaseConfig}>
      <Eventos/>
    </FirebaseAppProvider>
  </React.StrictMode>,
  document.getElementById('root')
);

serviceWorker.unregister();