## **LoanSimPriceAPI**

Este projeto é uma API em .NET usando ASP.NET Core, projetada para simulação de empréstimos com base no método de amortização Price. Ela oferece endpoints para calcular parcelas fixas, juros, amortização e saldo devedor ao longo do tempo, sendo ideal para aplicações financeiras que exigem cronogramas detalhados de pagamento.

---

## 🚀 **Funcionalidades**

- Simulação de empréstimos baseada no método Price
- Cálculo de parcelas mensais fixas, juros totais e saldo devedor

---

## ⚙️ **Requisitos**

- .NET SDK (versão 8.0.0 ou superior)
- SQL Server
- Docker e Docker Compose
- Visual Studio, Visual Studio Code ou JetBrains Rider

---

## 🏃 **Como Rodar o Projeto**

### 🔥 **Rodar com Docker**

Um script `run_project.bat` foi fornecido para automatizar todo o processo. Ele:

- Remove containers Docker existentes
- Inicializa o ambiente com Docker Compose
- Remove migrações anteriores
- Cria nova migração (`InitialCreate`)
- Atualiza o banco de dados

### 🔧 **Passos para execução com Docker:**

1️⃣ **Certifique-se de que o Docker e o Docker Compose estão instalados e em execução.**

2️⃣ **Execute o script `run_project.bat`:**
```bash
  ./run_project.bat
```

3️⃣ **Verifique se os containers estão rodando:**
```bash
  docker ps
```

Se preferir rodar os comandos manualmente, siga:
```bash
  # Remover containers existentes
  docker-compose down -v --rmi all --remove-orphans

  # Iniciar Docker Compose
  docker-compose up -d
  
  # Remover migração anterior
  dotnet ef migrations remove -f
  
  # Criar nova migração
  dotnet ef migrations add InitialCreate
  
  # Atualizar banco de dados
  dotnet ef database update
```

### 🌐 **Acessar a API:**
A API estará disponível em:
```bash
  https://localhost:5001/api
```

---

## 🧩 **Endpoint da API**

- **POST /api/loans/simulate** – Criar uma nova simulação de empréstimo

### 🔗 **Exemplo de Requisição (JSON)**

```json
{
  "loanAmount": 10000.0,
  "annualInterestRate": 0.05,
  "numberOfMonths": 12
}
```

### 📄 **Resposta esperada:**
```json
{
  "monthlyPayment": 856.07,
  "totalInterest": 272.84,
  "totalPayment": 10272.84,
  "paymentScheduleDetails": [
    {
      "month": 1,
      "principal": 789.40,
      "interest": 66.67,
      "balance": 9210.60
    },
    ...
  ]
}
```

📌 **Observação:** Utilize ferramentas como **Postman** ou **Swagger** para testar o endpoint.

---

## 🧪 **Executar Testes**

Se houver testes unitários disponíveis:
```bash
  dotnet test
```

---

## 🎨 **Documentação da API (Swagger)**

A documentação estará disponível em:
```bash
  https://localhost:5001/swagger/index.html
```

---

## 📜 **Licença**

Distribuído sob a Licença MIT. Consulte `LICENSE` para mais informações.

