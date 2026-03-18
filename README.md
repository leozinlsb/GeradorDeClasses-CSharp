# Gerador Automático de Classes - Versão C# (WinForms)

## Sobre o Projeto
Este utilitário foi desenvolvido como resolução de um desafio acadêmico. O objetivo era criar uma aplicação desktop capaz de gerar código estruturado automaticamente com base nos inputs do usuário. 

Este projeto demonstra fundamentos sólidos de lógica de programação, manipulação de strings e criação de interfaces com o usuário. 

Como um desafio pessoal e para expandir meu portfólio, também recriei esta mesma ferramenta utilizando Java Swing. Você pode conferir a versão em Java no meu perfil do GitHub

## Funcionalidades
* Interface gráfica construída com Windows Forms.
* Gerenciamento de propriedades através de um `ListBox`.
* Validações de entrada de usuário e regras de negócio.
* **Geração de Código:** Monta a estrutura de uma classe C# contendo:
  * Variáveis privadas.
  * Construtores (padrão e parametrizado).
  * Métodos de encapsulamento (`Getters` e `Setters` com tratamento de exceções `ArgumentException`).
  * Sobrescrita do método `ToString()`.
* Tela de visualização em `RichTextBox` com função prática de cópia para a área de transferência.

## Tecnologias Utilizadas
* **Linguagem:** C#
* **Framework:** .NET / Windows Forms
* **Paradigma:** Orientação a Objetos

## Como Executar
1. Clone este repositório:
   ```bash
   git clone [https://github.com/leozinlsb/GeradorDeClasses-CSharp.git](https://github.com/leozinlsb/GeradorDeClasses-CSharp.git)