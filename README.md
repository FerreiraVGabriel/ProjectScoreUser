⚙️ Sobre o Projeto
Este é um projeto de API REST desenvolvida em .NET Core, seguindo uma arquitetura em camadas (Controller, Service, Repository, Infra, Teste).

Seu principal objetivo é permitir o cadastro de clientes com dados pessoais e o cálculo de um Score de Confiança, conforme critérios de idade e rendimento anual.

A API não utiliza ORM (como Entity Framework), seguindo a exigência da prova técnica, e faz o acesso ao banco de dados via ADO.NET puro.

Além disso, conta com Swagger para testes interativos e testes unitários completos com xUnit + Moq.

📦 Funcionalidades
Cadastro, edição, listagem e exclusão de clientes

Validação de CPF, e-mail, DDD e UF

Cálculo de Score de Confiança baseado em idade e rendimento anual

Endpoint isolado para cálculo de score via query string

Estrutura em camadas com separação clara de responsabilidades

Interface de testes integrada com Swagger

Testes unitários com cobertura das regras de negócio principais

🧠 Regras de Cálculo de Score
Rendimento Anual

R$ 120.000 → +300

R$ 60.000 a R$ 120.000 → +200

< R$ 60.000 → +100

Idade

40 anos → +200

25 a 40 anos → +150

< 25 anos → +50
