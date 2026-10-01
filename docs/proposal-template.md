Team name: Spaghetti

Team members: Joshua Cooling

# Introduction

There is currently a high demand to generate new reports that can be distributed to specific people for various departments and users in the company. There is legacy infrastructure that has become difficult to maintain and is also not capable of adding modern features like role-based access. Managers and executives just have to hope that users don’t accidentally enter a URL that contains a sensitive report. The legacy reporting structure also does not have centralized business logic. Different reports running in different locations have logic and queries that do not necessarily align with each other. Third party software like Power BI is built for this but comes with recurring licensing costs. For a couple of users, managers find this acceptable, but management also wants these reports accessible by a larger audience, which means that these licensing costs add up. They need a system that will have role-based access, that has a modern user interface, and that does not come with recurring licensing costs.

This project will serve as a framework for a reporting platform that allows for quicker development of reports that will have a modern user interface and built in role-based access. This project will be demonstrated with sample data and users. Upon completion of this project, a reporting framework will exist that will allow a developer to integrate this with their datasets and users. The developer will then be able to quickly create and publish reports with a modern user interface and role-based access. This project will not include automated sending of reports, integration with a live database, or a user interface for creating reports.

# Anticipated Technologies

- ASP.NET Core
- Blazor Server
- SQLite
- GitHub

# Method/Approach

This development approach will be to build and validate the framework's core pieces first. Once that has been completed, I will layer on additional functionality. Once the functionality of the project is working, I will then shift to improving the user interface. Once there is a functional project, with a modern user interface, I will then work on adding additional functionalities to the project. 

1. Setup the project by initializing the ASP.NET Core/Blazor project and the SQLite database. 
2. Define the database schema. 
3. Generate sample data for the database. 
4. Build a simple version of one of the reports.
5. Implement a way to "View As" a specific user.
6. Ensure that reports have RBAC enforcement working correctly. 
7. Build the remaining reports as a simple version, ensuring that RBAC is still working. 
8. Make improvements to all of the sample reports. 
9. Add functionality to save a report as a PDF.

# Estimated Timeline

Milestone 1: Project foundation(Week 1-2) The ASP.NET Core/Blazor project is initialized with a SQLite database that has been defined and populated. 

Milestone 2: Framework Proven(Week 3-4) First simple version of a sample report is built with RBAC. Additionally, I will add functionality to allow switching between users. 

Milestone 3: Reporting Foundation(Weeks 5-6) Build the simple version of the remaining reports, while also ensuring the RBAC is working.

Milestone 4: UI improvements(Weeks 7-8) Make improvements to the sample reports by creating better visualizations and graphics in the UI. Add functionality to allow users to convert the reports to PDFs for distribution. 

Milestone 5: Refine and Documentation(Week 9+) Any extra time will be used to make any additional improvements that are thought of. This time will also be used to ensure that the documentation for the project is done completely and correctly. 

# Anticipated Problems

- Creating a report structure that will make it as simple as possible for a future developer to create new reports. 
- Ensuring that RBAC is working seamlessly when a new report is generated. 
- Time. I work a full time job, so I will have to make sure that I dedicate enough time per week so that I can meet the original timeline as closely as possible. 
