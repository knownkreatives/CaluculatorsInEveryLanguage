# The example function below keeps track of the opponent's history and plays whatever the opponent played two plays ago. It is not a very good player so you will need to change the code to pass the challenge.
import tensorflow as tf
from tensorflow import keras
from tensorflow.keras import layers
import random
import numpy as np

x = 5
shape = (x, 3)

# Assuming you have a dataset with input features 'X' and labels 'y'
# Replace X_train and y_train with your actual training data
# Make sure your labels are one-hot encoded (e.g., [1, 0, 0] for Rock)

# Example data (replace with your actual data)
X_train = np.random.random((1000, x, 3))  # Input shape: (batch_size, sequence_length, features)
y_train = np.random.randint(3, size=(1000,))  # Labels (0 for Rock, 1 for Paper, 2 for Scissors)

# One-hot encode the labels
y_train_one_hot = tf.keras.utils.to_categorical(y_train, num_classes=3)

# Define the RPS model
model = keras.Sequential([
    layers.Input(shape=(x, 3)),
    layers.LSTM(50, return_sequences=True),
    layers.GlobalAveragePooling1D(),
    layers.Dense(3, activation='sigmoid')
])

custom_optimizer = tf.keras.optimizers.Adam(learning_rate=0.00475)

# Compile the model
model.compile(optimizer=custom_optimizer, loss='categorical_crossentropy', metrics=['accuracy'])

# Train the model
model.fit(X_train, y_train_one_hot, epochs=5, batch_size=15)

# A counter to the opponent's play
def rps_response(play=0):
    return {0: "P", 1: "S", 2: "R"}[play]

def rps_array_sorter(play=""):
    if play == "":
        play = random.choice(["R", "P", "S"])
    arr = [0, 0, 0]
    arr[{"R": 0, "P": 1, "S": 2}[play]] += 1
    return arr

def player(prev_play="", opponent_history=[]):
    # appends the previous play to the opponent_history list
    opponent_history.append(prev_play)
    guess = ""
    
    last_x = opponent_history[-x:]  # Assuming a history length of 5

    if len(last_x) < x:
        for i in range(x - len(last_x)):
            last_x.append(np.random.choice(["R", "P", "S"]))

    # Convert last_x to a format suitable for the model
    last_x_encoded = np.zeros((1, x, 3))
    for i, play in enumerate(last_x):
        last_x_encoded[0, i, :] = rps_array_sorter(play)

    # Make predictions using the model
    predictions = model.predict(last_x_encoded)

    # Choose the most probable play
    predicted_play = np.argmax(predictions)

    guess = rps_response(predicted_play)
    
    print(guess)

    return guess
