#!/usr/bin/python
#-*-coding:latin1-*-
__author__="Caiua Franca"
__date__="$DD/MM/AA hh:mm:ss$"

num=input("Entre com o numero: ")
fat=1

for i in range(1,num+1):
    fat=fat*i  

print "O Fatorial do Numero",num,"é: ",fat
