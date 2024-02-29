import re ## Plan to implement algebraic calculation
import math
from time import sleep

class Calculator:
    Result = 0

    def Main(self): # Called to start the program
        self.CalculatorProgram()
        
    def CalculatorProgram(self):
        self.Calculator()
        
        cont = ""
        while not cont == "N":
            cont = input("Continue program? Y/N ").upper()
            if cont == "Y":
                self.Calculator(True if input("Carry over result? Y/anything ").upper() == "Y" else False)
                
        print("Thank you for using this program")                

    def Calculator(self, carryover=False):
        option = self.GiveOptions()
        opperation = self.SelectOperation(option)

        if carryover:
            values = [self.Result]
            print(f"{values[0]} is the first values")
        else:
            values = [int(input("What is the first value? "))]
        
        match(option):
            case 1 | 2 | 3 | 4:
                cont = ""
                while not cont == "N":
                    cont = input("Use more values? Y/N ").upper()
                    if cont == "Y":
                        values.append(int(input("What is the next value? ")))
            case 5 | 6:
                values.append(int(input("What is the second value? ")))

        result = operation(*values)
        self.Result = result 
        print(result[0])
        
    def GiveOptions(self):
        print("Here are some options available")
        sleep(0.125)
        print("1) Addition")
        sleep(0.125)
        print("2) Subtraction")
        sleep(0.125)
        print("3) Multiplication")
        sleep(0.125)
        print("4) Division")
        sleep(0.125)
        print("5) Exponents")
        sleep(0.125)
        print("6) Modulos")
        sleep(0.125)
        option = int(input("Which option do you choose? "))
        
        while not 0 < option < 6:
            print("Invalid choice!!!") 
            option = int(input("Which option do you choose? "))
            
        return option

    def SelectOperation(self, option=1):
        match(option):
            case 1:
                operation = Operation.Add
            case 2:
                operation = Operation.Subtract
            case 3:
                operation = Operation.Multiply
            case 4:
                operation = Operation.Divide
            case 5:
                operation = Operation.Exponent
            case 6:
                operation = Operation.Modulos

        return operation

class Operation:
    @classmethod
    def Add(self, x, *y):
        string = f"{x}"
        for i in y:
            string = f"{string} + {i}"
            
        print(string)
        
        result = x
        for n in y:
            result += n
        return (result, x, *y)
        
    @classmethod
    def Subtract(self, x, *y):
        string = f"{x}"
        for i in y:
            string = f"{string} - {i}"
            
        print(string)
        
        result = x
        for n in y:
            result -= n
        return (result, x, *y)
    
    @classmethod
    def Multiply(self, x, *y):
        string = f"{x}"
        for i in y:
            string = f"{string} * {i}"
            
        print(string)
        
        result = x
        for n in y:
            result *= n
        return (result, x, *y)
    
    @classmethod
    def Divide(self, x, *y):
        string = f"{x}"
        for i in y:
            string = f"({string} / {i})"
            
        print(string)
        
        result = x
        for n in y:
            result /= n
        return (result, x, *y)
    
    @classmethod
    def Exponent(self, x, y):
        print(f"{x} ^ {y}")
        result = x ** y
        return (result, x, y)
    
    @classmethod
    def Modulos(self, x, y):
        print(f"{x} % {y}")
        result = x % y
        return (result, x, y)

c = Calculator()
c.Main()
