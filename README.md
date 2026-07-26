# LongCalculator
A console application written in C# that performs arithmetic on numbers of arbitrary length, going far beyond the limits of standard integer types

Overview

Standard numeric types in most programming languages are limited to a fixed number of bits, which caps the size of numbers they can represent. This project implements a custom big-number data structure to store and manipulate integers of any length, along with the core arithmetic algorithms needed to operate on them.

Features
Custom data structure for storing digits of arbitrarily large numbers, bypassing built-in integer size limitations
Addition of two arbitrary-precision numbers
Subtraction with correct handling of sign and borrowing
Multiplication implemented from scratch at the digit level
Division of arbitrary-precision numbers
Exponentiation (raising a number to a power)
Factorial computation for arbitrarily large inputs
Save results to file, allowing calculation history/output to be stored and reviewed later
Tech Stack
Language: C#
Interface: Console application
Motivation

This project was built as an exercise in low-level algorithmic thinking — implementing arithmetic operations without relying on built-in big-number libraries, and designing an efficient data structure to represent and manipulate large numbers.
