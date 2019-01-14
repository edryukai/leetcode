## [777](https://leetcode.com/problems/swap-adjacent-in-lr-string/description/) Swap adjacent LR
* Given: `XL -> LX` and `RX -> XR` and we have to check if s1 can be transformed to s2
* **For any question that involves transforming from one state to another, we have to ask ourselves about invariants**
* **Invariants here**:
    1. `L` and `R` can never cross each other
    2. After transforming, `L` can only move left and `R` can only move right
* `X` doesn't reall matter
* So we check for above two conditions in solution