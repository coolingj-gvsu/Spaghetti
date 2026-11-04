# CIS641 Team Spaghetti

## Meeting Notes

Team name: Spaghetti

Members present: Joshua Cooling

Date: 11/3/26

Time: 9:00 PM

Discussion points:

* Continued setting up Jira. Created epics for each milestone and added tasks for the remaining work.
* Defined the database schema for roles, users, reports, and report permissions, based on the class diagram.
* Generated sample data and loaded it into the SQLite database, including 3 roles, 4 sample users, 3 reports, and a year of sales and expense data.
* The database is now created and updated automatically when the application starts.
* Built a simple version of the Regional Sales report, which displays monthly sales by region in a table.
* Milestone 1 (Project Foundation) is complete and Milestone 2 (Framework Proven) has started. The project is still about one week behind the proposal timeline.

Goals for next week (include responsibilities)

* Joshua - Build the "View As" selector to switch between sample users without logging in.
* Joshua - Show only the reports that the active user's role is permitted to view.
* Joshua - Block access to a report's page when the active user's role does not have permission.
* Joshua - Decide whether to keep or remove the template's login and registration pages.
* Joshua - Keep Jira updated as tasks are completed. 