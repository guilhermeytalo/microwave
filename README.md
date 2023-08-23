# README da Interface de Controle de Aquecimento

## Introdução
Este README fornece uma visão geral do projeto da interface de controle de aquecimento, detalhando suas características, funcionalidades e instruções de uso.

## Criação da Interface
- A interface permite que os usuários informem as configurações de tempo e potência de aquecimento.
- O arranjo dos elementos da interface é flexível e fica a critério do desenvolvedor.
- A entrada pode ser fornecida por meio de um teclado digital ou pelo teclado convencional.
- O backend pode ser implementado em C# e integrado em aplicativos desktop ou web.

## Iniciar o Aquecimento
- Para iniciar o aquecimento, utilize uma configuração personalizada de tempo e potência.
- O tempo de aquecimento varia de 1 segundo a 2 minutos.
- A potência pode ser configurada entre 1 e 10.
- Se a potência não for especificada, o valor padrão de 10 será utilizado.
- O tempo entre 60 e 100 segundos é convertido para minutos.

## Validações
- As configurações de tempo e potência estão sujeitas a validações.
- Valores inválidos de tempo geram mensagens solicitando uma entrada válida.
- Valores de potência fora da faixa geram mensagens de erro.
- Se a potência não for fornecida, o valor padrão de 10 será utilizado.

## Início Rápido
- Inicie o aquecimento rapidamente sem especificar tempo ou potência.
- As configurações padrão para o início rápido são potência 10 e tempo 30 segundos.

## Extensão de Tempo
- Ao iniciar o aquecimento durante um processo em andamento, 30 segundos são adicionados ao tempo restante.

## Exibição do Progresso do Aquecimento
- Mostre um indicador dinâmico de progresso baseado em strings durante o aquecimento.
- O formato utiliza pontos com uma contagem baseada na configuração da potência.
- A mensagem "Aquecimento concluído" é anexada após a conclusão do aquecimento.

## Pausa e Cancelamento
- Um único botão controla pausa e cancelamento.
- A pausa durante o aquecimento permite retomar do mesmo ponto.
- O cancelamento durante a pausa limpa as informações e interrompe o aquecimento.
- O cancelamento antes de iniciar limpa as configurações de entrada.

## Conclusão
Obrigado por explorar as funcionalidades e instruções de uso da interface de controle de aquecimento. Para mais detalhes, diretrizes de implementação e informações sobre como começar, consulte as seções relevantes acima.
