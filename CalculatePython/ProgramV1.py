from time import sleep

class Calculator:
    Result = 0
    Calls = 0
    
    def Main(self):
        self.PrintOptions()
        
        cont = input("Would you like to start me (program)? Y/N ")
        cont = cont.upper()
        sleep(0.125)
        
        while not (cont == "Y" or cont == "N"):
            print("Invalid Response!")
            cont = input("Would you like to start me (program)? Y/N ")
            cont = cont.upper()
            sleep(0.125)
        
        while cont == "Y":
            if self.Calls > 0:
                self.Calculate(True, self.Result)
            else:
                self.Calculate()

            cont = input("Would you like me to continue (the program)? Y/N ")
            cont = cont.upper()
            sleep(0.125)
            
            while not (cont == "Y" or cont == "N"):
                print("Invalid Response!")
                cont = input("Would you like me to continue (the program)? Y/N ")
                cont = cont.upper()
                sleep(0.125)

        print("See you nextime, hopefully...")
            
    def PrintOptions(self):
        print("Welcome to this nice calculator. :)")
        print()
        sleep(1)
        print("There are some optons available to select from:")
        sleep(1)
        print("1) Addition")
        sleep(0.125)
        print("2) Subtraction")
        sleep(0.125)
        print("3) Multiplication")
        sleep(0.125)
        print("4) Floating Division")
        sleep(0.125)
        print("5) Modulos")
        sleep(0.125)
        print("6) Floor Division")
        sleep(0.125)
        print("7) Absolute")
        sleep(0.125)
        print("8) Power")
        sleep(0.125)
        print()
    
    def Calculate(self, carryover=False, carry=0):
        self.Calls += 1
        opt = input("What operation would you like to choose? (1-8) ")
        sleep(0.125)
        print()

        while not (0 < int(opt) < 9):
            print("Invalid Response!")
            opt = input("What operation would you like to choose? (1-8) ")
            sleep(0.125)
            print()
        
        match int(opt):
            case 1:
                print("Addition\n")
                if not carryover:
                    n = int(input("What will number 1 be? "))
                else:
                    n = carry
                    print(f"Carried {carry} to this opperation")
                
                cont = input("Would you like to continue? Y/N ")
                cont = cont.upper()
                while not (cont == "Y" or cont == "N"):
                    print("Invalid Response!")
                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()

                count = 1
                ns = []
                while cont == "Y":
                    count += 1
                    ns.append(int(input(f"What would number {count} be? ")))

                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()
                    while not (cont == "Y" or cont == "N"):
                        print("Invalid Response!")
                        cont = input("Would you like to continue? Y/N ")
                        cont = cont.upper()

                r = self.Add(n, *ns)

                print(f"The sum of {n} and all of {ns} is: {r[0]}")
            case 2:
                print("Subtraction\n")
                if not carryover:
                    n = int(input("What will number 1 be? "))
                else:
                    n = carry
                    print(f"Carried {carry} to this opperation")
                
                cont = input("Would you like to continue? Y/N ")
                cont = cont.upper()
                while not (cont == "Y" or cont == "N"):
                    print("Invalid Response!")
                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()

                count = 1
                ns = []
                while cont == "Y":
                    count += 1
                    ns.append(int(input(f"What would number {count} be? ")))

                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()
                    while not (cont == "Y" or cont == "N"):
                        print("Invalid Response!")
                        cont = input("Would you like to continue? Y/N ")
                        cont = cont.upper()

                r = self.Subtract(n, *ns)

                print(f"The subtraction of {n} and all of {ns} is: {r[0]}")
            case 3:
                print("Multiplication\n")
                if not carryover:
                    n = int(input("What will number 1 be? "))
                else:
                    n = carry
                    print(f"Carried {carry} to this opperation")
                
                cont = input("Would you like to continue? Y/N ")
                cont = cont.upper()
                while not (cont == "Y" or cont == "N"):
                    print("Invalid Response!")
                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()

                count = 1
                ns = []
                while cont == "Y":
                    count += 1
                    ns.append(int(input(f"What would number {count} be? ")))

                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()
                    while not (cont == "Y" or cont == "N"):
                        print("Invalid Response!")
                        cont = input("Would you like to continue? Y/N ")
                        cont = cont.upper()

                r = self.Multiply(n, *ns)

                print(f"The product of {n} and all of {ns} is: {r[0]}")
            case 4:
                print("Division\n")
                if not carryover:
                    n = int(input("What will number 1 be? "))
                else:
                    n = carry
                    print(f"Carried {carry} to this opperation")
                
                cont = input("Would you like to continue? Y/N ")
                cont = cont.upper()
                while not (cont == "Y" or cont == "N"):
                    print("Invalid Response!")
                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()

                count = 1
                ns = []
                while cont == "Y":
                    count += 1
                    ns.append(int(input(f"What would number {count} be? ")))

                    cont = input("Would you like to continue? Y/N ")
                    cont = cont.upper()
                    while not (cont == "Y" or cont == "N"):
                        print("Invalid Response!")
                        cont = input("Would you like to continue? Y/N ")
                        cont = cont.upper()

                r = self.Divide(n, *ns)

                print(f"The division of {n} and all of {ns} is: {r[0]}")
            case 5:
                print("Modulos\n")
                if not carryover:
                    n1 = int(input("What will number 1 be? "))
                else:
                    n1 = carry
                    print(f"Carried {carry} to this opperation")
                
                n2 = int(input("What will number 2 be? "))

                r = self.MOD(n1, n2)
                
                print(f"The modulos of {n1} and {n2} is: {r[0]}")
            case 6:
                print("Floor Division\n")
                if not carryover:
                    n1 = int(input("What will number 1 be? "))
                else:
                    n1 = carry
                    print(f"Carried {carry} to this opperation")
                
                n2 = int(input("What will number 2 be? "))

                r = self.DIV(n1, n2)
                
                print(f"The floor division of {n1} and {n2} is: {r[0]}")
            case 7:
                print("Absolute\n")
                if not carryover:
                    n = int(input("What will number 1 be? "))
                else:
                    n = carry
                    print(f"Carried {carry} to this opperation")

                r = self.ABS(n)
                
                print(f"The absolute of {n} is: {r[0]}")
            case 8:
                print("Power\n")
                if not carryover:
                    n1 = int(input("What will number 1 be? "))
                else:
                    n1 = carry
                    print(f"Carried {carry} to this opperation")
                
                n2 = int(input("What will number 2 be? "))

                r = self.POW(n1, n2)
                
                print(f"{n1} raised to the power of {n2} is: {r[0]}")

        print()
                
    def Add(self, num1, *nums):
        result = num1
        for n in nums:
            result += n
                
        self.Result = result
        return (result, num1, nums)

    def Subtract(self, num1, *nums):
        result = num1
        for n in nums:
            result -= n
                
        self.Result = result
        return (result, num1, nums)

    def Multiply(self, num1, *nums):
        result = num1
        for n in nums:
            result *= n
                
        self.Result = result
        return (result, num1, nums)
    
    def Divide(self, num1, *nums):
        result = num1
        for n in nums:
            result /= n
                
        self.Result = result
        return (result, num1, nums)

    def MOD(self, num1, num2):
        result = num1 % num2
                
        self.Result = result
        return (result, num1, num2)

    def DIV(self, num1, num2):
        result = num1 // num2
                
        self.Result = result
        return (result, num1, num2)

    def ABS(self, num):
        result = num if num > 0 else -num
                
        self.Result = result
        return (result, num)

    def POW(self, num, power):
        result = 1
        if power == 0:
            result = 1
        else:
            for i in range(power):
                result *= num
                
        self.Result = result
        return (result, num, power)

calculator = Calculator()
calculator.Main()
