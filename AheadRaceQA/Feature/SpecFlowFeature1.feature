Feature: Basic Validation
	


Scenario Outline: Basic validation
Given The user is on the store page under Browser stack
| Browser   | BrowserVersion   | OS   | Build   |
| <Browser> | <BrowserVersion> | <OS> | <Build> |
When 1 items are added to the cart
And I navigate to Cart
And Cart is validated
And The total value of items 1 and payment $39.11 is verified 
And The delete button appears for the added item
And The clear button is clicked
Then The cart is cleared

Examples: 
| Browser       | BrowserVersion    | OS      | Build        |
| Chrome        | 92.0              | Windows | Stable Build |
| Firefox       | 86.0              | Windows | Stable Build |
| MicrosoftEdge | 87.0              | Windows | Stable Build |
| Chrome        | 92.0              | OS X    | Stable Build |
| Safari        | 14.0              | OS X    | Stable Build |



Scenario: Advanced validation
Given The user is on the store page under Browser stack
| Browser   | BrowserVersion   | OS   | Build   |
| <Browser> | <BrowserVersion> | <OS> | <Build> |
When 2 items are added to the cart
And I navigate to Cart
And Cart is validated with both Item.
And The qty is increased to 3 for first item
And The total value of items 4 and payment $168.34 is verified 
And Reduce and delete button for both the items are verified
And Item 1 is reduced by 1 unit
And The total value of items 3 and payment $129.23 is verified 
And Item 2 is deleted and validated
Then The checkout functionality is verified
And The cart is cleared

Examples: 
| Browser       | BrowserVersion | OS             | Build        |
| Chrome        | 92.0           | Windows        | Stable Build |
| Firefox       | 86.0           | Windows        | Stable Build |
| MicrosoftEdge | 87.0           | Windows	      | Stable Build |
| MicrosoftEdge | 90.0           | OS X           | Stable Build |
| Firefox       | 90.0           | OS X           | Stable Build |


Scenario Outline: Mobile Validation
Given The user is on the store page under Browser stack
| Browser   | Device   | Os_Version   | Build   | Platform |
| <Browser> | <Device> | <Os_Version> | <Build> | Platform |
When 1 items are added to the cart
And I navigate to Cart
And Cart is validated
And The total value of items 1 and payment $39.11 is verified 
And The delete button appears for the added item
And The clear button is clicked
Then The cart is cleared

Examples: 
| Browser | Device                 | Os_Version | Build        | PlatForm |
| Chrome  | Samsung Galaxy S9 Plus | 9.0        | Stable Build | Mobile   |
| Safari  | iPhone 12              | 14.0       | Stable Build | Mobile   |