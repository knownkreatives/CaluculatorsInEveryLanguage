import math
from turtle import *
import numpy as np

class Pen:
    Position = [0, 0]
    Rotation = 0

    def __str__(self):
        return f"Position: {self.Position}\nRotation: {self.Rotation}"
    
    def ResetPenPos(self):
        turtle.goto(0, 0)
        
        self.Position = [0, 0]
    
    def ResetPenRot(self):
        left(self.Rotation)
        
        self.Rotation = 0

    def ResetPen(self):
        resetPenRot()
        resetPenPos()

    def MovePen(self, distance):
        forward(distance)

        vector = [math.cos(-self.Rotation) * distance, math.sin(-self.Rotation) * distance]
        pos = [self.Position, vector]
        self.Position = list(np.sum(pos, axis=0))
    
    def DisplacePen(self, distance):
        penup()
        forward(distance)
        pendown()

        vector = [math.cos(-self.Rotation) * distance, math.sin(-self.Rotation) * distance]
        pos = [self.Position, vector]
        self.Position = list(np.sum(pos, axis=0))
    
    def TranslatePen(self, position):
        turtle.goto(*position)
        
        self.Position = list(np.sum(self.Position, position, axis=0))

    def RotatePen(self, rotation):
        right(rotation)
        
        self.Rotation += rotation

class Geometry:
    CurrentPen = Pen()
    
    def Shape(self, sides=3, distance=50):
        if not sides <= 2:
            for step in range(sides):
                self.CurrentPen.MovePen(distance)
                self.CurrentPen.TurnPen(360 / sides)
        else:
            print("Invalid number of sides")
                
    def Triangle(self, distance=50):
        self.Shape(3, distance)

    def Square(self, distance=50):
        self.Shape(4, distance)

    def Pentagon(self, distance=50):
        self.Shape(5, distance)

    def Hexagon(self, distance=50):
        self.Shape(6, distance)

    def spirograph(self, sides=3, distance=50):
        for repeat in range(2 * sides - 2):
            self.Shape(sides, distance)
            
            self.CurrentPen.TurnPen(180 / (sides - 1))

    def Spiral(self, sides=100):
        for side in range(sides):
            self.CurrentPen.MovePen(side)
            self.CurrentPen.RotatePen(3600 / sides)
