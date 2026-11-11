# CIS641 Team Spaghetti

## Meeting Notes

Team name: Spaghetti

Members present: Joshua Cooling

Date: 11/10/26

Time: 9:00 PM

Discussion points:

* Built the "View As" selector, which lets the dashboard switch between sample users without logging in. The selected user is remembered across pages.
* Added a Reports page that lists only the reports the active user's role is permitted to view.
* Report pages now check the active user's role before loading any data and show an access denied message when the role does not have permission.
* Built a simple version of the Department Expenses report, which also made it possible to test that restricted reports are blocked.
* Decided to keep the template's login and registration pages for now. They will be revisited once the remaining reports are built.
* Updated Jira as tasks were completed. Milestone 2 (Framework Proven) is complete and Milestone 3 (Reporting Foundation) has started, which puts the project close to back on schedule.

Goals for next week (include responsibilities)

* Joshua - Build a simple version of the Profit Overview report.
* Joshua - Verify that role-based access works correctly on all three reports.
* Joshua - Move report page information into the database so that new reports can be added without changing the core framework.
* Joshua - Keep Jira updated as tasks are completed.