import pandas as pd
from itertools import product

def rps_response(play):
    return {"R": "S", "P": "R", "S": "P"}[play]

def rps_validate(play, player):
    _play = play.upper()
    while not (_play == "R" or _play == "P" or _play == "S"):
        print("Invalid input, please press any of the following: R/P/S")
        _play = input(f'R/P/S player {player}: ').upper()
    return _play

def play_rps(l=6):
    player1 = []
    player2 = []
    results = [[0, 0], [0, 0], 0]
    
    for rounds in range(l):
        _1play = rps_validate(input("R/P/S player 1: "), 1)
        player1.append(_1play)
        
        _2play = rps_validate(input("R/P/S player 2: "), 2)
        player2.append(_2play)

        if (_1play == _2play):
            print("Draw")
            results[2] += 1
            continue
        elif (rps_response(_2play) == _1play):
            print("Player 2 wins")
            results[1][0] += 1
            results[0][1] += 1
            continue
        else:
            print("Player 1 wins")
            results[0][0] += 1 # this player wins
            results[1][1] += 1 # other player lost
            continue
        
    log_rps_data(player1, player2, results)
    update_rps_database(''.join(player1), ''.join(player2), results)

def log_rps_data(p1, p2, r, f="RPS_log.txt"):
    rps_log_file = open(f, "a")
    rps_log_file.write(
        f"Match:\nPlayer 1's plays => {p1}\nPlayer 2's plays => {p2}\nResults:\n\tWins => (Player 1) {r[0][0]}, (Player 2) {r[1][0]}\n\tLosses => (Player 1) {r[0][1]}, (Player 2) {r[1][1]}\n\tDraws => {r[2]}\nEnd of log\n\n")
    rps_log_file.close()

def update_rps_database(p1, p2, r, f="RPS_data.csv"):
    data = {
        "P1_Plays" : p1,
        "P1_Wins" : r[0][0],
        "P1_Losses" : r[0][1],
        "P2_Plays" : p2,
        "P2_Wins" : r[1][0],
        "P2_Losses" : r[1][1],
        "Draws" : r[2]
    }
    df = pd.DataFrame([data])
    df.to_csv(f, mode='a', index=False, header=False)
    
#play_rps()

def generate_rps_possible_playes(l=6):
    file = open("RPS_possibilities.txt", "w")
    possibilities = list(product(["R", "P", "S"], repeat=l))
    
    result = []
    for group in possibilities:
        for element in group:
            result.append(element)
        result.append(" ")

    file.write(''.join(result))
    file.close()

#generate_rps_possible_playes(12)

rps_csv = pd.read_csv("RPS_data.csv")
df = rps_csv.copy()
train_data = list(df["P1_Plays"]) + list(df["P2_Plays"])
train_data = [(first, rem) for first, rem in zip(train_data[0], train_data[1:])]
print(train_data)
