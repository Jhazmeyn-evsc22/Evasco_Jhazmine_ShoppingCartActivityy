# Evasco_Jhazmine_ShoppingcartActivity

## Summary of Changes

This Pull Request introduces major enhancements to the Shopping Cart System by expanding its functionality beyond basic add-to-cart features. The system now supports full cart management, checkout validation, receipt generation, and order tracking.

## Features Implemented

Cart Management

- View cart items
- Remove items from cart
- Update item quantities
- Clear entire cart
- Proceed to checkout

Product Browsing

- Search products by name
- Filter products by category (Food, Electronics, Clothing)

Checkout & Payment Validation

- Ensures payment input is numeric
- Prevents insufficient payment
- Automatically calculates change

Receipt System

- Generates unique receipt number (e.g., 0001)
- Displays date and time of transaction
- Shows purchased items and totals
- Includes payment and change details

Low Stock Alert

- Displays products with stock ≤ 5 after checkout

Order History

- Stores completed transactions during runtime
- Displays receipt number and final total per order

Input Validation Improvements

- All menu inputs are validated
- Y/N prompts strictly enforce valid responses

## How to Run
- Open the project in Visual Studio
- Build the solution
- Run the program
- Follow the console menu instructions

## Sample Output of the Program
<img width="373" height="373" alt="image" src="https://github.com/user-attachments/assets/b65cc616-0c20-4edd-ae36-fdcb12290507" />


## AI Usage
AI tools (ChatGPT) were used in the development of this project for the following:

- Helped design the structure of the Shopping Cart System
- Assisted in creating cart management features (add, remove, update items)
- Provided guidance for implementing payment validation and change computation
- Helped generate logic for receipt formatting and order history storage
- Suggested improvements for input validation and menu flow

All code was reviewed, tested, and modified by the developer to ensure correctness and understanding.
