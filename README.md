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

##Files
- Program.cs
- README.md

## AI Usage
During the development of this Shopping Cart System (Part 2), AI (ChatGPT) was used as a coding assistant to support the improvement, debugging, and refinement of the program.

## Prompts Given to AI
* How to implement cart management features (view, remove, update, and clear items)
* How to properly validate user input using `TryParse`
* How to resolve issues with incorrect stock updates
* How to generate receipts with date/time and receipt numbers
* How to validate Y/N inputs until a correct response is entered
* How to implement order history using arrays

## Areas Where AI Assisted
* Debugging stock deduction to ensure accurate inventory updates
* Improving input validation to prevent runtime errors (e.g., invalid inputs, empty cart scenarios)
* Structuring the cart system to avoid duplicate item handling issues
* Enhancing the checkout process, including payment validation and change computation
* Implementing the low stock alert feature after checkout
* Organizing overall program flow for better readability and logical structure

## Modifications Made by the Developer
* Adjusted AI-generated code to comply with project requirements (e.g., using arrays instead of advanced data structures)
* Modified discount logic based on assignment specifications
* Added extra validation checks for edge cases such as empty cart and invalid selections
* Ensured the program followed the required menu structure and flow
* Tested and refined stock management to maintain consistency between cart operations and inventory updates

All AI-generated suggestions were carefully reviewed, understood, and manually integrated into the final implementation.
