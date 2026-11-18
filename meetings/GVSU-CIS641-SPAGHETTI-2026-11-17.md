# CIS641 Team Spaghetti

## Meeting Notes

Team name: Spaghetti

Members present: Joshua Cooling

Date: 11/17/26

Time: 9:00 PM

Discussion points:

* Built a simple version of the Profit Overview report, which compares monthly sales to expenses and shows the profit for each month.
* Verified that role-based access works correctly on all three reports. Employees can only view Regional Sales, managers can also view Department Expenses, and executives can view all three. Restricted reports show an access denied message when visited directly.
* Moved report page information into the database. Each report now stores its own page path, so new reports can be added to the Reports page without changing the core framework.
* Updated Jira as tasks were completed. Milestone 3 (Reporting Foundation) is complete and Milestone 4 (UI Improvements) has started, which puts the project back on schedule.

Goals for next week (include responsibilities)

* Joshua - Add the ability to export a report to a PDF.
* Joshua - Revisit the template's login and registration pages now that all three reports are built.
* Joshua - Keep Jira updated as tasks are completed.