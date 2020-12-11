import React, {useState, useEffect} from "react";
import {Jumbotron, Card, Form, Container, Button, Row, Col} from "react-bootstrap";
import {db} from "../../utils/firebaseConfig";

const Eventos = () => {
    const [id, setId] = useState("");
    const [nome, setNome] = useState("");
    const [descricao, setDescricao] = useState("");

    const [eventos, setEventos] = useState([]);

    useEffect(() => {
        listarEventos();
    }, []);

    const listarEventos = async () => {
        //Pega os documentos da coleção "Eventos" do firestore.
        const result = (await db.collection("Eventos").get()).docs
        //Percorre os documentos e cria um objeto "resumido" (os documentos vêm criptografados).
        const data = result.map(documento => {
            return {
                id: documento.id,
                nome: documento.data().nome,
                descricao: documento.data().descricao
            }
        });
        setEventos(data);
        limparCampos();
    }

    const salvar = (event) => {
        event.preventDefault();

        const evento = {
            nome: nome, 
            descricao: descricao
        }

        if(id==="")
            db.collection("Eventos").add(evento);
        else {
            //Pega o documento pelo id e insere um documento com novos valores.
            db.collection("Eventos").doc(id).set(evento);
        }

        listarEventos();
    }

    const excluir = async (id) => {
        await db.collection("Eventos").doc(id).delete();
        listarEventos();
    }

    const editar = async (id) => {
        try {
            //Pega o documento com o id especificado.
            const result = await db.collection("Eventos").doc(id).get();
            setId(id);
            setNome(result.data().nome);
            setDescricao(result.data().descricao);
        } 
        catch (error) {
            console.log(error);
        }
    }

    const limparCampos = () => {
        setId("");
        setNome("");
        setDescricao("");
    }

    return (
        <Container> 
            <Jumbotron>
                <h1>Eventos</h1>
                <p>Gerencie os eventos</p>
            </Jumbotron>
            <Card>
                <Card.Body>
                    <Form onSubmit={salvar}>
                        <Form.Group>
                            <Form.Label>Nome</Form.Label>
                            <Form.Control type="text" value={nome} onChange={event => setNome(event.target.value)}></Form.Control>
                        </Form.Group>

                        <Form.Group>
                            <Form.Label>Descrição</Form.Label>
                            <Form.Control as="textarea" rows={3} value={descricao} onChange={event => setDescricao(event.target.value)}/>
                        </Form.Group>

                        <Button variant="success" type="submit" style={{marginTop: "15px"}}>
                            Salvar
                        </Button>
                    </Form>
                </Card.Body>
            </Card>
            <Row style={{marginTop: "50px"}}>
                {
                    eventos.map((item, index) => {
                        return (
                            <Col xs="4" key={index}>
                                <Card>
                                    <Card.Body>
                                        <Card.Title>{item.nome}</Card.Title>
                                        <Card.Text>
                                            {item.descricao}
                                        </Card.Text>
                                        <Button variant="danger" value={item.id} onClick={event => excluir(event.target.value)}>
                                            Excluir
                                        </Button>
                                        <Button variant="primary" value={item.id} style={{marginLeft: "15px"}} onClick={event => editar(event.target.value)}>
                                            Editar
                                        </Button>
                                    </Card.Body>
                                </Card>
                            </Col>
                        )
                    })
                }
            </Row>
        </Container>
    )
}

export default Eventos;