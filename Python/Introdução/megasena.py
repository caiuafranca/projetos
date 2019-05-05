#!/usr/bin/python
# -*- coding: UTF-8 -*-

"""
  Este trecho de código como gerar um número
  aleatório entre 1 e 10 em Python.
"""

import random
dados = []
jogos=input("Digite a QTD de Jogos") 
j=1
for j in range(0,jogos):
    
    i=1
    for i in range(0,6):
        numero = random.randrange(1, 60);
	print numero,      
    print "\n", 
