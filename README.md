# SeguroPlatform

## **Tecnologias Utilizadas**

- [x] .NET 8
- [x] Arquitetura Hexagonal (Ports & Adapters)  
- [x] RabbitMQ
- [X] PostgreSQL
- [x] MongoDb
- [x] Docker
- [x] Repository Pattern  
- [x] Pattern UserCases  

<img width="538" height="521" alt="image" src="https://github.com/user-attachments/assets/b7cc6ea2-e7b1-4f3d-ba8d-ca427ac35821" />



# 🚀 Projeto com Docker

Este projeto utiliza Docker para facilitar a configuração e execução do ambiente. O `docker-compose.yml` está localizado dentro da pasta `docker`.

---

## 🛠 **Pré-requisitos**
Antes de começar, certifique-se de ter instalado:

- [Docker](https://www.docker.com/get-started) (versão mais recente)
- [Docker Compose](https://docs.docker.com/compose/install/)

---

## ▶️ **Como rodar o projeto**

### 1️⃣ Clonar o repositório
```sh
git clone https://github.com/RD-Ricardo/SeguroPlatform.git
cd SeguroPlatform
```

### Comando docker
```sh
docker-compose -f docker/docker-compose.yml up --build
```

### Acesse 
```sh
http://localhost:8080/swagger/index.html
```

