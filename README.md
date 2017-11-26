# sevenSnakeProblem
Hackathon Challenge

How to run
----------

Download the latest release and execute the following command:

`SevenSnakeProblem.exe path_to_file`

Solution description
---------

The program starts by loading the file into a N-sized 2-dimensional matrix, where N is the number of elements on the first line of the file.

Then, the program creates all possible combinations of 6 moves (UP, DOWN, LEFT, RIGHT) from a starting point. 
- `UP, UP, UP, UP, UP, UP`
- `UP, UP, UP, UP, UP, DOWN`
- `UP, UP, UP, UP, UP, LEFT`
- `UP, UP, UP, UP, UP, RIGHT`
- `UP, UP, UP, UP, DOWN, UP`
- `....`


From these combinations, some are discarded since they would produce invalid snakes, for example:
- Any sequence that contains an `UP` move followed by a `DOWN` move. (the snake should use 7 distinct cells)
- Any sequence that contains an `UP`, `LEFT` and `DOWN` sequence of moves (this sequence would create a cycle).

There are a total of 12 invalid move sequences.

After getting a M-element list of 6 moves, the program goes through all grid cells and tries to create M snakes based on this list. 

Depending on the initial cell, some moves create out-of-bounds snakes that are discarded.

Everytime a valid snake is created, its `Sum` is stored and is then compared with the `Sum` of other valid snakes prevously identified.

As soon as the program finds a pair of snakes that do not share any cells and have the same `Sum`, it prints the position of the snakes. If a solution cannot be found, the text `FAIL` is printed.

Output format 
----------------------

The program writes to the standard output:

`[(row, col), (row, col), (row, col), (row, col), (row, col), (row, col), (row, col)]`

`[(row, col), (row, col), (row, col), (row, col), (row, col), (row, col), (row, col)]`

or 

`FAIL`

Other information
-------------------

Since a fixed N-sized 2-dimensional matrix is loaded, this may lead to a `System.OutOfMemoryException` if the argument file is big enough. In that case, The program will display an informative message.
