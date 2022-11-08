import random

targetMin = int(input("Enter your range's minimum number: "))
targetMax = int(input("Enter your range's maximum number: "))
targetNum = int(random.randint(targetMin, targetMax))

def takeGuess():
    moro = int(input("Enter your guess: "))
    return moro

def startGame():
    guess = 0
    while guess != targetNum:
        guess = takeGuess()
        if guess > targetNum:
            print("You guessed too high, guess again!")
        elif guess < targetNum:
            print("You guessed too low, guess again!")
        elif guess == targetNum:    
            print("You win the game!")
            break

startGame()