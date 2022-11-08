import random

decision1 = input("Decision #1: ")
decision2 = input("Decision #2: ")
var = random.randint(1,2)
if var == 1:
    print(decision1)
elif var == 2:
    print(decision2)
else:
    print("Error")