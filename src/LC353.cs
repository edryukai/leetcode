// M 353 Design Snake Game
// Logic:
//
// Game end conditions:
//    - Snake exceeds boundaries
//    - Snake hits itself
//
// Game play:
//    1. When snake takes food, add new head to snake in the block where there is food
//    2. When snake moves, every block shifts one place. This can be modelled as:
//          - Maintain blocks that make up snake body in a dequeue
//          - Add new position of head to the dequeue's head
//          - Remove tail of dequeue
//    3. To check the case where next move could be snake hitting itself, it makes sense to maintain 
//       blocks that fill the snake up in a hashset
// 
// TODO: Code pending, but for now I don't mind

public class SnakeGame {

    /** Initialize your data structure here.
        @param width - screen width
        @param height - screen height
        @param food - A list of food positions
        E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
    public SnakeGame(int width, int height, int[,] food) {

    }

    /** Moves the snake.
        @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down
        @return The game's score after the move. Return -1 if game over.
        Game over when snake crosses the screen boundary or bites its body. */
    public int Move(string direction) {

    }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */
