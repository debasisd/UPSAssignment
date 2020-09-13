# UPSAssignment

# Welcome User management application
In this project we have built User management where user can search, add / edit and delete user.  Based on the action triggered, application will call the corresponding API service end point and perform the activity.

# Architecture 
I have separated the user interface into View (creates the display, calling the Model as necessary to get information) and Controller (responds to user requests, interacting with both the View and Controller as necessary). All layers are loosely coupled. All the layers are separated with their own functionality. It is easy to replace a layer with some other type of layer. 

## Controller: UPSAssignment.Controller
In order to detach logic from the View, I have created the Controller to just hand the View some simple commands that do not require any further processing. According to our design, we did this by defining an interface, IUsersView, which the View must implement. This interface contains only the signatures of properties/methods we need to use.  UserView subscribes the events and then delegate the handling to the Controller then controller communicates with service to interact  with API . Controller UsersController class hooks up the Model (User class) with View (UserView class).

## View: UPSAssignment.View
This section will focus on the scenario of loading the View with the list of users and other user actions. UserView has implemented the IUsersView interface. The SetController() member function of UsersView allows us to tell the View to which Controller instance it must forward the events and all event handlers simply call the corresponding "event" method on the Controller.

## Model: UPSAssignment.Model
This User class is a Model class which only holds the in-memory state in a structured format. 

## Logger: Logmanager
To write error and trace details.

## Client Application: UPSAssignment.Start
It triggered the UserController method to hook up the User with UserView and show the list of users in grid.

# Improvements
## Authentication/Authorization
Config file is containing the token as constant variable, we can create a api method to get the token and set the value to that token.

## Concurrency
To handle the concurrency is optimistic locking in database side with help of "Timestamp" field in table. Currently it is checking the data by pulling just before the injecting the record to database for the update, if the updated date is same in both the cases, we will allow user to update the record else show the message record has been updated by someone else repopulate the grid to check the latest record.
## Test Case
We can add test cases for the controller, for that we will create the stub IUserView and test the corresponding method from controller.
