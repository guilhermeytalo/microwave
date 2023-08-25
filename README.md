# Microondas

## Introdução
Este README fornece uma visão geral do projeto da interface de controle de aquecimento, detalhando suas características, funcionalidades e instruções de uso.

## Tech Stack
 Foi utilizado .net para a construção do backend

## Etapas feitas baseadas no desafio
Nível 1

- [ ] Criação da Interface de Controle
    - [ ] Layout para inserção de tempo e potência.
    - [ ] Opção para entrada numérica por teclado digital ou manual.
    - [ ] Escolha da linguagem para o desenvolvimento.
    - [ ] Integração com o backend em C# (desktop ou web).

- [x] Método de Início do Aquecimento
    - [x] Parâmetros: tempo e potência.
    - [x] Restrições: tempo entre 1 segundo e 2 minutos.
    - [x] Potência varia de 1 a 10 (padrão 10 se não informada).
    - [x] Conversão de tempo entre 60 e 100 segundos para minutos (ex: 90 segundos para 1:30).

- [x] Validações de Operação
    - [x] Mensagem de erro para tempo fora dos limites.
    - [x] Mensagem de erro para potência inválida (fora de 1 a 10).
    - [x] Potência padrão de 10 caso não informada.

- [x] Início Rápido
    - [x] Iniciar aquecimento com potência 10 e tempo de 30 segundos.
    - [x] Acréscimo de Tempo durante o Aquecimento
    - [x] Adicionar 30 segundos ao tempo em execução ao iniciar novo aquecimento.

- [x] String Informativa do Processo de Aquecimento
    - [x] Exibição de uma string com "." por segundo.
    - [x] Número de caracteres por segundo baseado na potência.
    - [x] Concatenar "Aquecimento concluído" ao final.

- [ ] Pausa e Cancelamento do Aquecimento
    - [ ] Botão único para pausar/cancelar.
    - [x] Pausar aquecimento em andamento; retomar se reiniciado.
    - [ ] Cancelar aquecimento pausado, limpando informações.

# Maiores Desafios
O maior desafio foi construir de fato o projeto em C# por ser uma linguagem "nova" para mim, porém a documentação ajudou bastante além de outros sites para entender melhor como utiliza-la. Outro desafio foi deixar o criar abstrações porém isso me deu novas maneiras de identificar e melhorar códigos futuramente
 