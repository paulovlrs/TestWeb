#language: pt-br
Funcionalidade: MeuCarrinho
Itens validados na funcionalidade:
	Pesquisa;
	Inserir item no carrinho;
	Comparar preços antes e depois de inserir no carrinho;
	Ler arquivo com massa de dados

@smoke
Esquema do Cenário: Adicionar itens no carrinho de compra
	Dado Que eu esteja na tela principal
	Quando Preencher a barra de pesquisa <preencherPesquisa>
	E Clicar no botão pesquisa
	E clicar no produto <ListaDeProdutos>
	E salvar as informações dos valores do produto
	E clicar no botão adicionar ao carrinho
	Então Devo visualizar o(s) produto(s) no meu carrinho <produto>
	E Devo verificar se os valores não foram alterados

	Exemplos:
		| preencherPesquisa | ListaDeProdutos | produto |
		| ração             | 3               | Ração   |
		| shampoo           | 1               | Shampoo |
		| Coleira           | 5               | Coleira |