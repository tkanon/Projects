import random

print("Disclaimer: All answers are case sensitive and must start with a capital letter")
name = input("Enter your name: ")
print("Welcome to play", name)

def wantPlay():
    answer = 0
    while answer != "Y" or "N":
        answer = str(input("Do you want to play? Y/N "))
        if answer == "Y":
            play = True
            break
        elif answer == "N":
            play = False
            break
        else:
            print("You must enter valid answer. Y/N")
    return play

def botInput():
    bot = random.randint(1,3)
    if bot == 1:
        bot = "Rock"
        print(bot)
    elif bot == 2:
        bot = "Paper"
        print(bot)
    elif bot == 3:
        bot = "Scissors"
        print(bot)
    return bot

def main():
    play = wantPlay()
    while play == True:
        print("Good luck!")
        player = str(input("Choose Rock, Paper or Scissors: "))
        bot = botInput()

        if player == bot:
            situation = 0
        elif player == "Rock" and bot == "Paper":
            situation = 1
        elif player == "Rock" and bot == "Scissors":
            situation = 2
        elif player == "Paper" and bot == "Rock":
            situation = 2
        elif player == "Paper" and bot == "Scissors":
            situation = 1
        elif player == "Scissors" and bot == "Rock":
            situation = 1
        elif player == "Scissors" and bot == "Paper":
            situation = 2

        if situation == 0:
            print("It's a draw!")
        elif situation == 1:
            print("Ahh shoot! You lost.")
        elif situation == 2:
            print("Congratulations!! You won!!!")

        answer = input("Do you want to play again? Y/N ")
        if answer == "Y":
            play = True
        else:
            play = False
    if play == False:
        quit()

main()