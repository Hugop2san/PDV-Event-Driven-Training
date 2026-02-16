# Mini PDV • EDA + DDD + Blazor

Mini projeto de estudo simulando um **PDV (Ponto de Venda)** com foco em **Event-Driven Architecture (EDA)** aplicada a um **DDD simplificado**, utilizando **Blazor (.NET 8)**.
 
1- <img width="1920" height="887" alt="image" src="https://github.com/user-attachments/assets/77e4de66-7879-4732-b4d2-9f31d51a7eab" />
2- <img width="1919" height="888" alt="image" src="https://github.com/user-attachments/assets/4c37a117-f023-4f9e-ac1f-4a86ca4abfd2" />
3- <img width="1920" height="885" alt="image" src="https://github.com/user-attachments/assets/42945d2a-3e55-4c83-98e9-803513cb1057" />
4- <img width="1920" height="891" alt="image" src="https://github.com/user-attachments/assets/f4db47d9-fa34-4f32-ab9a-6307d4e7bae9" />

---

## Objetivo

Demonstrar como um evento de domínio (`PedidoCriado`, `PedidoCancelado`) pode acionar múltiplos handlers de forma desacoplada, mesmo em um monólito simples.

## Arquitetura

- **Domain** → Entidades e eventos
- **Application** → Services e contratos
- **Infrastructure** → EventBus em memória + LocalStorage
- **UI (Blazor)** → Interface e interação

### Como funciona a EDA aqui (resumo)

1. A UI chama o `PedidoService`.
2. O serviço publica um evento no `EventBus`.
3. Handlers independentes reagem ao evento.

## Persistência

Para manter o foco na arquitetura:
- Dados armazenados no **LocalStorage**
- Sem banco de dados
- EventBus em memória

---
Projeto criado com foco em aprendizado de arquitetura e desacoplamento em aplicações .NET.
