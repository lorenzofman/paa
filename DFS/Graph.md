1) Github

2) Não, a ordem de acesso a lista de adjacência é diferente. A implementação recursiva (com pilha implicita), itera (fazendo DFS) do primeiro nó vizinho até o último, enquanto a implementação com pilha itera (adicionando à pilha) do primeiro nó vizinho até o último, resultando em uma pilha com ordem invertida. O DFS será aplicado iterando do último (primeiro da pilha) até o primeiro vizinho.

3) Cada vértice é colocado na lista de vértices visitados apenas uma vez. O hashset de nós visitados garante isso.

No pior caso todos vértices precisam ser acessados e colocados na lista, então temos um custo de O(n), sendo n o número de vértices. Independente do número de arestas sabemos que, no limite, esse é o custo para todos vértices

A partir do momento que o vértice foi colocado na lista ele ainda pode ser acessado por todas suas arestas e também pode tentar avançar em todas suas arestas (no caso de um grafo bidirecionado). Um vértice tem Mn arestas, assim o custo de um vértice para a segunda parte é O(2 * Mn * n). Assim o custo total é O(2 * MnAvg * n).

Considerando o custo médio de arestas como sendo m, a média de arestas por nó (MnAvg) é m/n, então a segunda parte fica com custo O(2 * m/n * n) = O(2 * m). Juntando as duas partes temos um custo de O(n) + O(* 2m) = O(2 * m+n) = O(m+n).