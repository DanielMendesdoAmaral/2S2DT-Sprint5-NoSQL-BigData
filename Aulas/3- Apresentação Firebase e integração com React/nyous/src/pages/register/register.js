import React, {useState} from "react";
import {Container, Form, Button} from "react-bootstrap";

//Para trabalhar com o firebase.
import {useFirebaseApp} from "reactfire";

const Register = () => {
    const firebase = useFirebaseApp();

    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    const registrar = async (event) => {
        event.preventDefault();
        
        try {
            const user = await firebase.auth().createUserWithEmailAndPassword(email, senha);
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
                <Form style={{marginTop: "20px", height: "50vh"}} onSubmit={event => registrar(event)}>
                    <Form.Group controlId="formGroupEmail">
                        <Form.Label>Endereço de email</Form.Label>
                        <Form.Control type="email" placeholder="usuario@email.com" value={email} onChange={event => setEmail(event.target.value)}/>
                    </Form.Group>
                    <Form.Group controlId="formGroupPassword">
                        <Form.Label>Senha</Form.Label>
                        <Form.Control type="password" placeholder="Senha" value={senha} onChange={event => setSenha(event.target.value)}/>
                    </Form.Group>
                    <Button variant="primary" type="submit">Cadastrar</Button>
                </Form>
            </Container>
        </div>
    )
}

export default Register; 