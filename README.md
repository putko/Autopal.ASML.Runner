# Autopal.Asml.Runner
 * [Purpose of this project](#purpose-of-this-project)  
 * [Problem definitions](#problem-definitions)
 * [Solutions](#solutions)
## Purpose of this project
This is a command line application serving as an interface to solve problems. 
This project is implemented as a technical assignment part of job interview with [ASML](https://www.asml.nl/).
## Problem definitions
Create a VisualStudio solution that contains at least the following projects:
 - Executable called “Runner”. It will ask the user which of the problems below to solve.
 - A library called “SumOfMultiple” containing a solution for the following problem:
 -- Find the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input.
 - A library called “SequenceAnalysis” containing a solution for the following problem:
-- Find the uppercase words in a string, provided as input, and order all characters in these words alphabetically.
 -- Input: "This IS a STRING"
 -- Output: "GIINRSST"
 ## Solutions
 - SumOfMultiple
Complexity for the solution is O(1) since the solution is provided with a mathematical formula. 
To find the sum of numbers  multiple of d below N, I used this approach:
Sum of {d, 2d, 3d, ....} = d x {1, 2, 3 , n/d} = d x (n x (n+1)) / 2
- Sequence Analysis
Complexity of the solution is O(n) where n equals to number of chars in the input. 
-- First, Input is splitted into the words. 
-- Then, Words are trimmed.
-- Then, for each word their byte arrays are retrieved.
-- Then, for each byte, calculated the index by subtracting 65 from it. 
-- Then, use that index to find the value in hash array and increase the value by 1.
-- After all, I got an array with 26 elements, each one holding the number of the occurrences for given char. I traverse over this collection and use the value to write how many letters are needed.  