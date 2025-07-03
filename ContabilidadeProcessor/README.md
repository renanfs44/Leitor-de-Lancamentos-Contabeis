# 🧪 Teste Prático – Processador de Lançamentos Contábeis

## 💡 Desafio

Completar uma aplicação de console que leia um arquivo `.txt` contendo lançamentos contábeis, preencha objetos `LancamentoContabil` e exiba-os no console.

---

## ✅ Tarefas obrigatórias

- O método `LerLancamentos` em `LancamentoReader.cs` ainda não foi implementado. Sua tarefa é escrevê-lo do zero para ler o arquivo e retornar os lançamentos válidos.
- Ignorar linhas em branco e comentários (`#`).
- Tratar lançamentos inválidos (valores ausentes, datas inválidas, etc).
- Exibir os lançamentos corretamente no console.

---

## 🏗️ Estrutura esperada no arquivo

Cada lançamento contém **5 linhas**:

```
Data: 01/01/2025
Conta: 1234
Histórico: Compra
Valor: 100,00
Tipo: Débito
```

---

## 📁 Localização do arquivo

```
Files/lancamentos.txt
```

---

## 🛠️ Como rodar

1. Abra o projeto no Visual Studio ou Visual Studio Code.
2. Compile e execute o projeto.
3. O resultado será exibido no console.

---

## 🎯 Bônus (não obrigatório)

- Criar um log (ex: `erros.txt`) com os lançamentos inválidos ignorados.
- Exportar os lançamentos válidos para um arquivo `.csv` ou `.json`.

---

## ❓ Dúvidas

Sinta-se à vontade para perguntar qualquer dúvida.

Boa sorte! 🍀
