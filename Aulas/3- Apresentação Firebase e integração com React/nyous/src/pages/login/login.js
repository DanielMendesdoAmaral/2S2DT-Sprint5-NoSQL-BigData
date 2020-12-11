import React, {useState} from "react";
import {Container, Form, Button} from "react-bootstrap";

//Para trabalhar com o firebase.
import {useFirebaseApp} from "reactfire";

const Login = () => {
    const firebase = useFirebaseApp();

    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    const logar = async (event) => {
        event.preventDefault();
        //Agora, iremos utilizar as bibliotecas do firebase para fazer a autenticação.

        //Chame o método de autenticação do firebase e o signIn.
        try {
            const user = await firebase.auth().signInWithEmailAndPassword(email, senha);
            localStorage.setItem("token", user.user.refreshToken);
        } 
        catch (error) {
            alert("Email ou senha inválidos");
            console.log(error);
        }
    }

    return (
        <div>
            <Container className="form-height">
                <Form style={{marginTop: "20px", height: "50vh"}} onSubmit={event => logar(event)}>
                    <Form.Group controlId="formGroupEmail">
                        <Form.Label>Endereço de email</Form.Label>
                        <Form.Control type="email" placeholder="usuario@email.com" value={email} onChange={event => setEmail(event.target.value)}/>
                    </Form.Group>
                    <Form.Group controlId="formGroupPassword">
                        <Form.Label>Senha</Form.Label>
                        <Form.Control type="password" placeholder="Senha" value={senha} onChange={event => setSenha(event.target.value)}/>
                    </Form.Group>
                    <Button variant="primary" type="submit">Entrar</Button>
                </Form>
            </Container>
        </div>
    )
}

export default Login; 