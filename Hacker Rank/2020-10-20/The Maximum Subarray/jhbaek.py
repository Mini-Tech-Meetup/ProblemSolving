#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the maxSubarray function below.
def maxSubarray(arr):
    answer = []
    length = len(arr)
    dp = [0] * length
    dp[0] = arr[0]
    for i in range(1, length):
        dp[i] = max(dp[i-1] + arr[i], arr[i])
    answer.append(max(dp))
    all_minus = True
    for num in arr:
        if num > 0:
            all_minus = False
    if all_minus:
        answer.append(max(arr))
    else:
        answer.append(sum(list(filter(lambda x: x > 0, arr))))

    return answer

if __name__ == '__main__':

    t = int(input())

    for t_itr in range(t):
        n = int(input())

        arr = list(map(int, input().rstrip().split()))

        result = maxSubarray(arr)

        print(' '.join(map(str,result)))

