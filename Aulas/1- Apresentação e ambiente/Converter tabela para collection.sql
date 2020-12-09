USE nyous;
--Converta todos os dados da tabela "Eventos" para JSON. Copie o JSON, coloque em um JSON Formatter e baixe o arquivo. Entre na collection no Compass, vá em "Adicionar dados" e em "Importar arquivo", insira o JSON baixado.
SELECT * FROM Eventos FOR JSON AUTO;