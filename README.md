# Sudoku Solver
Welcome to my sudoku solver...

## Setup
To start using my solver, and hopefully like it as much as i do follow these steps:
1. use git clone to clone my repo
2. build the solution
3. run the build

## Usage
My sudoku is very easy to use, even a sigitai can get it.
Once youll start the application, a basic menu will pop up with 3 options:

1. Enter sudoku board from console
2. Enter sudoku board from file
3. exit
### Input
A string of numbers, eaech unsolved cell will be marked as 0.
When given a file its imortant to give the files full path's and make sure to format it so each line contains a single board with no whitespaces or empty lines.

### Output
Each board you will solve will be printed nicely on the console (if solvable).
additionally the solved board(as a string) will be appended to a file named OutputFile which you will find under Documents folder on your machine.
## Featurs
My solver uses many technics for afficent solving.
#### Naked singel
#### Hidden singel
#### Naked sets

I have explained thoroughly on each of them in my code documentation (Heuristics directory under solving unit)
one thing that is worth mentioning is that the naked sets heuristc is only used **once** for 9X9 boards exclusively.
that because of its factorial time complecity. and yet its a geat way to open up the board early on.

## Testing
I have used an xUnit testing project for unit testing.
you will find that I have implemented both sanity and somke tests.
As instracted I have used AAA testing pattern.

**Good Luck, and happy code review**
 
 by Ori Asulin.

