# DevOps Playground 🚀

[![DevOps Playground CI](https://github.com/AleX-GOM98/devops-playground/actions/workflows/ci.yml/badge.svg)](https://github.com/AleX-GOM98/devops-playground/actions/workflows/ci.yml)

Projeto incremental desenvolvido para estudos práticos de **DevOps**, **Platform Engineering**, **Cloud Native** e **SRE**, utilizando um ambiente próximo ao encontrado em projetos corporativos.

O objetivo é construir uma aplicação .NET evoluindo gradualmente desde o desenvolvimento local até um ambiente completo com CI/CD, Kubernetes, observabilidade, infraestrutura como código e GitOps.

---

## 📚 Objetivos

- Praticar Git e GitHub Flow
- Automatizar pipelines com GitHub Actions
- Containerizar aplicações com Docker
- Orquestrar containers com Kubernetes
- Implementar GitOps com ArgoCD
- Provisionar infraestrutura com Terraform
- Automatizar configurações com Ansible
- Monitorar aplicações com Prometheus e Grafana
- Aplicar boas práticas de DevOps e Cloud Native

---

# 🏗 Arquitetura Atual

```text
Developer
     │
git push
     │
     ▼
GitHub
     │
     ▼
GitHub Actions
     │
     ├── Restore
     ├── Build
     ├── Test
     ├── Docker Build
     └── Push GHCR
                │
                ▼
GitHub Container Registry
```

> A partir da Semana 7 a aplicação será implantada em um cluster Kubernetes (Kind).

---

# 🛠 Tecnologias

### Linguagem

- .NET 8
- C#

### Versionamento

- Git
- GitHub
- GitHub Flow

### CI/CD

- GitHub Actions
- GitHub Container Registry (GHCR)

### Containers

- Docker
- Docker Compose

### Banco de Dados

- PostgreSQL
- Entity Framework Core

### Kubernetes (em andamento)

- Kind
- kubectl
- Helm
- ArgoCD

### Observabilidade (planejado)

- Prometheus
- Grafana

### Infraestrutura (planejado)

- Terraform
- Ansible

---

# 📂 Estrutura do Projeto

```text
.
├── .github/
│   └── workflows/
├── ansible/
├── docker/
├── docs/
├── helm/
├── kubernetes/
├── observability/
├── scripts/
├── security/
├── src/
│   ├── DevOpsPlayground.Api
│   ├── DevOpsPlayground.Application
│   ├── DevOpsPlayground.Domain
│   └── DevOpsPlayground.Infrastructure
└── tests/
```

---

# 🔄 Pipeline CI

A pipeline executa automaticamente:

- Checkout do código
- Setup do .NET
- Restore
- Build
- Testes automatizados
- Build da imagem Docker
- Publicação da imagem no GitHub Container Registry

---

# 🌿 Estratégia de Branches

Este projeto segue o **GitHub Flow**.

Branches utilizadas:

```
main
feature/*
bugfix/*
docs/*
hotfix/*
refactor/*
test/*
chore/*
```

Todo desenvolvimento ocorre em branches específicas e é integrado à `main` por meio de Pull Requests.

---

# 🏷 Versionamento

O projeto utiliza **Semantic Versioning**.

| Versão | Conteúdo |
|---------|-----------|
| v0.1.0 | Ambiente inicial |
| v0.2.0 | Linux e Shell Script |
| v0.3.0 | Git e GitHub Flow |
| v0.4.0 | Aplicação .NET |
| v0.5.0 | Docker e Docker Compose |
| v0.6.0 | GitHub Actions e CI |

---

# ▶ Como executar

## Clonar

```bash
git clone git@github.com:AleX-GOM98/devops-playground.git
```

## Restaurar

```bash
dotnet restore
```

## Compilar

```bash
dotnet build
```

## Executar testes

```bash
dotnet test
```

## Docker

```bash
docker compose up -d
```

---

# 📈 Roadmap

- [x] Semana 1 - Ambiente
- [x] Semana 2 - Linux
- [x] Semana 3 - Git
- [x] Semana 4 - .NET
- [x] Semana 5 - Docker
- [x] Semana 6 - GitHub Actions
- [ ] Semana 7 - Kubernetes
- [ ] Semana 8 - Helm
- [ ] Semana 9 - ArgoCD
- [ ] Semana 10 - Terraform
- [ ] Semana 11 - Ansible
- [ ] Semana 12 - Observabilidade
- [ ] Semana 13 - Segurança
- [ ] Semana 14 - Projeto Final

---

# 📄 Licença

Projeto desenvolvido exclusivamente para fins de estudo e evolução profissional em DevOps e Cloud Engineering.