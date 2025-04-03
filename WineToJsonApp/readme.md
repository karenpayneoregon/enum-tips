# About

This project was born from an exercise to replace a `T4 template` that generated an enum by reading values from a database table to make code more manageable. The exercise called on using AI to see how well the AI assistant could perform, and it did well.   All code was placed into Program.cs then moved to separate classes using Visual Studio’s refactoring tools. 

Can you guess which AI assistant was used?

Where it started was in the following project `EnumHasConversionSample` using a T4 template.

## Before running.

1. Create a database called `EF.Wines` in your local SQL Server.
1. Populate the database with the script in the `Scripts` folder.

## Exception handling

There is no exception handling in this project.  It is a simple project to demonstrate the use of AI to generate code.  

## Summary

Although T4 templates work well, they can be difficult for developers to create, which can be tedious. So, I did a project that creates an enum from a database table using AI to write most of the code. The code generation is just over one hundred lines, while the T4 is just over fifty lines. However, remember that T4 templates are not something most developers know how to write.


