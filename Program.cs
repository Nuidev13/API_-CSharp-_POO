﻿using Biblioteca.Dominio;

ItemAcervo Rubber = new DVD("Rubber", "Pneu");
ItemAcervo deathNote = new Revista("Death Note", "Tsugumi Ohba");
ItemAcervo Sharknado = new DVD("Sharknado", "sharkão");
ItemAcervo Hamlet = new Livro("Hamlet", "William Shakespeare");
ItemAcervo Rei_Lear = new Livro("Rei Lear", "William Shakespeare");
ItemAcervo amnesia = new Revista("Amnésia", "Autor esqueceu");
ItemAcervo Final = new Revista("É o fim", "Autor END...");
ItemAcervo Batman= new Revista("Batman", "Bob Kane");
ItemAcervo Spiderman = new Revista("Spiderman", "Stan Lee");


Emprestimo emprestimo = new Emprestimo(Hamlet);
Emprestimo emprestimo1 = new Emprestimo(Rubber);
Emprestimo emprestimo2 = new Emprestimo(deathNote);
Emprestimo emprestimo3 = new Emprestimo(Batman);
Emprestimo emprestimo4 = new Emprestimo(Spiderman);

emprestimo.RegistrarDevolucao();
emprestimo1.RegistrarDevolucao();
emprestimo2.RegistrarDevolucao();
emprestimo3.RegistrarDevolucao();
emprestimo4.RegistrarDevolucao();