import functools
import itertools

def vat_faktura(zakupy):
    sum = 0
    for x in zakupy:
        sum += 0.77 * x
    return sum

def vat_paragon(zakupy):
    return 0.77 * sum(zakupy)
    
def drobne(kwota):
    noms = {1 : 0, 2 : 0, 5 : 0, 10 : 0, 20: 0}
    nom = 20 
    while kwota > 0:
        while kwota >= nom:
            kwota = kwota - nom
            noms[nom] = noms[nom] + 1
        nom = int(nom / 2)
    print(noms)

def romb(n):
    h = 1
    spaces = n 
    for _ in range(n):
        print(" " * spaces + '#' * h)
        h += 2
        spaces += -1
    h -= 4
    spaces += 2
    for _ in range(n):
        print(" " * spaces +  '#' * h)
        h -= 2
        spaces += 1


print(vat_faktura([1, 2, 3, 4, 20.5, 115.29]))
print(vat_paragon([1, 2, 3, 4, 20.5, 115.29]))  
drobne(19)
drobne(7)
drobne(51)
x = int(input())
romb(x)