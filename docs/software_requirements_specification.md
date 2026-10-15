# Overview

This document defines the functional and non-functional requirements for the Internal Reporting Framework, the term project for CIS641. It specifies what the system must do and the quality attributes it must meet, and serves as a reference for design and implementation decisions for the remainder of the project.

# Functional Requirements

1. Role Simulation
    1. The system shall allow a user to switch between active users by utilizing a "View As" selector, without requiring a login, to simulate viewing the dashboard as different roles.
2. Report Access Control
    1. The system shall display only the reports that the active user's role is permitted to view.
3. Report Viewing
    1. The system shall render visuals for the selected report's data when a user selects the report.
4. Report Export
    1. The system shall allow a user to export the currently viewed report as a PDF.

# Non-Functional Requirements

1. Report Viewing
    1. The system shall render a selected report within 3 seconds of selecting it, using the sample data.
2. Report Access Control
    1. The system shall deny access to a report's data when the active user's role does not meet that report's required permission.
3. Report Framework Extensibility
    1. The reporting framework shall allow a developer to create a new report without having to make modifications to the core framework.
4. Dashboard Reliability
    1. The reporting dashboard shall remain responsive during continuous operation without requiring a restart.