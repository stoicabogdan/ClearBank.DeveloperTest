# ClearBank.DeveloperTest

## Assumptions
* Do not implement a storage solution
* Refactor Service Layer
* Write corresponding tests

## What has been done

* I have created a new class Library which manages a Account Domain Model.
* The validation for a payment request is handled by the domain model when making a balance change. The ```MakePayment``` method deals only with the hydration of the domain model from the DataStore, calling the update with the changed data and the result return.
* Added Unit Tests for the Domain Model

## Further considerations and improvements

If given more time, the following changes would be added:
 * Adding Dependency Injection for the repository (This could allow the Service Class to be tested and define its lifetime ie. ```Singleton```, ```Transient```, ```Scoped```)
 * Write up tests for the Payment Service Class

