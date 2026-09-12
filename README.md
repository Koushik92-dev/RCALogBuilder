# RCALogBuilder 🛠️

A lightweight ASP.NET Core web application built with **GitHub Copilot** to streamline production incident documentation and generate standardized, GitHub-flavored Markdown post-mortems (Root Cause Analysis).

---

## Features

- **Structured RCA Capture:** Step-by-step form to collect incident data (downtime start, affected services, trigger, detection, containment, timeline, root cause, and prevention).
- **One-Click Markdown Export:** Automatically compiles entered metrics into a standardized GitHub-flavored Markdown (`.md`) post-mortem report ready for storage in git repositories.
- **Clean Razor Architecture:** Built using ASP.NET Core Razor Pages with a dedicated `IMarkdownExporter` service layer.
- **AI-Assisted Development:** Scaffolding, business logic, and UI bindings developed end-to-end using GitHub Copilot.

---

## Tech Stack

- **Framework:** ASP.NET Core (.NET 8)
- **UI & Views:** Razor Pages + Bootstrap 5
- **Export Format:** GitHub-Flavored Markdown (GFM)
- **Language:** C#

---

## Project Structure

```text
RCALogBuilder/
├── Models/
│   └── IncidentReport.cs       # Data model representing the RCA fields
├── Services/
│   ├── IMarkdownExporter.cs    # Export contract interface
│   └── MarkdownExporter.cs     # Markdown document builder service
├── Pages/
│   ├── Index.cshtml            # Questionnaire UI form
│   └── Index.cshtml.cs         # Post-handler & file download action
└── Program.cs                  # Dependency injection & service configuration
