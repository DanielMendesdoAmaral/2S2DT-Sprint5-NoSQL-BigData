//Aqui, ficarão todas as configurações que envolvam o firebase.

import firebase from "firebase";

//Esse código foi pego das configurações do projeto no firebase, na aba CDN.
export var firebaseConfig = {
    apiKey: "AIzaSyAv5VVr5VSWtYZXFvWCHYJv4WpJFu3BTU0",
    authDomain: "nyous-25721.firebaseapp.com",
    projectId: "nyous-25721",
    storageBucket: "nyous-25721.appspot.com",
    messagingSenderId: "87961019552",
    appId: "1:87961019552:web:cafc10f74b06f84aef15c5"
};
// Inicializa o firebase passando as configurações.
firebase.initializeApp(firebaseConfig);